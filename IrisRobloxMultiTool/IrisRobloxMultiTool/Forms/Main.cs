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
        public AssetDownloader assetDownloader = new AssetDownloader();
        public Home home = new Home();
        public GroupScanner scanner = new GroupScanner();
        public ToolsDownloader toolsDownloader = new ToolsDownloader();
        public WeAreDevsKeygen KeyGen = new WeAreDevsKeygen();
        public APIChecker istuff = new APIChecker();
        public AssetFavouriteBot FavBot = new AssetFavouriteBot();

        private bool WebViewInstalled()
        {
            string regKey = @"SOFTWARE\WOW6432Node\Microsoft\EdgeUpdate\Clients";
            using (RegistryKey edgeKey = Registry.LocalMachine.OpenSubKey(regKey))
            {
                if (edgeKey != null)
                {
                    string[] productKeys = edgeKey.GetSubKeyNames();
                    if (productKeys.Any())
                    {
                        return true;
                    }
                }
            }

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

            // Do Webview stuff
        }

        private void FirstSetup()
        {
            if (!Directory.Exists($"{Program.Directory}\\bin"))
            {
                Directory.CreateDirectory($"{Program.Directory}\\bin");
                Directory.CreateDirectory($"{Program.Directory}\\bin\\temp");
                Directory.CreateDirectory($"{Program.Directory}\\bin\\cache");
            }
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
            ButtonHolder.HorizontalScroll.Maximum = 0;
            ButtonHolder.HorizontalScroll.Visible = false;
            ButtonHolder.HorizontalScroll.Enabled = false;
            ButtonHolder.AutoScroll = true;

            FirstSetup();
            CheckWebView();

            Login LoginForm = new Login();
            LoginForm.ShowDialog();
            LoginForm.Dispose();
            TopMost = true;
            await Task.Delay(25);
            TopMost = false;

            HomeButton.PerformClick();

            Username.Text = Program.RbxApi.AccountData.Name;
            Username.LinkClicked += (s, er) => { Process.Start(Program.RbxApi.AccountData.ProfileUrl); };
            RobuxText.Text = Program.RbxApi.AccountData.RobuxCount;
            UserPFP.LoadAsync(Program.RbxApi.AccountData.ProfilePicture);
            if (!Program.RbxApi.AccountData.IsVerified)
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
            Directory.Delete($"{Program.Directory}\\IrisRobloxMultiTool.exe.WebView2", true);
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
    }
}
