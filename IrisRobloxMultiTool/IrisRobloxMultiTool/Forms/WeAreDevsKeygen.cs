using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class WeAreDevsKeygen : Form
    {
        CoreWebView2HttpRequestHeaders Headers;
        CoreWebView2Deferral CurrentDefferal;
        CoreWebView2NewWindowRequestedEventArgs CurrentArgs;
        WebView2 CurrentBypasser;
        string CurrentUrl;
        private bool FluxusKeySystem = false;

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

        public WeAreDevsKeygen()
        {
            InitializeComponent();
            LinkVertiseBrowser.EnsureCoreWebView2Async();
        }

        public string btoa(string toEncode)
        {
            byte[] bytes = Encoding.GetEncoding(28591).GetBytes(toEncode);
            string toReturn = Convert.ToBase64String(bytes);
            return toReturn;
        }

        private void LinkVertiseBrowser_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            CurrentBypasser = LinkVertiseBrowser;

            CurrentBypasser.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            CurrentBypasser.CoreWebView2.Settings.AreDevToolsEnabled = false;
            CurrentBypasser.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = false;
            CurrentBypasser.CoreWebView2.Settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.74 Safari/537.36 Edg/99.0.1150.46";
            CurrentBypasser.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            CurrentBypasser.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            CurrentBypasser.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
        }

        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs er)
        {

            if (!FluxusKeySystem) { er.Handled = true; return; }

            CurrentDefferal = er.GetDeferral();
            CurrentArgs = er;

            WebView2 web2 = new WebView2();
            web2.Dock = DockStyle.Fill;
            web2.EnsureCoreWebView2Async();
            panel1.Controls.Add(web2);

            web2.CoreWebView2InitializationCompleted += (fuck, me) =>
            {
                web2.Show();
                web2.BringToFront();
                CurrentArgs.NewWindow = web2.CoreWebView2;
                CurrentDefferal.Complete();
                CurrentBypasser = web2;

                CurrentBypasser.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                CurrentBypasser.CoreWebView2.Settings.AreDevToolsEnabled = false;
                CurrentBypasser.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = false;
                CurrentBypasser.CoreWebView2.Settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.74 Safari/537.36 Edg/99.0.1150.46";
                CurrentBypasser.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
                CurrentBypasser.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
                CurrentBypasser.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            };
        }

        private string GetTargetUrl()
        {
            string Target = string.Empty;

            string LinkVertiseData = CurrentUrl.Substring(CurrentUrl.IndexOf(".com")+4);

            if (LinkVertiseData.Contains("?"))
                LinkVertiseData = LinkVertiseData.Substring(0, LinkVertiseData.LastIndexOf("?"));

            string Data = new WebClient().DownloadString($"https://publisher.linkvertise.com/api/v1/redirect/link/static{LinkVertiseData}");

            JToken JData = JToken.Parse(Data);

            if (JData["data"]["link"]["id"] != null)
            {
                Dictionary<string, string> JsonData = new Dictionary<string, string>()
                {
                    ["timestamp"] = (((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1))).TotalMilliseconds + .5).ToString(),
                    ["random"] = "6548307",
                    ["link_id"] = JData["data"]["link"]["id"].ToString(),
                };

                string Return = new WebClient().UploadString($"https://publisher.linkvertise.com/api/v1/redirect/link{LinkVertiseData}/target?serial={btoa(Newtonsoft.Json.JsonConvert.SerializeObject(JsonData))}", "");
                JData = JToken.Parse(Return);

                if (JData["data"]["target"] != null)
                {
                    Target = JData["data"]["target"].ToString();
                }
            }

            return Target;
        }

        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs er)
        {
            if (er.Uri.Contains("linkvertise"))
                panel1.Visible = false;

            er.RequestHeaders.SetHeader("sec-ch-ua", "\" Not A; Brand\";v=\"99\", \"Chromium\";v=\"99\", \"Microsoft Edge\";v=\"99\"");
            er.RequestHeaders.SetHeader("referer", CurrentUrl);

            Headers = er.RequestHeaders;

            CurrentUrl = er.Uri;
        }

        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            panel1.Visible = false;
            if (CurrentUrl == null) return;
            LogData(LogType.Info, CurrentUrl);

            if (CurrentUrl.Contains("linkvertise.download")) return;

            else if (CurrentUrl.Contains("linkvertise"))
            {
                if (SelectedExploit.Text.Contains("Kiwi")) await Task.Delay(2000);
                else if (SelectedExploit.Text.Contains("Oxygen")) await Task.Delay(6000);

                string Target = GetTargetUrl();

                if (Target != string.Empty)
                {
                    if (!FluxusKeySystem)
                        CurrentBypasser.CoreWebView2.Navigate(Target);
                    else
                        CurrentBypasser.CoreWebView2.ExecuteScriptAsync($"window.open('{Target}')");
                }
            }
            else if (CurrentUrl.ToLower().Contains("kiwi"))
            {
                DoKiwiBypasses(CurrentUrl);
            }
            else if (CurrentUrl.ToLower().Contains("flux"))
            {
                DoFluxusBypasses(CurrentUrl);
            }
            else if (CurrentUrl.ToLower().Contains("cometrbx"))
            {
                DoCometBypass(CurrentUrl);
            }
            else if (CurrentUrl.ToLower().Contains("oxygenu"))
            {
                DoOxygenBypass(CurrentUrl);
            }
        }

        private async void DoOxygenBypass(string Url)
        {
            panel1.Visible = false;
            Task<string> WebPage = CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");

            while (WebPage.Status != TaskStatus.RanToCompletion)
                await Task.Delay(5);

            if (WebPage.Result.Contains("hcaptcha.com/captcha/v1/") || WebPage.Result.Contains("recaptcha") || WebPage.Result.Contains("https://hCaptcha.com/1/api.js")) panel1.Visible = true;
            else if (WebPage.Result.Contains("It looks like you never used Oxygen before")) { MessageBox.Show("Please get a new starter url via Oxygen client!", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (WebPage.Result.Contains("Copy Key"))
            {
                string Keys = await CurrentBypasser.CoreWebView2.ExecuteScriptAsync("raw");

                Key.Text = Keys.Replace(" ", "").Replace("\"", "");
            }
        }

        private async void DoCometBypass(string Url)
        {
            panel1.Visible = false;
            Task<string> WebPage = CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");

            while (WebPage.Status != TaskStatus.RanToCompletion)
                await Task.Delay(5);

            if (CurrentUrl.Contains("start.php")) CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementsByTagName('iframe')[0].parentElement.remove()");
            if (WebPage.Result.Contains("hcaptcha.com/captcha/v1/") || WebPage.Result.Contains("recaptcha") || WebPage.Result.Contains("https://hCaptcha.com/1/api.js") && !(WebPage.Result.Contains("Click the button to copy your key!"))) panel1.Visible = true;

            else if (WebPage.Result.Contains("Click the button to copy your key!"))
            {
                Task<string> DotIt = CurrentBypasser.CoreWebView2.ExecuteScriptAsync("var Str = document.head.getElementsByTagName('script')[2].innerHTML; var Str2 = Str.substring(Str.indexOf('\"')); Str2.substring(0, Str2.indexOf(\";\"));");

                while (DotIt.Status != TaskStatus.RanToCompletion)
                    await Task.Delay(5);

                Key.Text = DotIt.Result.Replace("\"", "").Replace("\\", "").Replace("/", "");
                panel1.Visible = false;
            }
        }

        private async void DoFluxusBypasses(string Url)
        {
            panel1.Visible = false;

            string WebPage = await CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");

            if (CurrentUrl.Contains("Start.php")) CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementsByTagName('iframe')[0].remove();");
            if (WebPage.Contains("hcaptcha.com/captcha/v1/") || WebPage.Contains("recaptcha") || WebPage.Contains("https://hCaptcha.com/1/api.js")) panel1.Visible = true;
            else if (WebPage.Contains("Click to con"))
            {
                CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('input')[0].click();");

                await Task.Delay(100);

                string KeyReturn = await CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementById('txt1').textContent;");

                Key.Text = KeyReturn.Replace("Your Key: ", "");
            }
            else if (WebPage.Contains("copyToClipboard()"))
            {
                string P1 = WebPage.Substring(WebPage.IndexOf("var e") + 10);
                string P2 = P1.Substring(0, P1.IndexOf(";") - 2);
                Key.Text = P2;
            }
        }

        private async void DoKiwiBypasses(string Url)
        {
            panel1.Visible = false;
            string WebPage = await CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");


            if (WebPage.Contains("ad blocker"))
            {
                CurrentBypasser.CoreWebView2.ExecuteScriptAsync("$(\":contains('ad blocker')\").last().click()");
            }

            if (CurrentUrl.Contains("keystart"))
            {
                await Task.Delay(4000);
                CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();");

            }
            else if (CurrentUrl.ToLower().Contains("kiwiexploits.com/key") && !CurrentUrl.Contains("KeySystems"))
            {
                await Task.Delay(2000);
                CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();");
                await Task.Delay(500);
                CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();");
            }
            else if (CurrentUrl.Contains("https://kiwiexploits.com/KeySystems/index.php"))
            {

                if (WebPage.Contains("recaptcha"))
                {
                    await Task.Delay(100);

                    CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('card-body fixed-bottom text-center bg-secondary fs-5 text-white')[0].remove()");

                    panel1.Visible = true;
                }
                else if (WebPage.Contains("Your Key"))
                {
                    await Task.Delay(100);
                    Task<string> Yeet = CurrentBypasser.CoreWebView2.ExecuteScriptAsync("document.getElementById('key').innerText");

                    while (Yeet.Status != TaskStatus.RanToCompletion)
                        await Task.Delay(5);

                    Key.Text = Yeet.Result.Replace("\"", "");
                    LogData(LogType.Info, "Key has been grabbed!");
                    LogData(LogType.Info, "If you do not see the key above please retry!");
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            LogBox.Clear();
            LogData(LogType.System, "Running, please wait... (May take up to 30 seconds for some exploits)");

            switch(SelectedExploit.Text)
            {
                case "Kiwi X":
                    CurrentBypasser.CoreWebView2.Navigate("https://kiwiexploits.com/KeySystems/index.php?");
                    break;
                case "Fluxus":
                    CurrentBypasser.CoreWebView2.Navigate(StarterUrl.Text);
                    break;
                case "Oxygen U":
                    CurrentBypasser.CoreWebView2.Navigate(StarterUrl.Text);
                    break;
                case "Comet":
                    CurrentBypasser.CoreWebView2.Navigate(StarterUrl.Text);
                    break;
            }

        }

        private void WeAreDevsKeygen_Load(object sender, EventArgs e)
        {

        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.ScrollToCaret();
        }

        private void SelectedExploit_SelectedIndexChanged(object sender, EventArgs e)
        {
            FluxusKeySystem = false;
            switch (SelectedExploit.Text)
            {
                
                case "Fluxus":
                    MessageBox.Show("Please get a starter url via Fluxus client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FluxusKeySystem = true;
                    break;
                case "Oxygen U":
                    MessageBox.Show("Please get a starter url via Oxygen client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FluxusKeySystem = true;
                    break;
                case "Comet":
                    MessageBox.Show("Please get a starter url via Comet client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FluxusKeySystem = true;
                    break;
            }
        }
    }
}
