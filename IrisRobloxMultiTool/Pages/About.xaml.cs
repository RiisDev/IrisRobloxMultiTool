using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace IrisRobloxMultiTool.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class About
    {
        private readonly WebClient _client = new();
        private bool _discordclicked;
        private bool _updateclicked;

        public About() => InitializeComponent();
        private void Canvas_MouseLeave(object sender, MouseEventArgs e) => Mouse.OverrideCursor = null;
        private static void SetContent(ContentControl label, string content) => label.Dispatcher.Invoke(() => label.Content = content);
        
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
            _discordclicked = true;
        }
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_discordclicked && Mouse.OverrideCursor == Cursors.Hand) Process.Start("https://discord.gg/7mJaZC5");
            _discordclicked = false;
            Mouse.OverrideCursor = null;
        }

        private string GetDiscordMemberCount()
        {
            //dynamic jsonReturn =
            //    JToken.Parse(_client.DownloadString(
            //        "https://discord.com/api/v9/invites/7mJaZC5?with_counts=true&with_expiration=true"));
            //return jsonReturn.approximate_presence_count ?? 0;
            return "0";
        }
        
        private void DoGithubChecks()
        {
            _client.Headers.Add(HttpRequestHeader.Accept, "application/vnd.github+json");
            _client.Headers.Add(HttpRequestHeader.UserAgent, "request");
            //JArray releasesData = JArray.Parse(_client.DownloadString("https://api.github.com/repos/IrisV3rm/IrisRobloxMultiTool/releases"));

            int downloads = 5;//releasesData.Sum(t => (int)t["assets"]?[0]?["download_count"]);

            SetContent(DownloadCount, downloads.ToString());
            //SetContent(ReleaseVersion, $"V{App.CurrentVersion.Substring(0, App.CurrentVersion.LastIndexOf(".", StringComparison.Ordinal))}");
            SetContent(OnlineCount, $"{GetDiscordMemberCount()} ONLINE");

            //if (App.UpdateAvailable)
            //{
            //    UpdateVersionLabel.Content = $@"Update Available: v{releasesData[0]["tag_name"]}";

            //    UpdateClickCanvas.MouseLeave += delegate { Mouse.OverrideCursor = null; };
            //    UpdateClickCanvas.MouseLeftButtonDown += delegate
            //    {
            //        Mouse.OverrideCursor = Cursors.Hand;
            //        _updateclicked = true;
            //    };
            //    UpdateClickCanvas.MouseLeftButtonUp += delegate
            //    {
            //        if (_updateclicked && Mouse.OverrideCursor == Cursors.Hand) App.DoUpdate();
            //        _updateclicked = false;
            //        Mouse.OverrideCursor = null;
            //    };
            //}
            //else
            //{
            //    VersionCanvas.Effect = null;
            //    UpdateAvailableLabel.Visibility = Visibility.Collapsed;
            //}

            Paragraph newParagraph = new();
            //newParagraph.Inlines.Add((string)releasesData[0]["body"] ?? string.Empty);
            RootTextBox.Dispatcher.Invoke(() => RootTextBox.Document.Blocks.Add(newParagraph));

            _client.Dispose();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) => DoGithubChecks();
    }
}
