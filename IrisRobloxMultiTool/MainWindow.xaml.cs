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

            if (App.CurrentVersion.StartsWith(latestVersion)) return;

            UpdateAvailable = true;

            AboutTab.Content += " | Update Available";

            //MessageBoxResult result = App.CustomMessageBox.ShowDialog("There is an update, would you like to download now?", "IRMT", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            //if (result == MessageBoxResult.Yes)
	           // Process.Start("https://github.com/RiisDev/IrisRobloxMultiTool/releases");
		}


        private readonly List<string> _nonCookieTabs = ["Home", "API Checker", "We Are Devs Keygen", "About"];

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await CheckForUpdates();

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
                await Task.Run(async () =>
                {
	                await UserPFP.Dispatcher.InvokeAsync(() =>
	                {
		                UserPFP.ImageSource = !Roblox.Account.ProfilePicture.IsNullOrEmpty() ? GetBitmapFromUrl(Roblox.Account.ProfilePicture) : UserPFP.ImageSource;
	                });
                });
            }

            PlayerName.Content = Roblox.Account.Name;
            RobuxCount.Content = Roblox.Account.RobuxCount;
            VerifiedIcon.Visibility = Roblox.Account.IsVerified ? Visibility.Visible : Visibility.Hidden;
        }

    }
}
