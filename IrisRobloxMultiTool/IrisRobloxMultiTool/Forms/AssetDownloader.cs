using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class AssetDownloader : Form
    {
        public void LogData(LogType logType, string Message = "")
        {
            LogBox.Invoke(new Action(() =>
            {
                switch (logType)
                {
                    case LogType.System:
                        LogBox.BindText(Color.DimGray, "[SYSTEM] ");
                        LogBox.BindText(Color.White, $"{Message}\n");
                        break;
                    case LogType.Info:
                        LogBox.BindText(Color.DimGray, "[LOG] ");
                        LogBox.BindText(Color.FromArgb(85, 136, 238), $"{Message}\n");
                        break;
                    case LogType.Error:
                        LogBox.BindText(Color.DimGray, "[ERROR] ");
                        LogBox.BindText(Color.Red, $"{Message}\n");
                        break;
                    default:
                        break;
                }
            }));
            Console.WriteLine($"{logType} {Message}");
        }

        public enum LogType
        {
            System,
            Error,
            Info,
        }

        public enum ClothingType
        {
            Accessories,
            Audio,
            ClassicPants,
            ClassicShirts
        }

        private string ShirtsDir      = $"{Program.Directory}\\AssetDownloader\\ClassicShirts";
        private string PantsDir       = $"{Program.Directory}\\AssetDownloader\\ClassicPants";
        private string AudioDir       = $"{Program.Directory}\\AssetDownloader\\Audio";
        private string AccessoriesDir = $"{Program.Directory}\\AssetDownloader\\Accessories";
        private string TempDir        = $"{Program.Directory}\\AssetDownloader\\Temp";
        private string IDListDir      = string.Empty;

        private bool DownloadTemps, DownloadFull, Renamed = false;

        public List<string> ItemIDs = new List<string>();
        public Dictionary<string, string> SongData = new Dictionary<string, string>();

        public AssetDownloader()
        {
            InitializeComponent();
        }

        private void IncrementProgress()
        {
            ProgressBar.Invoke(new Action(() =>
            {
                ProgressBar.Value += 1;
            }));
        }

        private void SetBarMax(int Max)
        {
            ProgressBar.Invoke(new Action(() =>
            {
                ProgressBar.Maximum = Max;
            }));
        }

        private void ResetProgBar()
        {
            ProgressBar.Invoke(new Action(() =>
            {
                ProgressBar.Value = 0;
            }));
        }

        private string GetNextPageCursor(string CatalogURL)
        {
            string Cursor = string.Empty;

            using (WebClient client = new WebClient())
            {
                string JsonData = client.DownloadString(CatalogURL);

                JToken Data = JToken.Parse(JsonData);

                Cursor = Data["nextPageCursor"].ToString();
            }

            return Cursor;
        }

        private void GatherIDs(string CatalogURL)
        {
            using (WebClient client = new WebClient())
            {
                string JsonData = client.DownloadString(CatalogURL);

                JToken Data = JToken.Parse(JsonData);
                JArray IdData = JArray.Parse(Data["data"].ToString());

                for (int i = 0; i < IdData.Count; i++)
                {
                    Data = JToken.Parse(IdData[i].ToString());
                    ItemIDs.Add(Data["id"].ToString());
                }
            }
        }

        private string GetAssetName(string ID)
        {
            string Final = ID;

            try
            {
                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add(HttpRequestHeader.Cookie, Program.RbxApi.AccountData.Cookie);
                    Client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36");

                    string Json = Client.DownloadString($"https://api.roblox.com/marketplace/productinfo?assetId={ID}");

                    JToken Data = JToken.Parse(Json);

                    Final = Data["Name"].ToString();
                }
            }
            catch (Exception er) {
                Console.WriteLine(er.ToString());
            }

            return Final;
        }

        private void ScrapeAudioIds(string LibraryUrl)
        {
            bool DoneOne = false;
            string[] Audios = LibraryUrl.Split(new string[] { "item-image-wrapper" }, StringSplitOptions.None);

            foreach (string Audio in Audios)
            {
                if (!DoneOne)
                {
                    DoneOne = true;
                }
                else if (!Audio.Contains("MediaPlayerControls"))
                { }
                else
                {
                    string NewBlock = Audio.Substring(Audio.IndexOf("img title"), Audio.IndexOf("textDisplay"));
                    string SongTitleP1 = NewBlock.Substring(NewBlock.IndexOf("\"") + 1);
                    string SongTitle = SongTitleP1.Substring(0, SongTitleP1.IndexOf("\""));

                    string SongUrlP1 = NewBlock.Substring(NewBlock.IndexOf("-url=") + 6);
                    string SongUrl = SongUrlP1.Substring(0, SongUrlP1.IndexOf("\""));

                    if (SongData.ContainsKey(SongTitle))
                        SongTitle = SongTitle + RandomInt().ToString();
                    SongData.Add(SongTitle, SongUrl);
                }
            }
        }

        private string GetValidName(string filename)
        {
            string Final = string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

            if (Final.Contains(";"))
                Final = Final.Substring(Final.LastIndexOf(";") + 1);

            return Final;
        }

        private void ManualIDs()
        {
            if (IDListDir == null) return;
            if (CustomIdLocBox.Text == string.Empty) return;

            foreach (string Id in File.ReadAllLines(IDListDir))
            {
                long Out;
                if (long.TryParse(Id, out Out))
                {
                    ItemIDs.Add(Id);
                }
            }
        }

        private void GetIDs(ClothingType type)
        {
            string PageCur;
            string BaseUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=3&limit=100&subcategory={type}";
            string CatalogUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=3&limit=100&subcategory={type}";

            if (type == ClothingType.Accessories)
            {
                BaseUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=11&limit=100&subcategory={type}";
                CatalogUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=11&limit=100&subcategory={type}";
            }

            LogData(LogType.Info, $"Detected type as: {type}");
            LogData(LogType.Info, "Cathering Item IDs...");

            for (int i = 1; i <= (int.Parse(ItemCount.Text) / 100); i++)
            {
                if (i == 1)
                {
                    GatherIDs(CatalogUrl);
                }
                else
                {
                    PageCur = GetNextPageCursor(CatalogUrl);
                    LogData(LogType.Info, $"Going to next page: {PageCur}");
                    CatalogUrl = BaseUrl + $"&cursor={PageCur}";
                    LogData(LogType.Info, $"New catalog URL: {CatalogUrl}");
                    GatherIDs(CatalogUrl);
                }
            }
        }

        private void FirstSaveStep(ClothingType type)
        {
            new Thread( async () =>
            {
                for (; ; )
                {
                    await Task.Delay(25);
                    if (ProgressBar.Value == ProgressBar.Maximum)
                    {
                        DownloadTemps = true;
                        Thread.CurrentThread.Abort();
                        break;
                    }
                }
            }).Start();

            new Thread(() =>
            {
                foreach (string ID in ItemIDs.ToList())
                {
                    using (WebClient client = new WebClient())
                    {
                        if (type == ClothingType.Accessories)
                        {
                            client.DownloadFileCompleted += (s, e) =>
                            {
                                IncrementProgress();
                            };
                            try
                            {
                                client.DownloadFileAsync(new Uri($"https://assetdelivery.roblox.com/v1/asset?id={ID}"), $"{AccessoriesDir}\\{ID}.rbxm");
                            }
                            catch
                            {
                                IncrementProgress();
                            }
                        }
                        else
                        {
                            client.DownloadFileCompleted += (s, e) =>
                            {
                                IncrementProgress();
                            };

                            try
                            {
                                client.DownloadFileAsync(new Uri($"https://assetdelivery.roblox.com/v1/asset?id={ID}"), $"{TempDir}\\{ID}");
                            }
                            catch
                            {
                                IncrementProgress();
                            }
                        }
                    }
                }
            }).Start();
        }

        private void SecondSaveStep()
        {
            new Thread(async () =>
            {
                for (; ; )
                {
                    await Task.Delay(25);
                    if (ProgressBar.Value == ProgressBar.Maximum)
                    {
                        DownloadFull = true;
                        Thread.CurrentThread.Abort();
                        break;
                    }
                }
            }).Start();

            if (ItemTypeCombo.Text == "Accessories" || ItemTypeCombo.Text == "Audio")
            {
                ProgressBar.Invoke(new Action(() =>
                {
                    ProgressBar.Value = ProgressBar.Maximum;
                }));
                return;
            }

            ItemIDs.Clear();

            foreach (string AssetTemp in Directory.GetFiles(TempDir))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(AssetTemp))
                    {
                        try
                        {
                            string FileText = sr.ReadToEnd();
                            int pfrom = 0;

                            if (FileText.Contains("ShirtTemplate"))
                                pfrom = FileText.IndexOf("<Content name=\"ShirtTemplate\">") + "<Content name=\"ShirtTemplate\">".Length + 15;
                            else if (FileText.Contains("PantsTemplate"))
                                pfrom = FileText.IndexOf("<Content name=\"PantsTemplate\">") + "<Content name=\"ShirtTemplate\">".Length + 15;

                            int pto = FileText.IndexOf("</Content>") - 14;

                            string Parsed = FileText.Substring(pfrom, pto - pfrom).Replace("http://www.roblox.com/asset/?id=", "https://assetdelivery.roblox.com/v1/asset?id=");
                            ItemIDs.Add(Parsed);
                        }
                        catch
                        {
                            try
                            {
                                File.Delete(AssetTemp);
                            }
                            catch { }
                        }
                        IncrementProgress();
                    }
                }
                catch { IncrementProgress(); }
            }

            ItemIDs = ItemIDs.Distinct().ToList();
            SetBarMax(ItemIDs.Count());
            ResetProgBar();

            foreach (string AssetID in ItemIDs.ToList())
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += (s, e) =>
                    {
                        IncrementProgress();
                    };
                    try
                    {
                        wc.DownloadFileAsync(new Uri(AssetID), $"{Program.Directory}\\AssetDownloader\\{ItemTypeCombo.Text}\\{AssetID.Replace("https://assetdelivery.roblox.com/v1/asset?id=", "")}.png");
                    }
                    catch
                    {
                        IncrementProgress();
                    }
                }
            }

        }

        private long RandomInt()
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                return long.Parse(BitConverter.ToInt32(rno, 0).ToString());
            }
        }

        private async void ThirdSaveStep()
        {
            new Thread(async () =>
            {
                for (; ; )
                {
                    await Task.Delay(25);
                    if (ProgressBar.Value == ProgressBar.Maximum)
                    {
                        Renamed = true;
                        Thread.CurrentThread.Abort();
                        break;
                    }
                }
            }).Start();

            foreach (string Asset in Directory.GetFiles($"{Program.Directory}\\AssetDownloader\\{ItemTypeCombo.Text}"))
            {
                string AssetId = Asset.Substring(Asset.LastIndexOf('\\') + 1).Replace(".png", "").Replace(".rbxm", "");
                string Extension = ".png";
                string AssetName = GetAssetName(AssetId);

                if (ItemTypeCombo.Text == "Accessories")
                {
                    Extension = ".rbxm";
                }
                else if (ItemTypeCombo.Text == "Audio")
                {
                    Extension = ".mp3";
                }

                try
                {
                    File.Move(Asset, $"{Program.Directory}\\AssetDownloader\\{ItemTypeCombo.Text}\\{GetValidName(AssetName)}{Extension}");
                    IncrementProgress();
                }
                catch (IOException er)
                {
                    if (er.Message.Contains("already exists"))
                    {
                        File.Move(Asset, $"{Program.Directory}\\AssetDownloader\\{ItemTypeCombo.Text}\\{GetValidName(AssetName)}_{RandomInt()}{Extension}");
                        IncrementProgress();
                    }
                }
                await Task.Delay(25);
            }
        }

        private void FetchIDs()
        {
            switch (ItemTypeCombo.Text)
            {
                case "ClassicShirts":
                    GetIDs(ClothingType.ClassicShirts);
                    LogData(LogType.Info, $"Gathered a total of: {ItemIDs.Count} IDs");
                    break;
                case "ClassicPants":
                    GetIDs(ClothingType.ClassicPants);
                    LogData(LogType.Info, $"Gathered a total of: {ItemIDs.Count} IDs");
                    break;
                case "Audio":

                    for (int i = 1; i <= int.Parse(PageCountForAudio.Text); i++)
                    {
                        using (WebClient Client = new WebClient())
                        {
                            Client.Headers.Add(HttpRequestHeader.Cookie, Program.RbxApi.AccountData.Cookie);
                            Client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36");
                            string LibraryData = Client.DownloadString($"https://search.roblox.com/catalog/contents?CatalogContext=2&Subcategory=16&Keyword={KeywordBox.Text}&SortAggregation=5&PageNumber={i}&LegendExpanded=true&Category=9");

                            ScrapeAudioIds(LibraryData);
                        }
                    }
                    LogData(LogType.Info, $"Gathered a total of: {SongData.Count} IDs");
                    break;
                case "Accessories":
                    GetIDs(ClothingType.Accessories);
                    LogData(LogType.Info, $"Gathered a total of: {ItemIDs.Count} IDs");
                    break;
            }
        }

        private void AssetDownloader_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory($"{Program.Directory}\\AssetDownloader");
            Directory.CreateDirectory(ShirtsDir);
            Directory.CreateDirectory(PantsDir);
            Directory.CreateDirectory(AudioDir);
            Directory.CreateDirectory(AccessoriesDir);
            Directory.CreateDirectory(TempDir);
            PageCountForAudio.SelectedIndex = 0;
            ItemCount.SelectedIndex = 0;

            new Task(() =>
            {
                APIChecker Checker = new APIChecker();

                Tuple<string, Color> Data = Checker.GetAssetDownloaderStatus();

                Status.Invoke(new Action(() =>
                {
                    Status.Text = Data.Item1;
                    Status.ForeColor = Data.Item2;
                }));


                Checker.Dispose();

            }).Start();

        }

        private void FindLocation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Make sure they are seperated by line!", "IRMT - Asset Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (OpenFileDialog Diag = new OpenFileDialog())
            {
                Diag.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                Diag.CheckFileExists = true;
                Diag.CheckPathExists = true;

                if (Diag.ShowDialog() == DialogResult.OK)
                {
                    CustomIdLocBox.Text = Diag.FileName;
                }
            }
        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.ScrollToCaret();
        }

        private void ItemTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemTypeCombo.Text == "Audio")
            {
                PageCountForAudio.Visible = true;
                ItemCount.Visible = false;
                label5.Text = "Page Count";
            }
            else if (ItemTypeCombo.Text == "Accessories")
            {
                MessageBox.Show("These will all download as RBXM!", "Asset Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PageCountForAudio.Visible = false;
                ItemCount.Visible = true;
                label5.Text = "Item Count";
            }
        }

        private void DownloadTempAssets()
        {
            switch (ItemTypeCombo.Text)
            {
                case "ClassicShirts":
                    FirstSaveStep(ClothingType.ClassicShirts);
                    break;
                case "ClassicPants":
                    FirstSaveStep(ClothingType.ClassicPants);
                    break;
                case "Audio":
                    new Thread(async () =>
                    {
                        for (; ; )
                        {
                            await Task.Delay(25);
                            if (ProgressBar.Value == ProgressBar.Maximum)
                            {
                                Renamed = true;
                                DownloadFull = true;
                                DownloadTemps = true;
                                Thread.CurrentThread.Abort();
                                break;
                            }
                        }
                    }).Start();

                    foreach (string FName in SongData.Keys)
                    {
                        new Thread(() =>
                        {
                            using (WebClient client = new WebClient())
                            {
                                try
                                {
                                    string FileName = GetValidName(FName);

                                    client.DownloadFileCompleted += (s, e) =>
                                    {
                                        IncrementProgress();
                                    };

                                    client.DownloadFileAsync(new Uri(SongData[FName]), $"{AudioDir}\\{FileName}.mp3");
                                }
                                catch (Exception)
                                {
                                    IncrementProgress();
                                }
                            }
                        }).Start();
                    }
                    break;
                case "Accessories":
                    FirstSaveStep(ClothingType.Accessories);
                    break;
            }
        }

        private async void StartDownload_Click(object sender, EventArgs e)
        {
            DownloadFull = false;
            DownloadTemps = false;
            Renamed = false;
            ItemIDs.Clear();
            SongData.Clear();
            LogBox.Clear();
            ResetProgBar();

            Directory.Delete(TempDir, true);
            Directory.CreateDirectory(TempDir);

            LogData(LogType.Info, "Logging started!");

            if (!ManualIDCheck.Checked)
            {
                if (ItemTypeCombo.Text == "Audio")
                    LogData(LogType.System, $"Fetching {PageCountForAudio.Text} pages of audio!");
                else
                    LogData(LogType.System, $"Fetching {ItemCount.Text} IDs for assets: {ItemTypeCombo.Text}");

                FetchIDs();
            }

            LogData(LogType.System, "Gather specific IDs...");
            ManualIDs();
            LogData(LogType.System, $"Done fetching asset IDs!");
            ItemIDs = ItemIDs.Distinct().ToList();
            SetBarMax(ItemIDs.Count());
            LogData(LogType.System, $"Continuing to download in ~1 seconds!");
            await Task.Delay(2000);

            if (ItemTypeCombo.Text == "Audio")
            {
                LogData(LogType.Info, $"Starting phase 1/1...");
                SetBarMax(SongData.Count());
                DownloadTempAssets();
            }
            else
            {
                LogData(LogType.Info, $"Starting phase 1/3...");
                ResetProgBar();
                DownloadTempAssets();

                while (DownloadTemps != true)
                    await Task.Delay(25);

                LogData(LogType.Info, $"Starting phase 2/3...");
                ResetProgBar();
                await Task.Delay(5);
                SecondSaveStep();

                while (DownloadFull != true)
                    await Task.Delay(25);

                LogData(LogType.Info, $"Starting phase 3/3...");
                ResetProgBar();
                await Task.Delay(5);
                if (RealAssetName.Checked)
                {
                    ThirdSaveStep();
                }
                else
                {
                    LogData(LogType.System, $"Asset names will not be set!");
                    Renamed = true;
                }
            }
            new Thread( async () =>
            {
                for (; ; )
                {
                    await Task.Delay(25);
                    if (DownloadTemps && DownloadFull && Renamed)
                    {
                        LogData(LogType.System, "Detected all items finished, opening directoy!");
                        Process.Start($"{Program.Directory}\\AssetDownloader");
                        try
                        {
                            Directory.Delete(TempDir, true);
                            Directory.CreateDirectory(TempDir);
                        }
                        catch { }
                        break;
                    }
                }
            }).Start();
        }
    }
}
