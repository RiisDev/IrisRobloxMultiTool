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

        private bool LoggedIn()
        {
            return false;
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            FirstSetup();
            CheckWebView();

            Login LoginForm = new Login();
            LoginForm.ShowDialog();

            Username.Text = Program.RbxApi.AccountData.Name;
            Username.LinkClicked += (s, er) => { Process.Start(Program.RbxApi.AccountData.ProfileUrl); };
            RobuxText.Text = Program.RbxApi.AccountData.RobuxCount;
            UserPFP.LoadAsync(Program.RbxApi.AccountData.ProfilePicture);
            if (!Program.RbxApi.AccountData.IsVerified)
            {
                Verified.Visible = false;
            }
        }
    }
}
