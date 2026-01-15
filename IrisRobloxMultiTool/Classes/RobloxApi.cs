
namespace IrisRobloxMultiTool.Classes
{
	public class Account
	{
		public string Cookie { get; set; } = string.Empty;
		public string Name { get; set; } = Environment.UserName;
		public string Id { get; set; } = string.Empty;
		public string ProfilePicture { get; set; } = string.Empty;
		public string ProfileUrl { get; set; } = string.Empty;
		public bool IsVerified { get; set; }
		public string RobuxCount { get; set; } = "-1";
		public string CsrfToken { get; set; } = string.Empty;
	}

	public class RobloxApi
    {
	    public bool SkippedSignIn { get; set; }
		public Account Account = new();

		public async Task<string> RefreshCsrfToken()
		{
			if (Account.Cookie.IsNullOrEmpty())
				throw new InvalidOperationException("Cookie not set in account data");

			if (SkippedSignIn)
				throw new InvalidOperationException("Cannot get new Csrf token without signin");

			RobloxContainer.Add(new Uri("https://auth.roblox.com"), new Cookie(".ROBLOSECURITY", Account.Cookie, "/", "auth.roblox.com"));
			RobloxContainer.Add(new Uri("https://roblox.com"), new Cookie(".ROBLOSECURITY", Account.Cookie, "/", "roblox.com"));

			using HttpRequestMessage request = new (HttpMethod.Post, "https://auth.roblox.com/v2/logout");
			using HttpResponseMessage response = await RobloxClient.SendAsync(request);

			bool foundHeader = response.Headers.TryGetValues("x-csrf-token", out IEnumerable<string>? headers);

			if (!foundHeader || headers is null)
				throw new InvalidOperationException("Failed to refresh CSRF token");

			Account.CsrfToken = headers.First();
			
			return Account.CsrfToken;
		}

		public async Task SetupAccountData()
		{
			if (Account.Cookie.IsNullOrEmpty())
				throw new InvalidOperationException("Cookie not set in account data");

			if (SkippedSignIn)
				throw new InvalidOperationException("Cannot setup account data without signin");

			RobloxContainer.Add(new Uri("https://auth.roblox.com"), new Cookie(".ROBLOSECURITY", Account.Cookie, "/", "auth.roblox.com"));
			RobloxContainer.Add(new Uri("https://roblox.com"), new Cookie(".ROBLOSECURITY", Account.Cookie, "/", "roblox.com"));
			
			HttpResponseMessage response = await RobloxClient.GetAsync("https://www.roblox.com/my/account/json");
			response.EnsureSuccessStatusCode();

			string content = await response.Content.ReadAsStringAsync();

			JsonDocument document = JsonDocument.Parse(content);
			JsonElement root = document.RootElement;

			Account.Name = root.GetProperty("DisplayName").GetString() ?? string.Empty;
			Account.Id = root.GetProperty("UserId").GetInt32().ToString();
			Account.IsVerified = root.GetProperty("IsEmailVerified").GetBoolean();
			Account.ProfileUrl = $"https://www.roblox.com/users/{Account.Id}/profile";

			response.Dispose();

			response = await RobloxClient.GetAsync($"https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds={Account.Id}&size=150x150&format=Png&isCircular=true");
			response.EnsureSuccessStatusCode();

			content = await response.Content.ReadAsStringAsync();
			document = JsonDocument.Parse(content);
			root = document.RootElement;

			Account.ProfilePicture = root.GetProperty("data")[0].GetProperty("imageUrl").GetString() ?? string.Empty;

			response.Dispose();

			response = await RobloxClient.GetAsync($"https://economy.roblox.com/v1/users/{Account.Id}/currency");
			response.EnsureSuccessStatusCode();

			content = await response.Content.ReadAsStringAsync();
			document = JsonDocument.Parse(content);
			root = document.RootElement;

			Account.RobuxCount = root.GetProperty("robux").GetInt32().ToString();

			await RefreshCsrfToken();
		}
	}
}
