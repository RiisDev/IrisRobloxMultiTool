using IrisRobloxMultiTool.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
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
        AssetDownloader assetDownloader = new AssetDownloader();
        Home home = new Home();
        GroupScanner scanner = new GroupScanner();
        ToolsDownloader toolsDownloader = new ToolsDownloader();
        WeAreDevsKeygen KeyGen = new WeAreDevsKeygen();

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

        private void AssetDownloaderButton_Click(object sender, EventArgs e)
        {
            HideForms();
            if (assetDownloader == null)
            {
                assetDownloader = new AssetDownloader();
            }

            if (!FormHolder.Controls.Contains(assetDownloader))
            {
                assetDownloader.TopLevel = false;
                assetDownloader.AutoScroll = true;
                assetDownloader.Dock = DockStyle.Fill;
                FormHolder.Controls.Add(assetDownloader);
            }

            assetDownloader.Show();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            HideForms();

            if (home == null)
            {
                home = new Home();
            }

            if (!FormHolder.Controls.Contains(home))
            {
                home.TopLevel = false;
                home.AutoScroll = true;
                home.Dock = DockStyle.Fill;
                FormHolder.Controls.Add(home);
            }

            home.Show();
        }

        private void GroupScannerButton_Click(object sender, EventArgs e)
        {
            HideForms();

            if (scanner == null)
            {
                scanner = new GroupScanner();
            }

            if (!FormHolder.Controls.Contains(scanner))
            {
                scanner.TopLevel = false;
                scanner.AutoScroll = true;
                scanner.Dock = DockStyle.Fill;
                FormHolder.Controls.Add(scanner);
            }

            scanner.Show();
        }

        private void ToolDownloader_Click(object sender, EventArgs e)
        {
            HideForms();

            if (toolsDownloader == null)
            {
                toolsDownloader = new ToolsDownloader();
            }

            if (!FormHolder.Controls.Contains(scanner))
            {
                toolsDownloader.TopLevel = false;
                toolsDownloader.AutoScroll = true;
                toolsDownloader.Dock = DockStyle.Fill;
                FormHolder.Controls.Add(toolsDownloader);
            }

            scanner.Show();
        }

        private void WeAreDevsKeygenButton_Click(object sender, EventArgs e)
        {
            HideForms();

            if (KeyGen == null)
            {
                KeyGen = new WeAreDevsKeygen();
            }

            if (!FormHolder.Controls.Contains(scanner))
            {
                KeyGen.TopLevel = false;
                KeyGen.AutoScroll = true;
                KeyGen.Dock = DockStyle.Fill;
                FormHolder.Controls.Add(KeyGen);
            }

            scanner.Show();
        }
    }
}
