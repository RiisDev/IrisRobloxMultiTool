using IrisRobloxMultiTool.Classes;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace IrisRobloxMultiTool.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class RobloxGameBot
	{
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

	    private async Task<string> GetAuthenticationTicket(string cookie, string assertionToken)
	    {
		    using HttpRequestMessage request = new(HttpMethod.Post, "https://auth.roblox.com/v1/authentication-ticket/");
		    request.Content = JsonContent.Create(new { clientAssertion = assertionToken });
		    using HttpResponseMessage authenticationTicketResponse = await Client.SendAsync(request);
		    return authenticationTicketResponse.Headers.GetValues("rbx-authentication-ticket").First();
		}

		public RobloxGameBot() => InitializeComponent();

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
			string trimmedValue = value.Trim('"');
			string robloxParsed = trimmedValue[..trimmedValue.IndexOf('"')];
			return robloxParsed;
        }

		private async Task<Process?> LaunchRobloxGame(long placeId, string cookie)
		{
			string assertionToken = await GetAssertionToken(cookie);
			string authTicket = await GetAuthenticationTicket(cookie, assertionToken);
			string robloxPath = GetRobloxLocation();
			
			Process robloxProcess = Process.Start(robloxPath, GetLaunchCode(placeId, authTicket));

			_ = Task.Run(async() =>
			{
				while (!robloxProcess.HasExited)
				{
					ShowWindow(robloxProcess.MainWindowHandle, 0);
					await Task.Delay(150);
				}
			});

			return Process.GetProcessesByName("RobloxPlayerBeta").First();
		}

		private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			try { _ = new Mutex(true, "ROBLOX_singletonMutex"); } catch {/**/}
		}
	}
}
