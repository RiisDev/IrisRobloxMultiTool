using IrisRobloxMultiTool.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Windows;

namespace IrisRobloxMultiTool.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class RobloxGameBot
	{
		private readonly BotProcessInfoViewModel _botProcessModel;

		[StructLayout(LayoutKind.Sequential)]
		public struct Rect { public int Left; public int Top; public int Right; public int Bottom; public int Width => Right - Left; public int Height => Bottom - Top; }
		public enum SetWindowPosFlags : uint { NoSendChanging = 0x0400 }

	    [DllImport("user32.dll", SetLastError = true)]
		static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("user32.dll")]
		private static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
		
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

		private static async Task<(string, string)> GetAccountInfo(string cookie)
		{
			using HttpRequestMessage request = new (HttpMethod.Get, "https://www.roblox.com/my/settings/json");
			request.Headers.TryAddWithoutValidation("Cookie", $".ROBLOSECURITY={cookie}");
			request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:147.0) Gecko/20100101 Firefox/147.0");
			using HttpResponseMessage response = await Client.SendAsync(request);
			string responseBody = await response.Content.ReadAsStringAsync();
			using JsonDocument document = JsonDocument.Parse(responseBody);

			string? username = document.RootElement.GetProperty("DisplayName").GetString()?.Trim();
			string userId = document.RootElement.GetProperty("UserId").GetRawText().Trim();

			return (username ?? "Unknown", userId);
		}

	    private static async Task<string> GetCsrfToken(string cookie)
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

	    private static async Task<string> GetAssertionToken(string cookie)
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

		private static string GetLaunchCode(long placeId, string authCode)
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
			try
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

				_ = Task.Run(async () =>
				{
					await AppInvokeAsync(async () =>
					{
						while (!robloxProcess?.HasExited ?? false)
						{
							if (HiddenClientToggle.IsChecked ?? false) ShowWindow(robloxProcess.MainWindowHandle, 0);
							else if (GetWindowRect(robloxProcess.MainWindowHandle, out Rect rectangle))
								if (rectangle is { Height: > 5, Width: > 5 })
									SetWindowPos(robloxProcess.MainWindowHandle, IntPtr.Zero, 0, 0, 1, 1,
										SetWindowPosFlags.NoSendChanging);

							robloxProcess.PriorityClass = ProcessPriorityClass.Idle;
							robloxProcess.ProcessorAffinity = new IntPtr(1);

							await Task.Delay(150);
						}
					});
				});

				return robloxProcess;
			}
			catch (Exception ex)
			{
				CustomMessageBox.ShowDialog(ex.Message);
				Log(ex);

				return null;
			}
		}

		private readonly CancellationTokenSource _cts = new ();
		
		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			if (Process.GetProcessesByName("RobloxPlayerBeta").Length > 0) 
			{ CustomMessageBox.ShowDialog("Roblox is currently running, please close all clients and then reload application page."); return; }

			try { _ = new Mutex(true, "ROBLOX_singletonMutex"); } catch {/**/}

			_botProcessModel.BotProcessInfos.Clear();
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

			CustomMessageBox.ShowDialog($"Selected cookie file: {Path.GetFileName(_selectedFilePath)}");
		}

		private void ClearBotFile_Click(object sender, RoutedEventArgs e)
		{
			_selectedFilePath = string.Empty;
			CustomMessageBox.ShowDialog("Input file cleared.");
		}


		private void StartBot_Click(object sender, RoutedEventArgs e)
		{
			string placeId = PlaceIdBox.Text;

			if (string.IsNullOrWhiteSpace(placeId)) { CustomMessageBox.ShowDialog("Please enter a Place ID."); return; }

			if (string.IsNullOrWhiteSpace(_selectedFilePath)) { CustomMessageBox.ShowDialog("Please select an input file."); return; }

			_botProcessModel.BotProcessInfos.Clear();

			string[] lines = File.ReadAllLines(_selectedFilePath);

			foreach (string line in lines)
			{
				string cookie = line.Trim();
				if (string.IsNullOrWhiteSpace(cookie)) continue;

				_ = Task.Run(() =>
				{
					AppInvoke(async () =>
					{
						(string username, string userId) = await GetAccountInfo(cookie);

						RestartCookie:
						Process? botProcess = await LaunchRobloxGame(long.Parse(placeId), cookie);

						if (botProcess is null) return;
						
						BotProcessInfo botInfo = new()
						{
							Username = username,
							UserId = long.Parse(userId),
							ProcessId = botProcess.Id,
							ActiveTime = TimeSpan.Zero
						};

						_botProcessModel.BotProcessInfos.Add(botInfo);

						// ReSharper disable once AccessToModifiedClosure
						botProcess.Exited += (_, _) => _botProcessModel.BotProcessInfos.Remove(botInfo);

						while (!_cts.IsCancellationRequested && !botProcess.HasExited)
						{
							botInfo.ActiveTime += TimeSpan.FromSeconds(1);

							if (KillAt15.IsChecked is not null && KillAt15.IsChecked.Value && botInfo.ActiveTime >= TimeSpan.FromMinutes(15))
								botProcess.Kill(true);

							if (KillAt15.IsChecked is not null && KillAt15.IsChecked.Value && botInfo.ActiveTime >= TimeSpan.FromMinutes(15))
							{
								botProcess.Kill(true);
								goto RestartCookie;
							}

							await Task.Delay(1000);
						}
					});
				});
			}

		}

		private void Page_Unloaded(object sender, RoutedEventArgs e) => _cts.Cancel();
	}

	public sealed class BotProcessInfoViewModel
	{
		public ObservableCollection<BotProcessInfo> BotProcessInfos { get; } = [];
	}

	public sealed class BotProcessInfo : INotifyPropertyChanged
	{
		public required string Username { get; set; }

		public required long UserId { get; set; }

		public required int ProcessId { get; set; }

		public required TimeSpan ActiveTime
		{
			get;
			set
			{
				if (field == value) return;

				field = value;
				OnPropertyChanged(nameof(ActiveTime));
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
