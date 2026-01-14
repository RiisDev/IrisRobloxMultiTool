using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IrisRobloxMultiTool.Pages
{
    public partial class APIChecker : Page
    {
        private static readonly SolidColorBrush LimeBrush = new(Colors.Lime);
        private static readonly SolidColorBrush OrangeBrush = new(Colors.Orange);
        private static readonly SolidColorBrush RedBrush = new(Colors.Red);
        private static readonly SolidColorBrush BlueBrush = new(Color.FromRgb(66, 154, 249));
        private static readonly HttpClient Client = new();
        #region AssetDownloader
        public Tuple<string, SolidColorBrush> GetAssetDelivery()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {

                string Response = Client.GetStringAsync("https://assetdelivery.roblox.com/v1/asset?id=607785314").Result;
                if (Response.Contains("<Content name=\"ShirtTemplate\">"))
                    Data = Tuple.Create("Online", Brushes.Lime);
                else if (Response.Length > 300)
                    Data = Tuple.Create("Online", Brushes.Lime);

            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, SolidColorBrush> GetCatalogSearch()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {

                string Response = Client.GetStringAsync("https://catalog.roblox.com/v1/search/items?Keyword=&category=3&limit=100&subcategory=ClassicShirts").Result;
                if (Response.Contains("\"data\":[{"))
                    Data = Tuple.Create("Online", Brushes.Lime);

            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, SolidColorBrush> GetMarketplace()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {
                string Response = Client.GetStringAsync("https://economy.roblox.com/v2/assets/607785314/details").Result;
                if (Response.Contains("{\"TargetId\":607785314,"))
                    Data = Tuple.Create("Online", Brushes.Lime);
            }
            catch (Exception)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, SolidColorBrush> GetAudioSearch()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://search.roblox.com/catalog/contents?CatalogContext=2&Subcategory=16&Keyword=ree&SortAggregation=5&PageNumber=1&LegendExpanded=true&Category=9");
                //httpRequest.Headers["Cookie"] = App.RobloxAccountAPI.AccountData.Cookie;
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using StreamReader streamReader = new(httpResponse.GetResponseStream()!);
                if (streamReader.ReadToEnd().Contains("Creator Marketplace"))
                    Data = Tuple.Create("Online", Brushes.Lime);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Data;
            }

            return Data;
        }

        public Tuple<string, SolidColorBrush> GetAssetDownloaderStatus()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            Tuple<string, SolidColorBrush> AssetDel = GetAssetDelivery();
            Tuple<string, SolidColorBrush> CatalogSearch = GetCatalogSearch();
            Tuple<string, SolidColorBrush> MarketPlace = GetMarketplace();
            Tuple<string, SolidColorBrush> Audio = GetAudioSearch();

            if (AssetDel.Item2 == Brushes.Red)
                return Data;
            if (CatalogSearch.Item2 == Brushes.Red)
                return Data;
            if (MarketPlace.Item2 == Brushes.Red)
                return Tuple.Create("Partial", Brushes.Orange);
            if (Audio.Item2 == Brushes.Red)
                return Tuple.Create("Partial", Brushes.Orange);

            Data = Tuple.Create("Fully functional!", Brushes.Lime);

            return Data;
        }

        #endregion
        #region GroupScanner
        public Tuple<string, SolidColorBrush> GetGroupSearch()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {

                if (Client.GetStringAsync("https://groups.roblox.com/v1/groups/search?keyword=Yeet&prioritizeExactMatch=true&limit=100").Result.Contains("\"data\":[{"))
                    Data = Tuple.Create("Online", Brushes.Lime);

            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, SolidColorBrush> GetGroupMain()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {

                if (Client.GetStringAsync("https://groups.roblox.com/v1/groups/3580494").Result.Contains("{\"id\":3580494,\"name\":\"meme"))
                    Data = Tuple.Create("Online", Brushes.Lime);

            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, SolidColorBrush> GetGroupMembership()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {

                if (Client.GetStringAsync("https://groups.roblox.com/v1/groups/3580494/membership").Result.Contains("{\"groupId\":3580494,"))
                    Data = Tuple.Create("Online", Brushes.Lime);

            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, SolidColorBrush> GetGroupCurrency()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://economy.roblox.com/v1/groups/3580494/currency");
                //httpRequest.Headers["Cookie"] = App.RobloxAccountAPI.AccountData.Cookie;
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using StreamReader streamReader = new(httpResponse.GetResponseStream()!);
                if (streamReader.ReadToEnd().Contains("{\"robux\""))
                    Data = Tuple.Create("Online", Brushes.Lime);
            }
            catch (Exception)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, SolidColorBrush> GetGroupThumbnail()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {

                if (Client.GetStringAsync("https://thumbnails.roblox.com/v1/groups/icons?groupIds=3580494&size=150x150&format=Png&isCircular=false").Result.Contains("{\"data\":[{\"targetId\":3580494,\"state\":\"Completed\",\"imageUrl\""))
                    Data = Tuple.Create("Online", Brushes.Lime);

            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }

        public Tuple<string, SolidColorBrush> GetGroupScannerStatus()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            Tuple<string, SolidColorBrush> GroupSearch = GetGroupSearch();
            Tuple<string, SolidColorBrush> GroupMain = GetGroupMain();
            Tuple<string, SolidColorBrush> GroupMembership = GetGroupMembership();
            Tuple<string, SolidColorBrush> GroupCurrency = GetGroupCurrency();
            Tuple<string, SolidColorBrush> GroupThumbnail = GetGroupThumbnail();

            if (GroupSearch.Item2 == Brushes.Red)
                return Data;
            if (GroupMain.Item2 == Brushes.Red)
                return Data;
            if (GroupMembership.Item2 == Brushes.Red)
                return Tuple.Create("Partial", Brushes.Orange);
            if (GroupCurrency.Item2 == Brushes.Red)
                return Tuple.Create("Partial", Brushes.Orange);
            if (GroupThumbnail.Item2 == Brushes.Red)
                return Tuple.Create("Partial", Brushes.Orange);

            Data = Tuple.Create("Fully functional!", Brushes.Lime);

            return Data;
        }

        #endregion
        #region Misc
        public Tuple<string, SolidColorBrush> GetIRMTStatus()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {
                if (Client.GetStringAsync("https://irisapp.ca/IRMT/API/VerifiedPrograms.php").Result.Contains("[{\""))
                    Data = Tuple.Create("Online", Brushes.Lime);
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }

        public static Tuple<string, SolidColorBrush> GetLinkvertiseStatus()
        {
            Tuple<string, SolidColorBrush> Data = Tuple.Create("Blocked or Offline", Brushes.Red);

            try
            {
                //JToken JsonData = JToken.Parse(Client.GetStringAsync("https://bypass.pm/bypass2?url=https://linkvertise.com/119085/ItemPhysics").Result);

                //if (JsonData["success"] == null || JsonData["destination"] == null || JsonData["success"].ToString() == "false" || string.IsNullOrEmpty(JsonData["destination"].ToString())) return Data;

                Data = Tuple.Create("Online", Brushes.Lime);
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        #endregion


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

        public APIChecker()
        {
            InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<TextBlock, TextBlock> statusToControl = new()
            {
                { AssetDeliveryPing, AssetDeliveryOnlineStatus },
                { AudioAPIPing, AudioAPIOnlineStatus },
                { CatalogSearchPing, CatalogSearchAPI },
                { IRMTAPIPing, IRMTAPIStatus },
                { LinkvertiseAPIPing, LinkvertiseAPIStatus },
                { MarketplaceAPIPing, MarketplaceAPIStatus },
                { ThumbnailAPIPing, ThumbnailAPIStatus }
            };

            Dictionary<string, TextBlock> urlToLabel = new()
            {
                { "https://bypass.pm/bypass2?url=https://linkvertise.com/119085/ItemPhysics", LinkvertiseAPIPing },
                { "https://assetdelivery.roblox.com/v1/asset?id=607785314", AssetDeliveryPing },
                { "https://catalog.roblox.com/v1/search/items?Keyword=&category=3&limit=100&subcategory=ClassicShirts", CatalogSearchPing },
                { "https://economy.roblox.com/v2/assets/607785314/details", MarketplaceAPIPing },
                { "https://search.roblox.com/catalog/contents?CatalogContext=2&Subcategory=16&Keyword=ree&SortAggregation=5&PageNumber=1&LegendExpanded=true&Category=9", AudioAPIPing },
                { "https://thumbnails.roblox.com/v1/groups/icons?groupIds=3580494&size=150x150&format=Png&isCircular=false", ThumbnailAPIPing },
                { "https://irisapp.ca/IRMT/API/VerifiedPrograms.php", IRMTAPIPing }
            };

            foreach (KeyValuePair<TextBlock, TextBlock> kvp in statusToControl) SetControlToChecking(kvp.Key, kvp.Value);

            IEnumerable<Task> pingTasks = urlToLabel.Select(async kvp =>
            {
                string url = kvp.Key;
                TextBlock label = kvp.Value;
                PingReturn pingReturn = await GetServerPingAsync(url);
                UpdateLabel(label, $"{pingReturn.PingTime}ms", pingReturn.Brush);
            });

            new Task(() => { Tuple<string, SolidColorBrush> Linkvertise = GetLinkvertiseStatus(); UpdateLabel(LinkvertiseAPIStatus, Linkvertise.Item1, Linkvertise.Item2); }).Start();
            new Task(() => { Tuple<string, SolidColorBrush> AssetDel = GetAssetDelivery(); UpdateLabel(AssetDeliveryOnlineStatus, AssetDel.Item1, AssetDel.Item2); }).Start();
            new Task(() => { Tuple<string, SolidColorBrush> CatalogSearch = GetCatalogSearch(); UpdateLabel(CatalogSearchAPI, CatalogSearch.Item1, CatalogSearch.Item2); }).Start();
            new Task(() => { Tuple<string, SolidColorBrush> MarketPlace = GetMarketplace(); UpdateLabel(MarketplaceAPIStatus, MarketPlace.Item1, MarketPlace.Item2); }).Start();
            new Task(() => { Tuple<string, SolidColorBrush> Audio = GetAudioSearch(); UpdateLabel(AudioAPIOnlineStatus, Audio.Item1, Audio.Item2); }).Start();
            new Task(() => { Tuple<string, SolidColorBrush> GroupThumbnail = GetGroupThumbnail(); UpdateLabel(ThumbnailAPIStatus, GroupThumbnail.Item1, GroupThumbnail.Item2); }).Start();
            new Task(() => { Tuple<string, SolidColorBrush> IRMT = GetIRMTStatus(); UpdateLabel(IRMTAPIStatus, IRMT.Item1, IRMT.Item2); }).Start();

            await Task.WhenAll(pingTasks);
        }

        public static async Task<PingReturn> GetServerPingAsync(string url)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                using HttpResponseMessage response = await Client.GetAsync(url);
                stopwatch.Stop();

                return new PingReturn(stopwatch.ElapsedMilliseconds, PingToBrush(stopwatch.ElapsedMilliseconds));
            }
            catch (Exception)
            {
                return new PingReturn(-1, Brushes.Red);
            }
        }

        public static void SetControlToChecking(TextBlock pingLabel, TextBlock statusLabel)
        {
            pingLabel.Text = "Checking...";
            statusLabel.Text = "Checking...";
            statusLabel.Foreground = BlueBrush;
        }

        public static void UpdateLabel(TextBlock label, string text, SolidColorBrush foreground)
        {
            label.Dispatcher.Invoke(() =>
            {
                label.Text = text;
                label.Foreground = foreground;
            });
        }
    }

    public class PingReturn
    {
        public long PingTime { get; }
        public SolidColorBrush Brush { get; }

        public PingReturn(long pingTime, SolidColorBrush brush)
        {
            PingTime = pingTime;
            Brush = brush;
        }
    }
}
