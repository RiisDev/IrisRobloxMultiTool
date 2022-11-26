using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoginPage.EnsureCoreWebView2Async(CoreWebView2Environment.CreateAsync(null, $"{AppDomain.CurrentDomain.BaseDirectory}\\bin\\WebViewCache", null).Result);
        }

        private  void LoginPage_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            LoginPage.Source = new Uri("https://roblox.com/Login", UriKind.Absolute);
            LoginPage.CoreWebView2.Settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36";
            LoginPage.CoreWebView2.AddWebResourceRequestedFilter("https://roblox.com/*", CoreWebView2WebResourceContext.All);
            LoginPage.CoreWebView2.AddWebResourceRequestedFilter("http://roblox.com/*", CoreWebView2WebResourceContext.All);

            LoginPage.CoreWebView2.WebResourceResponseReceived += (s, ef) =>
            {
                if (ef.Request.Headers.Contains("Cookie"))
                {
                    if (ef.Request.Headers.GetHeader("Cookie").Contains(".ROBLOSECURITY"))
                    {
                        string[] Cookies = ef.Request.Headers.GetHeader("Cookie").Split(new string[] { ";" }, StringSplitOptions.None);
                        foreach (string Cookie in Cookies)
                        {
                            if (Cookie.Contains(".ROBLOSECURITY"))
                            {
                                Program.RobloxAccountAPI.AccountData.Cookie = Cookie;
                                Program.RobloxAccountAPI.SetupAccount();
                                Close();
                                break;
                            }
                        }
                    }
                }
            };

        }

        private void LoginPage_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            LoginPage.CoreWebView2.ExecuteScriptAsync(@"document.body.classList.remove(""light-theme"");document.body.classList.add(""dark-theme"");"); // Credit Ic3
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Global.SafeShutdown();
        }
    }
}
