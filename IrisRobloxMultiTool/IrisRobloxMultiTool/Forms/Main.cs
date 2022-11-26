using IrisRobloxMultiTool.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool
{
    public partial class Main : Form
    {
        public AssetDownloader assetDownloader;
        public Home home;
        public GroupScanner scanner;
        public ToolsDownloader toolsDownloader;
        public WeAreDevsKeygen KeyGen;
        public APIChecker istuff;
        public AssetFavouriteBot FavBot;
        public ProxyChecker ProxyStuff;

        private bool WebViewInstalled()
        {
            using (RegistryKey edgeKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate\Clients"))
                if (edgeKey != null)
                    return edgeKey.GetSubKeyNames().Any();

            return false;
        }

        private void CheckWebView()
        {
            if (!WebViewInstalled())
            {
                DialogResult Diag = MessageBox.Show("WebView2 is not installed, would you like to install it?", "IRMT", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (Diag != DialogResult.Yes)
                {
                    Program.Global.SafeShutdown();
                }
                else if (Diag == DialogResult.Yes)
                {
                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFileCompleted += (s, e) =>
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = $"{Program.Directory}\\temp\\WebViewInstall.exe";
                            process.StartInfo.Verb = "runas";
                            process.Start();
                        };
                        Client.DownloadFileAsync(new Uri("https://go.microsoft.com/fwlink/p/?LinkId=2124703"), $"{Program.Directory}\\temp\\WebViewInstall.exe");
                    }
                }
            }

            CoreWebView2Environment.SetLoaderDllFolderPath($"{AppDomain.CurrentDomain.BaseDirectory}\\bin\\dlls");

            assetDownloader = new AssetDownloader();
            home = new Home();
            scanner = new GroupScanner();
            toolsDownloader = new ToolsDownloader();
            KeyGen = new WeAreDevsKeygen();
            istuff = new APIChecker();
            FavBot = new AssetFavouriteBot();
            ProxyStuff = new ProxyChecker();
        }

        private void CheckForUpdates()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadStringCompleted += (Yes, no) =>
                {
                    string CurrentVersion = Application.ProductVersion;

                    JToken Token = JToken.Parse(no.Result);

                    if (Token["tag_name"] != null)
                    {
                        if (CurrentVersion.Substring(0, CurrentVersion.LastIndexOf(".")) != Token["tag_name"].ToString())
                        {
                            UpdAv.Visible = true;
                            DialogResult Diag = MessageBox.Show("There is an update, would you like to download now?", "IRMT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (Diag == DialogResult.Yes)
                            {
                                Process.Start("https://github.com/IrisV3rm/IrisRobloxMultiTool/releases");
                            }
                        }
                    }
                };
                client.Headers.Add(HttpRequestHeader.Accept, "application/vnd.github.v3+json");
                client.Headers.Add(HttpRequestHeader.UserAgent, "request");
                client.DownloadStringAsync(new Uri("https://api.github.com/repos/IrisV3rm/IrisRobloxMultiTool/releases/latest"));
            }
        }

        public Main()
        {
            InitializeComponent();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            #if DEBUG
                MessageBox.Show("This is a debug build, if you're seeing this please report it to Iris#0410!");
            #endif
            ButtonHolder.HorizontalScroll.Maximum = 0;
            ButtonHolder.HorizontalScroll.Visible = false;
            ButtonHolder.HorizontalScroll.Enabled = false;
            ButtonHolder.AutoScroll = true;

            CheckWebView();

            Login LoginForm = new Login();
            LoginForm.ShowDialog();
            LoginForm.Dispose();
            TopMost = true;
            await Task.Delay(25);
            TopMost = false;

            HomeButton.PerformClick();

            Program.RobloxAPI.Client.Headers.Add(HttpRequestHeader.Cookie, Program.RobloxAccountAPI.AccountData.Cookie);
            Program.RobloxAPI.Client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36");

            Username.Text = Program.RobloxAccountAPI.AccountData.Name;
            Username.LinkClicked += (s, er) => { Process.Start(Program.RobloxAccountAPI.AccountData.ProfileUrl); };
            RobuxText.Text = Program.RobloxAccountAPI.AccountData.RobuxCount;
            UserPFP.LoadAsync(Program.RobloxAccountAPI.AccountData.ProfilePicture);
            if (!Program.RobloxAccountAPI.AccountData.IsVerified)
            {
                Verified.Visible = false;
            }

            CheckForUpdates();
            IrisStuff.PerformClick();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/IrisV3rm/IrisRobloxMultiTool/releases");
        }

        private async void LogOutButton_Click(object sender, EventArgs e)
        {
            home.Dispose();
            await Task.Delay(25);
            Directory.Delete($"{Program.Directory}\\bin\\WebViewCache\\EBWebView", true);
            Program.Global.SafeShutdown();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Program.Global.SafeShutdown();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void SupportMe_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.twitch.tv/irisdev");
            Process.Start("https://www.youtube.com/channel/UC7eKTp0XmY1WwrLBndraSHA?sub_confirmation=1");
            Process.Start("https://paypal.me/IrisDev");
        }

        private void HideForms()
        {
            foreach (Form frm in FormHolder.Controls)
                frm.Hide();
        }

        private void ShowForm(Form ToggledForm)
        {
            HideForms();
            if (!FormHolder.Controls.Contains(ToggledForm))
            {
                ToggledForm.TopLevel = false;
                ToggledForm.AutoScroll = true;
                ToggledForm.Dock = DockStyle.Fill;
                FormHolder.Controls.Add(ToggledForm);
            }

            ToggledForm.Show();
        }

        private void AssetDownloaderButton_Click(object sender, EventArgs e)
        {
            if (assetDownloader == null)
            {
                assetDownloader = new AssetDownloader();
            }

            ShowForm(assetDownloader);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            if (home == null)
            {
                home = new Home();
            }

            ShowForm(home);
        }

        private void GroupScannerButton_Click(object sender, EventArgs e)
        {
            if (scanner == null)
            {
                scanner = new GroupScanner();
            }

            ShowForm(scanner);
        }

        private void ToolDownloader_Click(object sender, EventArgs e)
        {
            if (toolsDownloader == null)
            {
                toolsDownloader = new ToolsDownloader();
            }

            ShowForm(toolsDownloader);
        }

        private void WeAreDevsKeygenButton_Click(object sender, EventArgs e)
        {
            if (KeyGen == null)
            {
                KeyGen = new WeAreDevsKeygen();
            }

            ShowForm(KeyGen);
        }

        private void IrisStuff_Click(object sender, EventArgs e)
        {
            if (istuff == null)
            {
                istuff = new APIChecker();
            }

            ShowForm(istuff);
        }

        private void AssetFavouriteBot_Click(object sender, EventArgs e)
        {
            if (FavBot == null)
            {
                FavBot = new AssetFavouriteBot();
            }

            ShowForm(FavBot);
        }

        private void ProxyChecker_Click(object sender, EventArgs e)
        {
            if (ProxyStuff == null)
            {
                ProxyStuff = new ProxyChecker();
            }

            ShowForm(ProxyStuff);
        }
    }
}
