using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private bool DoneCaptcha = false;
        string CurrentUrl;
        public WeAreDevsKeygen()
        {
            InitializeComponent();
            LinkVertiseBrowser.EnsureCoreWebView2Async();
        }

        private void ProcessUrl(string Data)
        {
            Console.WriteLine(Data);
        }
        public string btoa(string toEncode)
        {
            byte[] bytes = Encoding.GetEncoding(28591).GetBytes(toEncode);
            string toReturn = System.Convert.ToBase64String(bytes);
            return toReturn;
        }
        private void LinkVertiseBrowser_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            LinkVertiseBrowser.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
           // LinkVertiseBrowser.CoreWebView2.Settings.AreDevToolsEnabled = false;
            LinkVertiseBrowser.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = true;
            LinkVertiseBrowser.CoreWebView2.Settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.74 Safari/537.36 Edg/99.0.1150.46";
            LinkVertiseBrowser.CoreWebView2.AddWebResourceRequestedFilter("kiwiexploits.com/*", Microsoft.Web.WebView2.Core.CoreWebView2WebResourceContext.All);

            LinkVertiseBrowser.CoreWebView2.NavigationStarting += (o, er) =>
            {
                if (er.Uri.Contains("linkvertise"))
                    panel1.Visible = false;

                er.RequestHeaders.SetHeader("sec-ch-ua", "\" Not A; Brand\";v=\"99\", \"Chromium\";v=\"99\", \"Microsoft Edge\";v=\"99\"");
                er.RequestHeaders.SetHeader("referer", CurrentUrl);

                Headers = er.RequestHeaders; 

                CurrentUrl = er.Uri;
            };

            LinkVertiseBrowser.CoreWebView2.NewWindowRequested += async (o, er) =>
            {
                await Task.Delay(2000);
                er.NewWindow = LinkVertiseBrowser.CoreWebView2;
            };


            LinkVertiseBrowser.CoreWebView2.NavigationCompleted += async (o, er) =>
            {
                
                if (CurrentUrl == null) return;
                LogData(LogType.Info, CurrentUrl);

                if (CurrentUrl.Contains("linkvertise.download"))
                {
                    Console.WriteLine("CantBypass");
                }
                else if (CurrentUrl.Contains("linkvertise"))
                {
                    panel1.Visible = false;

                    string Data = new WebClient().DownloadString($"https://vacant-curtly-composure.herokuapp.com/bypass2?url={CurrentUrl}");

                    JToken JData = JToken.Parse(Data);

                    //LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("$(\":contains('Direct Access with Premium')\").last().click()");

                    if (SelectedExploit.Text.Contains("Kiwi"))
                        await Task.Delay(2000);
                    else if (SelectedExploit.Text.Contains("Oxygen"))
                        await Task.Delay(5000);
                    else if (SelectedExploit.Text == "Fluxus")
                    {
                        panel1.Visible = true;

                        //Task<string> PathName = LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("location.pathname");

                        //while (PathName.Status != TaskStatus.RanToCompletion)
                        //    await Task.Delay(5);

                        //string LinkVertiseData = PathName.Result.Substring(1, PathName.Result.LastIndexOf("/") - 1);
                        //Data = new WebClient().DownloadString($"https://publisher.linkvertise.com/api/v1/redirect/link/static{LinkVertiseData}");

                        //JData = JToken.Parse(Data);

                        //if (JData["data"]["link"]["id"] != null)
                        //{
                        //    Dictionary<string, string> JsonData = new Dictionary<string, string>()
                        //    {
                        //        ["timestamp"] = (((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1))).TotalMilliseconds + .5).ToString(),
                        //        ["random"] = "6548307",
                        //        ["link_id"] = JData["data"]["link"]["id"].ToString(),
                        //    };

                        //    string Return = new WebClient().UploadString($"https://publisher.linkvertise.com/api/v1/redirect/link{LinkVertiseData}/target?serial={btoa(Newtonsoft.Json.JsonConvert.SerializeObject(JsonData))}", "");
                        //    JData = JToken.Parse(Return);

                        //    if (JData["data"]["target"] != null)
                        //    {
                        //        LinkVertiseBrowser.CoreWebView2.Navigate(JData["data"]["target"].ToString());
                        //    }
                        //}

                        return;

                    }


                    if (Convert.ToBoolean(JData["success"].ToString()))
                    {
                        LinkVertiseBrowser.CoreWebView2.Navigate(JData["destination"].ToString());
                    }
                    else
                    {
                        Console.WriteLine("CantBypass");
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
            };
        }

        private async void DoOxygenBypass(string Url)
        {
            panel1.Visible = false;
            Task<string> WebPage = LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");

            while (WebPage.Status != TaskStatus.RanToCompletion)
                await Task.Delay(5);

            
            if (WebPage.Result.Contains("hcaptcha.com/captcha/v1/") || WebPage.Result.Contains("recaptcha") || WebPage.Result.Contains("https://hCaptcha.com/1/api.js"))
            {
                Console.WriteLine("captcha");
                panel1.Visible = true;
            }
            else if (WebPage.Result.Contains("It looks like you never used Oxygen before"))
            {
                MessageBox.Show("Please get a new starter url via Oxygen client!", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (WebPage.Result.Contains("Oxygen U Key") && (!WebPage.Result.Contains("It looks like you never used Oxygen before, Please open it and press") || !WebPage.Result.Contains("rethink")))
            {
                string Data = new WebClient().DownloadString("https://oxygenu.xyz/KeySystem/Main.php");
                string Part1 = Data.Substring(Data.IndexOf("input") + 8);
                string Part2 = Part1.Substring(0, Part1.IndexOf("<") - 1);
                Key.Text = Part2;
                LogData(LogType.Info, "Key has been grabbed!");
                LogData(LogType.Info, "If you do not see the key above please retry!");
            }
        }

        private async void DoCometBypass(string Url)
        {
            panel1.Visible = true;
            Task<string> WebPage = LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");

            while (WebPage.Status != TaskStatus.RanToCompletion)
                await Task.Delay(5);

            if (CurrentUrl.Contains("start.php"))
            {
                LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.getElementsByTagName('iframe')[0].parentElement.remove()");
            }

            if (WebPage.Result.Contains("hcaptcha.com/captcha/v1/") || WebPage.Result.Contains("recaptcha") || WebPage.Result.Contains("https://hCaptcha.com/1/api.js"))
            {
                Console.WriteLine("captcha");
                panel1.Visible = true;
            }
        }

        private async void DoFluxusBypasses(string Url)
        {
            panel1.Visible = true;
            Task<string> WebPage = LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");

            while (WebPage.Status != TaskStatus.RanToCompletion)
                await Task.Delay(5);

            if (CurrentUrl.Contains("Start.php"))
            {
                LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.getElementsByTagName('iframe')[0].remove();");
            }
            
            if (WebPage.Result.Contains("hcaptcha.com/captcha/v1/") || WebPage.Result.Contains("recaptcha") || WebPage.Result.Contains("https://hCaptcha.com/1/api.js"))
            {
                panel1.Visible = true;
            }
        }

        private async void DoKiwiBypasses(string Url)
        {
            panel1.Visible = false;
            Task<string> WebPage = LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");

            while (WebPage.Status != TaskStatus.RanToCompletion)
                await Task.Delay(5);

            if (WebPage.Result.Contains("ad blocker"))
            {
                LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("$(\":contains('ad blocker')\").last().click()");
            }

            if (CurrentUrl.Contains("keystart"))
            {
                await Task.Delay(4000);
                LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();");

            }
            else if (CurrentUrl.ToLower().Contains("kiwiexploits.com/key") && !CurrentUrl.Contains("KeySystems"))
            {
                await Task.Delay(2000);
                LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();");

            }
            else if (CurrentUrl.Contains("https://kiwiexploits.com/KeySystems/index.php"))
            {

                while (WebPage.Status != TaskStatus.RanToCompletion)
                    await Task.Delay(5);

                if (WebPage.Result.Contains("recaptcha"))
                {
                    await Task.Delay(100);
                    
                    LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('card-body fixed-bottom text-center bg-secondary fs-5 text-white')[0].remove()");

                    panel1.Visible = true;
                }
                else if (WebPage.Result.Contains("Your Key"))
                {
                    await Task.Delay(100);
                    Task<string> Yeet = LinkVertiseBrowser.CoreWebView2.ExecuteScriptAsync("document.getElementById('key').innerText");

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
            LogBox.Clear();
            LogData(LogType.System, "Running, please wait... (May take up to 30 seconds for some exploits)");

            switch(SelectedExploit.Text)
            {
                case "Kiwi X":
                    LinkVertiseBrowser.CoreWebView2.Navigate("https://kiwiexploits.com/KeySystems/index.php?");
                    break;
                case "JJSploit":
                    break;
                case "Coco Z":
                    break;
                case "Fluxus":
                    LinkVertiseBrowser.CoreWebView2.Navigate(StarterUrl.Text);
                    break;
                case "Oxygen U":
                    LinkVertiseBrowser.CoreWebView2.Navigate(StarterUrl.Text);
                    break;
                case "Comet":
                    LinkVertiseBrowser.CoreWebView2.Navigate(StarterUrl.Text);
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
            switch (SelectedExploit.Text)
            {
                
                case "JJSploit":
                    break;
                case "Coco Z":
                    break;
                case "Fluxus":
                    //MessageBox.Show("Please get a starter url via Fluxus client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StarterUrl.Text = "https://fluxteam.xyz/ks/checkpoint/Start.php?HWID=bd69a7d29bc011ec913f806e6f6e6963a4872ad2dd325cabc47545d3159dea67";
                    break;
                case "Oxygen U":
                    MessageBox.Show("Please get a starter url via Oxygen client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "Comet":
                    MessageBox.Show("Please get a starter url via Comet client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
