using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class APIChecker : Form
    {

        private static readonly HttpClient Client = new HttpClient();
        #region AssetDownloader
        public Tuple<string, Color> GetAssetDelivery()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                
                string Response = Client.GetStringAsync("https://assetdelivery.roblox.com/v1/asset?id=607785314").Result;
                if (Response.Contains("<Content name=\"ShirtTemplate\">"))
                    Data = Tuple.Create("Online", Color.Green);
                else if (Response.Length > 300)
                    Data = Tuple.Create("Online", Color.Green);
                
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, Color> GetCatalogSearch()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                
                string Response = Client.GetStringAsync("https://catalog.roblox.com/v1/search/items?Keyword=&category=3&limit=100&subcategory=ClassicShirts").Result;
                if (Response.Contains("\"data\":[{"))
                    Data = Tuple.Create("Online", Color.Green);
                
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, Color> GetMarketplace()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                string Response = Client.GetStringAsync("https://economy.roblox.com/v2/assets/607785314/details").Result;
                if (Response.Contains("{\"TargetId\":607785314,"))
                    Data = Tuple.Create("Online", Color.Green);                
            }
            catch (Exception)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, Color> GetAudioSearch()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create("https://search.roblox.com/catalog/contents?CatalogContext=2&Subcategory=16&Keyword=ree&SortAggregation=5&PageNumber=1&LegendExpanded=true&Category=9");
                httpRequest.Headers["Cookie"] = Program.RobloxAccountAPI.AccountData.Cookie;
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    if (streamReader.ReadToEnd().Contains("Creator Marketplace"))
                        Data = Tuple.Create("Online", Color.Green);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Data;
            }

            return Data;
        }

        public Tuple<string, Color> GetAssetDownloaderStatus()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            Tuple<string, Color> AssetDel = GetAssetDelivery();
            Tuple<string, Color> CatalogSearch = GetCatalogSearch();
            Tuple<string, Color> MarketPlace = GetMarketplace();
            Tuple<string, Color> Audio = GetAudioSearch();

            if (AssetDel.Item2 == Color.Red)
                return Data;
            if (CatalogSearch.Item2 == Color.Red)
                return Data;
            if (MarketPlace.Item2 == Color.Red)
                return Tuple.Create("Partial", Color.Orange);
            if (Audio.Item2 == Color.Red)
                return Tuple.Create("Partial", Color.Orange);

            Data = Tuple.Create("Fully functional!", Color.Green);

            return Data;
        }

        #endregion
        #region GroupScanner
        public Tuple<string, Color> GetGroupSearch()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                
                if (Client.GetStringAsync("https://groups.roblox.com/v1/groups/search?keyword=Yeet&prioritizeExactMatch=true&limit=100").Result.Contains("\"data\":[{"))
                    Data = Tuple.Create("Online", Color.Green);
                
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, Color> GetGroupMain()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                
                if (Client.GetStringAsync("https://groups.roblox.com/v1/groups/3580494").Result.Contains("{\"id\":3580494,\"name\":\"meme"))
                    Data = Tuple.Create("Online", Color.Green);
                
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, Color> GetGroupMembership()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                
                if (Client.GetStringAsync("https://groups.roblox.com/v1/groups/3580494/membership").Result.Contains("{\"groupId\":3580494,"))
                    Data = Tuple.Create("Online", Color.Green);
                
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, Color> GetGroupCurrency()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create("https://economy.roblox.com/v1/groups/3580494/currency");
                httpRequest.Headers["Cookie"] = Program.RobloxAccountAPI.AccountData.Cookie;
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    if (streamReader.ReadToEnd().Contains("{\"robux\""))
                        Data = Tuple.Create("Online", Color.Green);
            }
            catch (Exception)
            {
                return Data;
            }

            return Data;
        }
        public Tuple<string, Color> GetGroupThumbnail()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                
                if (Client.GetStringAsync("https://thumbnails.roblox.com/v1/groups/icons?groupIds=3580494&size=150x150&format=Png&isCircular=false").Result.Contains("{\"data\":[{\"targetId\":3580494,\"state\":\"Completed\",\"imageUrl\""))
                    Data = Tuple.Create("Online", Color.Green);
                
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }

        public Tuple<string, Color> GetGroupScannerStatus()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            Tuple<string, Color> GroupSearch = GetGroupSearch();
            Tuple<string, Color> GroupMain = GetGroupMain();
            Tuple<string, Color> GroupMembership = GetGroupMembership();
            Tuple<string, Color> GroupCurrency = GetGroupCurrency();
            Tuple<string, Color> GroupThumbnail = GetGroupThumbnail();

            if (GroupSearch.Item2 == Color.Red)
                return Data;
            if (GroupMain.Item2 == Color.Red)
                return Data;
            if (GroupMembership.Item2 == Color.Red)
                return Tuple.Create("Partial", Color.Orange);
            if (GroupCurrency.Item2 == Color.Red)
                return Tuple.Create("Partial", Color.Orange);
            if (GroupThumbnail.Item2 == Color.Red)
                return Tuple.Create("Partial", Color.Orange);

            Data = Tuple.Create("Fully functional!", Color.Green);

            return Data;
        }

        #endregion
        #region Misc
        public Tuple<string, Color> GetIRMTStatus()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                if (Client.GetStringAsync("https://irisapp.ca/IRMT/API/VerifiedPrograms.php").Result.Contains("[{\""))
                    Data = Tuple.Create("Online", Color.Green);
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }

        public Tuple<string, Color> GetLinkvertiseStatus()
        {
            Tuple<string, Color> Data = Tuple.Create("Blocked or Offline", Color.Red);

            try
            {
                JToken JsonData = JToken.Parse(Client.GetStringAsync("https://bypass.pm/bypass2?url=https://linkvertise.com/119085/ItemPhysics").Result);

                if (JsonData["success"] == null || JsonData["destination"] == null || JsonData["success"].ToString() == "false" || string.IsNullOrEmpty(JsonData["destination"].ToString())) return Data;

                Data = Tuple.Create("Online", Color.Green);
            }
            catch (AggregateException)
            {
                return Data;
            }

            return Data;
        }
        #endregion

        private void UpdateLabel(Label label, string Text, Color color)
        {
            label.Invoke(new Action(() =>
            {
                label.Text = Text;
                label.ForeColor = color;
            }));
        }
        
        public APIChecker()
        {
            InitializeComponent();
            
        }

        private void APIChecker_Load(object sender, EventArgs e)
        {
            Client.DefaultRequestHeaders.Add("Cookie", Program.RobloxAccountAPI.AccountData.Cookie);
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/111.0");
            AssetDeliveryStatus.Text = "Checking...";
            AssetDeliveryStatus.ForeColor = Color.FromArgb(66, 154, 249);
            CatalogSearchStatus.Text = "Checking...";
            CatalogSearchStatus.ForeColor = Color.FromArgb(66, 154, 249);
            MarketplaceStatus.Text = "Checking...";
            MarketplaceStatus.ForeColor = Color.FromArgb(66, 154, 249);
            AudioSearchStatus.Text = "Checking...";
            AudioSearchStatus.ForeColor = Color.FromArgb(66, 154, 249);
            GroupSearchStatus.Text = "Checking...";
            GroupSearchStatus.ForeColor = Color.FromArgb(66, 154, 249);
            GroupStatus.Text = "Checking...";
            GroupStatus.ForeColor = Color.FromArgb(66, 154, 249);
            GroupMemberStatus.Text = "Checking...";
            GroupMemberStatus.ForeColor = Color.FromArgb(66, 154, 249);
            GroupCurrencyStatus.Text = "Checking...";
            GroupCurrencyStatus.ForeColor = Color.FromArgb(66, 154, 249);
            ThumbnailStatus.Text = "Checking...";
            ThumbnailStatus.ForeColor = Color.FromArgb(66, 154, 249);
            LinkvertiseStatus.Text = "Checking...";
            LinkvertiseStatus.ForeColor = Color.FromArgb(66, 154, 249);
            IRMTStatus.Text = "Checking...";
            IRMTStatus.ForeColor = Color.FromArgb(66, 154, 249);


            new Task(() => { Tuple<string, Color> Linkvertise = GetLinkvertiseStatus(); UpdateLabel(LinkvertiseStatus, Linkvertise.Item1, Linkvertise.Item2); }).Start();
            new Task(() => { Tuple<string, Color> AssetDel = GetAssetDelivery(); UpdateLabel(AssetDeliveryStatus, AssetDel.Item1, AssetDel.Item2); }).Start();
            new Task(() => { Tuple<string, Color> CatalogSearch = GetCatalogSearch(); UpdateLabel(CatalogSearchStatus, CatalogSearch.Item1, CatalogSearch.Item2); }).Start();
            new Task(() => { Tuple<string, Color> MarketPlace = GetMarketplace(); UpdateLabel(MarketplaceStatus, MarketPlace.Item1, MarketPlace.Item2); }).Start();
            new Task(() => { Tuple<string, Color> Audio = GetAudioSearch(); UpdateLabel(AudioSearchStatus, Audio.Item1, Audio.Item2); }).Start();
            new Task(() => { Tuple<string, Color> GroupSearch = GetGroupSearch(); UpdateLabel(GroupSearchStatus, GroupSearch.Item1, GroupSearch.Item2); }).Start();
            new Task(() => { Tuple<string, Color> GroupMain = GetGroupMain(); UpdateLabel(GroupStatus, GroupMain.Item1, GroupMain.Item2); }).Start();
            new Task(() => { Tuple<string, Color> GroupMembership = GetGroupMembership(); UpdateLabel(GroupMemberStatus, GroupMembership.Item1, GroupMembership.Item2); }).Start();
            new Task(() => { Tuple<string, Color> GroupCurrency = GetGroupCurrency(); UpdateLabel(GroupCurrencyStatus, GroupCurrency.Item1, GroupCurrency.Item2); }).Start();
            new Task(() => { Tuple<string, Color> GroupThumbnail = GetGroupThumbnail(); UpdateLabel(ThumbnailStatus, GroupThumbnail.Item1, GroupThumbnail.Item2); }).Start();
            new Task(() => { Tuple<string, Color> IRMT = GetIRMTStatus(); UpdateLabel(IRMTStatus, IRMT.Item1, IRMT.Item2); }).Start();
        }

        private void StartDownload_Click(object sender, EventArgs e)
        {
            APIChecker_Load(null, null);
        }
    }
}
