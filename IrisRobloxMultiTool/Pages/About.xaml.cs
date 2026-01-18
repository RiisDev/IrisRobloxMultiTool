using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace IrisRobloxMultiTool.Pages
{
    public partial class About
    {
        private bool _discordClicked;
        private bool _updateClicked;

        public About()
        {
	        InitializeComponent();
	        SetContent(ReleaseVersion, $"V{CurrentVersion[..CurrentVersion.LastIndexOf($".", StringComparison.Ordinal)]}");
		}

        private void Canvas_MouseLeave(object sender, MouseEventArgs e) => Mouse.OverrideCursor = null;
        
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            _discordClicked = true;
        }
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_discordClicked && Mouse.OverrideCursor == Cursors.Hand) Process.Start("explorer.exe", "https://discord.gg/7mJaZC5");
            _discordClicked = false;
            Mouse.OverrideCursor = null;
        }

        private async Task<string> GetDiscordMemberCount()
        {
            string json = await BaseClient.GetStringAsync("https://discord.com/api/v9/invites/yyuggrH?with_counts=true");
            JsonDocument document = JsonDocument.Parse(json);
            JsonElement root = document.RootElement;
            if (!root.TryGetProperty("approximate_presence_count", out JsonElement countElement)) return "0";

            int count = countElement.GetInt32();
            return count.ToString();
        }
        
        private async Task DoGithubChecks()
        {
	        try
	        {

		        BaseClient.DefaultRequestHeaders.Clear();
		        BaseClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
		        BaseClient.DefaultRequestHeaders.Add("User-Agent", "request");

		        string releasesJson = await BaseClient.GetStringAsync("https://api.github.com/repos/RiisDev/IrisRobloxMultiTool/releases");
		        using JsonDocument jsonDocument = JsonDocument.Parse(releasesJson);
		        JsonElement rootElement = jsonDocument.RootElement;

		        string releaseBody = rootElement[0].GetProperty("body").GetString() ?? "Failed to find release body.";
		        string releaseVersion = "v" + (rootElement[0].GetProperty("tag_name").GetString() ?? "0.0.0");

		        long downloadCount = 0;

		        if (rootElement.ValueKind == JsonValueKind.Array)
		        {
			        foreach (JsonElement element in rootElement.EnumerateArray())
			        {
				        if (!element.TryGetProperty("assets", out JsonElement assets)) continue;
				        if (assets.ValueKind != JsonValueKind.Array || assets.GetArrayLength() == 0) continue;

				        foreach (JsonElement asset in assets.EnumerateArray())
				        {
					        if (!asset.TryGetProperty("download_count", out JsonElement downloadCountElement)) continue;
					        if (downloadCountElement.ValueKind != JsonValueKind.Number) continue;
					        downloadCount += downloadCountElement.GetInt32();
				        }
			        }
		        }

		        SetContent(DownloadCount, downloadCount.ToString());

				if (UpdateAvailable)
				{
					SetContent(UpdateVersionLabel, $"Update Available: {releaseVersion}");

					UpdateAvailableCanvas.MouseLeave += delegate { Mouse.OverrideCursor = null; };
					UpdateAvailableCanvas.MouseLeftButtonDown += delegate
					{
						Mouse.OverrideCursor = Cursors.Hand;
						_updateClicked = true;
					};
					UpdateAvailableCanvas.MouseLeftButtonUp += delegate
					{
						if (_updateClicked && Mouse.OverrideCursor == Cursors.Hand)
							Process.Start("explorer.exe", "https://github.com/RiisDev/IrisRobloxMultiTool/releases/latest");

						_updateClicked = false;
						Mouse.OverrideCursor = null;
					};
				}
				else
				{
					UpdateAvailableCanvas.Effect = null;
					UpdateVersionLabel.Visibility = Visibility.Collapsed;
				}

				await AppInvokeAsync(() =>
				{
					RootTextBox.Document.Blocks.Clear();

					Paragraph newParagraph = new();
					newParagraph.Inlines.Add(releaseBody);
					RootTextBox.Document.Blocks.Add(newParagraph);
				});

	        }
	        catch (Exception ex)
	        {
				Log(ex);
	        }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
	        _ = Task.Run(async () => SetContent(OnlineCount, $"{await GetDiscordMemberCount()} ONLINE"));
	        _ = Task.Run(async () => await DoGithubChecks());
        }

		private void Border_SizeChanged(object sender, SizeChangedEventArgs e) => UpdateVersionLabel.Width = e.NewSize.Width - 50;
    }
}
