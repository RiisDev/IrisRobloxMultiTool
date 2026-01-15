using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IrisRobloxMultiTool.Pages
{
    public partial class ApiChecker
	{
		public ApiChecker() => InitializeComponent();

		private enum ApiType
	    {
            Roblox,
            Standard
	    }

        private static readonly SolidColorBrush LimeBrush = new(Colors.Lime);
        private static readonly SolidColorBrush OrangeBrush = new(Colors.Orange);
        private static readonly SolidColorBrush RedBrush = new(Colors.Red);
        private static readonly SolidColorBrush BlueBrush = new(Color.FromRgb(66, 154, 249));

		private record ServerData(TextBlock Ping, TextBlock Status);
		private record RobloxAssetCheck(string Url, string SuccessIndicator, ServerData TextObject, Func<string, bool>? ExtraCheck = null);
		private record GetStatus(string Status, SolidColorBrush Brush, int Ping);

		private async Task<GetStatus> GetApiStatusAsync(string url, string successIndicator, ApiType apiType = ApiType.Standard, Func<string, bool>? extraCheck = null)
        {
			try
			{
                TimeOnly startTime = TimeOnly.FromDateTime(DateTime.Now);

				string response = apiType switch
				{
					ApiType.Roblox => await RobloxClient.GetStringAsync(url),
					ApiType.Standard => await BaseClient.GetStringAsync(url),
					_ => throw new NotImplementedException()
				};

                TimeOnly endTime = TimeOnly.FromDateTime(DateTime.Now);

                int ping = (endTime.ToTimeSpan() - startTime.ToTimeSpan()).Milliseconds;

				bool baseCheck = response.Contains(successIndicator);
				bool extraCheckPassed = extraCheck?.Invoke(response) ?? true;

				if (baseCheck && extraCheckPassed)
				{
					return new GetStatus("Online", LimeBrush, ping);
				}

				return new GetStatus("Blocked or Offline", RedBrush, ping);
			}
			catch (Exception)
			{
				return new GetStatus("Blocked or Offline", RedBrush, -1);
			}
		}

        private static SolidColorBrush PingToBrush(long ping)
        {
            return ping switch
            {
                -1 => RedBrush,
                < 400 => LimeBrush,
                < 800 => OrangeBrush,
                _ => RedBrush
            };
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
	        List<RobloxAssetCheck> robloxApiChecks =
	        [
		        new (
			        "https://assetdelivery.roblox.com/v1/asset?id=607785314",
			        "<Content name=\"ShirtTemplate\">",
			        new ServerData(AssetDeliveryPing, AssetDeliveryOnlineStatus),
			        response => response.Length > 300
		        ),
		        new (
			        "https://catalog.roblox.com/v1/search/items?Keyword=&category=3&limit=100&subcategory=ClassicShirts", 
			        "\"data\":[{",
			        new ServerData(CatalogSearchPing, CatalogSearchApi)

				),
		        new (
			        "https://economy.roblox.com/v2/assets/607785314/details", 
			        "{\"TargetId\":607785314,",
			        new ServerData(MarketplaceApiPing, MarketplaceApiStatus)
			    ),
		        new (
			        "https://search.roblox.com/catalog/contents?CatalogContext=2&Subcategory=16&Keyword=ree&SortAggregation=5&PageNumber=1&LegendExpanded=true&Category=9",
			        "Creator Marketplace",
			        new ServerData(AudioApiPing, AudioApiOnlineStatus)
			    ),
                new (
					"https://thumbnails.roblox.com/v1/groups/icons?groupIds=3580494&size=150x150&format=Png&isCircular=false",
					"Completed",
                    new ServerData(ThumbnailApiPing, ThumbnailApiStatus)
	            )
	        ];

            foreach (RobloxAssetCheck check in robloxApiChecks)
            {
                SetControlToChecking(check.TextObject.Ping, check.TextObject.Status);
                _ = Task.Run(async () =>
                {
                    GetStatus status = await GetApiStatusAsync(check.Url, check.SuccessIndicator, ApiType.Roblox, check.ExtraCheck);
                    UpdateLabel(check.TextObject.Ping, $"{status.Ping}ms", PingToBrush(status.Ping));
                    UpdateLabel(check.TextObject.Status, status.Status, status.Brush);
                });
            }
	    }

        private static void SetControlToChecking(TextBlock pingLabel, TextBlock statusLabel)
        {
            pingLabel.Text = "Checking...";
            statusLabel.Text = "Checking...";
            statusLabel.Foreground = BlueBrush;
        }

        private static void UpdateLabel(TextBlock label, string text, SolidColorBrush foreground)
        {
            label.Dispatcher.Invoke(() =>
            {
                label.Text = text;
                label.Foreground = foreground;
            });
        }
    }

}
