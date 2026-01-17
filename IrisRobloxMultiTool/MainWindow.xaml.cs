using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IrisRobloxMultiTool.Classes;
using IrisRobloxMultiTool.Windows;
using Wpf.Ui.Controls;

namespace IrisRobloxMultiTool
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            new SignIn().ShowDialog();
            InitializeComponent();
        }

        private static BitmapImage GetBitmapFromUrl(string url)
        {
            BitmapImage bitmap = new();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.Absolute);
            bitmap.EndInit();

            return bitmap;
        }

        private async Task CheckForUpdates()
        {
            BaseClient.DefaultRequestHeaders.Clear();
            BaseClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            BaseClient.DefaultRequestHeaders.Add("User-Agent", "request");

			HttpResponseMessage response = await BaseClient.GetAsync("https://api.github.com/repos/RiisDev/IrisRobloxMultiTool/releases/latest");
            if (!response.IsSuccessStatusCode) return;
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonDocument json = JsonDocument.Parse(responseBody);
            JsonElement root = json.RootElement;
            string latestVersion = root.GetProperty("tag_name").GetString() ?? "";

            if (CurrentVersion.StartsWith(latestVersion)) return;

            UpdateAvailable = true;

            await AppInvokeAsync(() => AboutTab.Content += " | Update Available");

            MessageBoxResult result = CustomMessageBox.ShowDialog("There is an update, would you like to download now?", "IRMT", MessageBoxButton.YesNo);

			if (result == MessageBoxResult.Yes)
                Process.Start("explorer.exe", "https://github.com/RiisDev/IrisRobloxMultiTool/releases");
		}


        private readonly List<string> _nonCookieTabs = ["Home", "API Checker", "About"];

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _ = Task.Run(async () => await CheckForUpdates());

            if (Roblox.SkippedSignIn)
            {
                List<NavigationItem> itemsToRemove = RootNavigation.Items
                    .OfType<NavigationItem>()
                    .Where(item => !_nonCookieTabs.Contains(item.Content.ToString() ?? ""))
                    .ToList();

                foreach (NavigationItem item in itemsToRemove)
                {
                    item.IsEnabled = false;
                    item.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
            }
            else
            {
	            _ = Task.Run(async () =>
	            {
		            await AppInvokeAsync(() =>
		            {
			            UserPfp.ImageSource = !Roblox.Account.ProfilePicture.IsNullOrEmpty()
				            ? GetBitmapFromUrl(Roblox.Account.ProfilePicture)
				            : UserPfp.ImageSource;
		            });
	            });
            }

            PlayerName.Content = Roblox.Account.Name;
            RobuxCount.Content = Roblox.Account.RobuxCount;
            VerifiedIcon.Visibility = Roblox.Account.IsVerified ? Visibility.Visible : Visibility.Hidden;
        }

		private void UiWindow_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			RootFrame.Height = e.NewSize.Height - 60;
		}
    }
}
