using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
// ReSharper disable MemberHidesStaticFromOuterClass

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
		private record RobloxAssetCheck(string Url, string SuccessIndicator, ServerData TextObject, Func<string, bool>? ExtraCheck = null, HttpType? HttpType = HttpType.Get, dynamic? PostContent = null);
		private record GetStatus(string Status, SolidColorBrush Brush, int Ping);

		public enum HttpType
		{
			Get,
			Post
		}

		private async Task<GetStatus> GetApiStatusAsync(string url, string successIndicator, ApiType apiType = ApiType.Standard, Func<string, bool>? extraCheck = null, HttpType? httpType = HttpType.Get, dynamic? postContent = null)
        {
			try
			{
				RobloxClient.DefaultRequestHeaders.TryAddWithoutValidation("x-csrf-token", await Roblox.RefreshCsrfToken());

                TimeOnly startTime = TimeOnly.FromDateTime(DateTime.Now);
				
				using HttpRequestMessage request = new(httpType == HttpType.Get ? HttpMethod.Get : HttpMethod.Post, url);

				if (httpType == HttpType.Post && postContent != null) 
					request.Content = JsonContent.Create(postContent);

				HttpResponseMessage responseMessage = apiType switch
				{
					ApiType.Roblox => await RobloxClient.SendAsync(request),
					ApiType.Standard => await BaseClient.SendAsync(request),
					_ => throw new InvalidOperationException()
				};
				
				string response = await responseMessage.Content.ReadAsStringAsync();

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
			catch (Exception ex)
			{
				Log(ex);
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
					"https://thumbnails.roblox.com/v1/groups/icons?groupIds=3580494&size=150x150&format=Png&isCircular=false",
					"Completed",
                    new ServerData(ThumbnailApiPing, ThumbnailApiStatus)
	            ),
				new (
					"https://apis.roblox.com/toolbox-service/v1/marketplace/3?limit=100&pageNumber=0&sortDirection=Descending&audioTypes=0&uiSortIntent=10",
					"totalResults",
					new ServerData(AudioApiPing, AudioApiOnlineStatus)
				),
		        new (
					"https://apis.roblox.com/toolbox-service/v1/items/details?assetIds=94215407204609,7135127272",
			        "{\"data\":[{\"asset\":",
			        new ServerData(AssetDetailsPing, AssetDetailsStatus)
		        ),
				new (
					"https://assetdelivery.roblox.com/v1/assets/batch",
					"[{\"location\":",
					new ServerData(AudioDownloadPing, AudioDownloadStatus),
					null,
					HttpType.Post,
					new List<object>
					{
						new
						{
							RequestId = "94215407204609",
							AssetId = 94215407204609L
						}
					})
			];

            foreach (RobloxAssetCheck check in robloxApiChecks)
            {
                SetControlToChecking(check.TextObject.Ping, check.TextObject.Status);
                _ = Task.Run(async () =>
                {
                    GetStatus status = await GetApiStatusAsync(check.Url, check.SuccessIndicator, ApiType.Roblox, check.ExtraCheck, check.HttpType, check.PostContent);
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
			SetProperty(label, x=> x.Text, text);
			SetProperty(label, x=> x.Foreground, foreground);
        }
    }

}
