using IrisRobloxMultiTool.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace IrisRobloxMultiTool.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class RobloxGameBot
	{
		private readonly BotProcessInfoViewModel _botProcessModel;

		[DllImport("user32.dll")]
	    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		private static readonly CookieContainer RobloxContainer = new();
		private static readonly HttpClient Client = new(new HttpClientHandler
	    {
		    AllowAutoRedirect = true,
		    AutomaticDecompression = DecompressionMethods.All,
		    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
		    UseCookies = true,
		    UseProxy = false,
		    Proxy = null,
		    CookieContainer = RobloxContainer
	    })
	    {
		    Timeout = TimeSpan.FromSeconds(30),
		    DefaultRequestHeaders =
		    {
			    {"User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.6478.91 Safari/537.36"}
		    }
	    };

	    private async Task<string> GetCsrfToken(string cookie)
	    {
		    RobloxContainer.Add(new Uri("https://auth.roblox.com"), new Cookie(".ROBLOSECURITY", cookie, "/", "auth.roblox.com"));
		    RobloxContainer.Add(new Uri("https://roblox.com"), new Cookie(".ROBLOSECURITY", cookie, "/", "roblox.com"));

		    using HttpRequestMessage request = new(HttpMethod.Post, "https://auth.roblox.com/v2/logout");
		    using HttpResponseMessage response = await Client.SendAsync(request);

		    bool foundHeader = response.Headers.TryGetValues("x-csrf-token", out IEnumerable<string>? headers);

		    if (!foundHeader || headers is null)
			    throw new InvalidOperationException("Failed to refresh CSRF token");

		    return headers.First();
	    }

	    private async Task<string> GetAssertionToken(string cookie)
	    {
		    string csrf = await GetCsrfToken(cookie);

		    Client.DefaultRequestHeaders.Remove("x-csrf-token");
		    Client.DefaultRequestHeaders.Remove("Referrer");

		    Client.DefaultRequestHeaders.Add("x-csrf-token", csrf);
		    Client.DefaultRequestHeaders.Referrer = new Uri("https://www.roblox.com/");

		    string response = await Client.GetStringAsync("https://auth.roblox.com/v1/client-assertion/");
		    using JsonDocument document = JsonDocument.Parse(response);
		    string? clientAssertionToken = document.RootElement.GetProperty("clientAssertion").GetString()?.Trim();

			return clientAssertionToken ?? throw new InvalidOperationException("Failed to get assertion token");
		}

	    private async Task<string> GetAuthenticationTicket(string assertionToken)
	    {
		    using HttpRequestMessage request = new(HttpMethod.Post, "https://auth.roblox.com/v1/authentication-ticket/");
		    request.Content = JsonContent.Create(new { clientAssertion = assertionToken });
		    using HttpResponseMessage authenticationTicketResponse = await Client.SendAsync(request);
		    return authenticationTicketResponse.Headers.GetValues("rbx-authentication-ticket").First();
		}

		public RobloxGameBot()
		{
			InitializeComponent();
			_botProcessModel = new BotProcessInfoViewModel();
			ProcessListGrid.DataContext = _botProcessModel;
		}

		private string GetLaunchCode(long placeId, string authCode)
        {
	        Random rnd = new();
	        long browserTrackerId = 55393295400 + rnd.Next(1, 100);
	        TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
	        int launchTime = (int)t.TotalSeconds * 1000;
	        return $"roblox-player:1+launchmode:play+gameinfo:{authCode}+launchtime:{launchTime}+placelauncherurl:https://www.roblox.com/Game/PlaceLauncher.ashx?request=RequestGame&browserTrackerId={browserTrackerId}&placeId={placeId}&isPlayTogetherGame=false&referredByPlayerId=0&joinAttemptOrigin=PlayButton+browsertrackerid:{browserTrackerId}+robloxLocale:en_us+gameLocale:en_us+channel:+LaunchExp:InApp";
        }

        private static string GetRobloxLocation()
        {
			using RegistryKey? key = Registry.ClassesRoot.OpenSubKey(@"roblox-player\shell\open\command");
			if (key is null) throw new InvalidOperationException("Roblox is not installed on this system.");
			string? value = key.GetValue(null) as string;
			if (value is null) throw new InvalidOperationException("Roblox is not installed on this system. 0x1");
			string trimmedValue = value.Trim('"');
			string robloxParsed = trimmedValue[..trimmedValue.IndexOf('"')];
			return robloxParsed;
        }

		private async Task<Process?> LaunchRobloxGame(long placeId, string cookie)
		{
			string assertionToken = await GetAssertionToken(cookie);
			string authTicket = await GetAuthenticationTicket(assertionToken);
			string robloxPath = GetRobloxLocation();
			
			ProcessStartInfo startInfo = new()
			{
				FileName = robloxPath,
				Arguments = GetLaunchCode(placeId, authTicket),
				CreateNoWindow = true,
				UseShellExecute = false
			};

			Process? robloxProcess = Process.Start(startInfo);

			_ = Task.Run(async() =>
			{
				while (!robloxProcess?.HasExited ?? false)
				{
					ShowWindow(robloxProcess.MainWindowHandle, 0);

					robloxProcess.PriorityClass = ProcessPriorityClass.Idle; 
					robloxProcess.ProcessorAffinity = new IntPtr(1);

					await Task.Delay(150);
				}
			});

			return robloxProcess;
		}

		private readonly CancellationTokenSource _cts = new ();
		
		private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			if (Process.GetProcessesByName("RobloxPlayerBeta").Length > 0) 
			{ CustomMessageBox.ShowDialog("Roblox is currently running, please close all clients and then reload application page."); return; }

			try { _ = new Mutex(true, "ROBLOX_singletonMutex"); } catch {/**/}

			_ = Task.Run(async () =>
			{
				try
				{
					while (!_cts.IsCancellationRequested)
					{
						foreach (BotProcessInfo processInfo in _botProcessModel.BotProcessInfos)
						{
							processInfo.ActiveTime = processInfo.ActiveTime.Add(TimeSpan.FromSeconds(1));
						}

						await Task.Delay(1000);
					}
				} catch {/**/}

			});

			_botProcessModel.BotProcessInfos.Clear();

			for (int i = 0; i < 5; i++) // Simulate 5 bot processes
			{
				_botProcessModel.BotProcessInfos.Add(new BotProcessInfo(this)
				{
					Username = $"User{i + 1}",
					UserId = 1000 + i,
					ProcessId = 5000 + i,
					ActiveTime = TimeSpan.Zero
				});
				AppInvoke(UpdateLayout);
			}
		}
		
		private string _selectedFilePath = string.Empty;
		
		private void SelectBotFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new()
			{
				Filter = "All Files (*.*)|*.*",
				Title = "Select Bot Input File"
			};

			if (dlg.ShowDialog() != true) return;
			_selectedFilePath = dlg.FileName;

			CustomMessageBox.ShowDialog($"Selected file: {Path.GetFileName(_selectedFilePath)}");
		}

		private void ClearBotFile_Click(object sender, RoutedEventArgs e)
		{
			_selectedFilePath = string.Empty;
			CustomMessageBox.ShowDialog("Input file cleared.");
		}


		private void StartBot_Click(object sender, RoutedEventArgs e)
		{
			string placeId = PlaceIdBox.Text;
			bool isHidden = WindowModeToggle.IsChecked ?? false;

			if (string.IsNullOrWhiteSpace(placeId))
			{
				CustomMessageBox.ShowDialog("Please enter a Place ID.");
				return;
			}

			if (string.IsNullOrWhiteSpace(_selectedFilePath))
			{
				CustomMessageBox.ShowDialog("Please select an input file.");
				return;
			}

			_botProcessModel.BotProcessInfos.Clear();

			CustomMessageBox.ShowDialog($"Started botting for Place ID {placeId} in {(isHidden ? "Hidden" : "Tiny Window")} mode.");
		}

		private void Page_Unloaded(object sender, RoutedEventArgs e) => _cts.Cancel();
	}

	public sealed class BotProcessInfoViewModel
	{
		public ObservableCollection<BotProcessInfo> BotProcessInfos { get; } = [];
	}

	public class BotProcessInfo(Page page)
	{
		public required string Username
		{
			get;
			set { field = value; AppInvoke(page.UpdateLayout); }
		}

		public required int UserId
		{
			get;
			set { field = value; AppInvoke(page.UpdateLayout); }
		}

		public required int ProcessId
		{
			get;
			set { field = value; AppInvoke(page.UpdateLayout); }
		}

		public required TimeSpan ActiveTime
		{
			get;
			set { field = value; AppInvoke(page.UpdateLayout); }
		}
	}
}
