using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V105.WebAuthn;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class WeAreDevsKeygen : Form
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static readonly HttpClient Client = new HttpClient();


        Dictionary<BrowserType, string> DriverDownloads = new Dictionary<BrowserType, string>()
        {
            {BrowserType.Edge, "https://cdn.discordapp.com/attachments/1044070738233151488/1044070770558636132/msedgedriver.exe" },
        };

        Dictionary<BrowserType, string> DriverAdBlocks = new Dictionary<BrowserType, string>()
        {
            {BrowserType.Edge, "https://cdn.discordapp.com/attachments/1044070738233151488/1044815404582842429/extension_1_45_2_0.crx" },
        };

        BrowserType DetectedBrowser;
        IWebDriver Driver;

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

        public enum BrowserType
        {
            Edge
        }

        public WeAreDevsKeygen()
        {
            InitializeComponent();
        }

        private void DoVertiseRedirect()
        {
            ExecuteJavaScript($@"
let Button = document.createElement(""button""); 
Button.Id = ""SPOOFBUTTON""; 
Button.onclick = function() {{ window.open(""{GetLinkvertiseRedirect(Driver.Url)}"", '_blank').focus(); }}; 
document.body.prepend(Button); 
Button.click();
");
        }

        private async void DoFluxusKeySystem()
        {
            string Title = NavigateForTitle(StarterUrl.Text).Result;

            if (Title == "Fluxus | Start")
            {
                LogData(LogType.System, "Fluxus chosen, please solve the captcha!");

                ExecuteJavaScript("document.body.prepend(document.querySelector('#captcha'));document.body.children[1].remove();");

                Driver.Manage().Window.Size = new(500, 300);
                Driver.Manage().Window.Position = new(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);


                while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);
                Driver.Manage().Window.Position = new(-2000, -2000);

                LogData(LogType.System, "Captcha solved, running bypasses....");
                LogData(LogType.System, "Linkvertise 1/3 Started...");

                DoVertiseRedirect();

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);
                while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);

                LogData(LogType.System, "Linkvertise 1/3 Passed...");
                LogData(LogType.System, "Linkvertise 2/3 Started...");

                DoVertiseRedirect();

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);
                while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);

                DoVertiseRedirect();

                LogData(LogType.System, "Linkvertise 2/3 Passed...");
                LogData(LogType.System, "Linkvertise 3/3 Started...");

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);

                LogData(LogType.System, "Linkvertise 3/3 Passed...");

                await Task.Delay(250);
                Key.Text = ExecuteJavaScript("return document.getElementsByTagName(\"code\")[0].innerText");
                LogData(LogType.System, "Outputting key!");

            }
            else if (Title == "Oxygen u Key")
            {
                LogData(LogType.System, "Oxygen U chosen, please solve the captcha!");

                ExecuteJavaScript("document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"container\")[0].remove()");

                Driver.Manage().Window.Size = new(500, 300);
                Driver.Manage().Window.Position = new(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);

                while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);
                Driver.Manage().Window.Position = new(-2000, -2000);

                LogData(LogType.System, "Captcha solved, running bypasses....");
                LogData(LogType.System, "Linkvertise 1/2 Started...");

                await Task.Delay(7000);
                DoVertiseRedirect();

                LogData(LogType.System, "Linkvertise 1/2 Passed...");

                while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);
                LogData(LogType.System, "Linkvertise 2/2 Started...");

                await Task.Delay(7000);
                DoVertiseRedirect();
                LogData(LogType.System, "Linkvertise 2/2 Passed...");

                while (!GetUrl().Contains("https://oxygenu.xyz/KeySystem/Main.php")) await Task.Delay(50);

                Key.Text = ExecuteJavaScript("return raw");
                LogData(LogType.System, "Outputting key!");
            }
            else if (Title == "Oxygen U" && GetUrl() == "https://oxygenu.xyz/KeySystem/Main.php")
            {
                Key.Text = ExecuteJavaScript("return raw");
                LogData(LogType.System, "Outputting key!");
            }


            Driver.Quit();

            MessageBox.Show("You may now close all opened browser windows if still open!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private async void DoKiwiBypass()
        {
            string WebPage = NavigateForSource("https://kiwiexploits.com/KeySystems/index.php?").Result;

            if (WebPage.Contains("ad blocker"))
                ExecuteJavaScript("document.querySelector(\":contains('ad blocker')\").last().click()");


            LogData(LogType.System, "Captcha 1/3 Started...");
            while (!GetUrl().Contains("https://kiwiexploits.com/keystart")) await Task.Delay(50);

            await Task.Delay(4000);
            ExecuteJavaScript("document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();");

            LogData(LogType.System, "Captcha 1/3 Passed...");
            LogData(LogType.System, "Captcha 2/3 Started...");
            while (!GetUrl().Contains("https://kiwiexploits.com/Key1")) await Task.Delay(50);

            await Task.Delay(4000);
            ExecuteJavaScript("document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();");

            LogData(LogType.System, "Captcha 2/3 Passed...");
            LogData(LogType.System, "Linkvertise 1/2 Started...");
            while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);

            await Task.Delay(7000);
            DoVertiseRedirect();

            LogData(LogType.System, "Linkvertise 1/2 Passed...");

            LogData(LogType.System, "Captcha 3/3 Started...");
            while (!GetUrl().Contains("https://kiwiexploits.com/Key2")) await Task.Delay(50);

            await Task.Delay(4000);
            ExecuteJavaScript("document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();");

            LogData(LogType.System, "Captcha 3/3 Passed...");
            LogData(LogType.System, "Linkvertise 2/2 Started...");
            while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);

            await Task.Delay(7000);
            DoVertiseRedirect();

            LogData(LogType.System, "Linkvertise 2/2 Passed...");
            while (!GetUrl().Contains("https://kiwiexploits.com/KeySystems/index.php")) await Task.Delay(50);

            LogData(LogType.System, "Please solve captcha to continue!");
            Driver.Manage().Window.Position = new(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);

            while (!GetUrl().Contains("https://kiwiexploits.com/KeySystems/index.php?")) await Task.Delay(50);

            Driver.Manage().Window.Position = new(-2000, -2000);

            Key.Text = ExecuteJavaScript("return document.getElementById(\"key\").innerText");


            Driver.Quit();

            MessageBox.Show("You may now close all opened browser windows if still open!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private async void DoKrnlBypass()
        {
            Driver.Navigate().GoToUrl("https://cdn.krnl.place/getkey.php");

            LogData(LogType.System, "Krnl chosen, please solve the captcha! 1/4");

            while (!Driver.PageSource.Contains("Please Complete The Captcha")) await Task.Delay(50);

            ExecuteJavaScript("document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"form-group\")[0].style = \"\"");

            Driver.Manage().Window.Size = new(500, 300);
            Driver.Manage().Window.Position = new(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);


            while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);

            LogData(LogType.System, "Captcha 1/4 Passed...");
            LogData(LogType.System, "Linkvertise 1/4 Started (Please wait 20 seconds per linkvertise)...");
            Driver.Manage().Window.Position = new(-2000, -2000);

            await Task.Delay(20000);
            DoVertiseRedirect();


            while (!GetUrl().Contains("krnl.place")) await Task.Delay(50);


            LogData(LogType.System, "Linkvertise 1/4 Passed...");
            LogData(LogType.System, "Captcha 2/4 Started...");
            ExecuteJavaScript("document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"form-group\")[0].style = \"\"");

            Driver.Manage().Window.Size = new(500, 300);
            Driver.Manage().Window.Position = new(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);


            while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);
            LogData(LogType.System, "Linkvertise 2/4 Started (Please wait 20 seconds per linkvertise)...");

            Driver.Manage().Window.Position = new(-2000, -2000);

            await Task.Delay(20000);
            DoVertiseRedirect();

            while (!GetUrl().Contains("krnl.place")) await Task.Delay(50);

            LogData(LogType.System, "Linkvertise 2/4 Passed...");
            LogData(LogType.System, "Captcha 3/4 Started...");

            ExecuteJavaScript("document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"form-group\")[0].style = \"\"");

            Driver.Manage().Window.Size = new(500, 300);
            Driver.Manage().Window.Position = new(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);


            while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);
            LogData(LogType.System, "Linkvertise 3/4 Started (Please wait 20 seconds per linkvertise)...");

            Driver.Manage().Window.Position = new(-2000, -2000);

            await Task.Delay(20000);
            DoVertiseRedirect();

            while (!GetUrl().Contains("krnl.place")) await Task.Delay(50);

            LogData(LogType.System, "Linkvertise 3/4 Passed...");
            LogData(LogType.System, "Captcha 4/4 Started...");

            ExecuteJavaScript("document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"form-group\")[0].style = \"\"");

            Driver.Manage().Window.Size = new(500, 300);
            Driver.Manage().Window.Position = new(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);


            while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);
            LogData(LogType.System, "Linkvertise 4/4 Started (Please wait 20 seconds per linkvertise)...");

            Driver.Manage().Window.Position = new(-2000, -2000);

            await Task.Delay(20000);
            DoVertiseRedirect();

            LogData(LogType.System, "Linkvertise 4/4 Passed...");
            while (!GetUrl().Contains("krnl.place")) await Task.Delay(50);

            Key.Text = ExecuteJavaScript("return document.getElementsByTagName(\"input\")[0].value");

            LogData(LogType.System, "Krnl key has been generated...");

            Driver.Quit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            GenerateKey.Enabled = false;
            LogBox.Clear();
            LogData(LogType.System, "Running, please wait... (May take up to a minute for some exploits)");

            try
            {
                switch (SelectedExploit.Text)
                {
                    case "Kiwi X":
                        DoKiwiBypass();
                        break;
                    case "Krnl":
                        DoKrnlBypass();
                        break;
                    case "Fluxus":
                    case "Oxygen U":
                    case "":
                        DoFluxusKeySystem();
                        break;
                }
            } catch (WebDriverException ex)
            {
                if (ex.ToString().Contains("Reached error"))
                {
                    MessageBox.Show("Page URL Invalid", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Unknown error occured while bypassing, please restart the application!", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Driver.Quit();
                }
            }
        }

        private async void WeAreDevsKeygen_Load(object sender, EventArgs e)
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName == "geckodriver")
                    proc.Kill();
                else if (proc.ProcessName == "chromedriver")
                    proc.Kill();
                else if (proc.ProcessName == "msedgedriver")
                    proc.Kill();
            }

            new Task(() =>
            {
                APIChecker Checker = new APIChecker();

                Tuple<string, Color> Data = Checker.GetLinkvertiseStatus();

                Status.Invoke(new Action(() =>
                {
                    Status.Text = Data.Item1;
                    Status.ForeColor = Data.Item2;
                }));


                Checker.Dispose();

            }).Start();

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice"))
            {
                string ProgId = key.GetValue("ProgID").ToString();

                if (string.IsNullOrEmpty(ProgId))
                {
                    MessageBox.Show("Browser detection failed, defaulting to Microsoft Edge", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DetectedBrowser = BrowserType.Edge;
                }
                else if (ProgId.Contains("Firefox"))
                {
                    DetectedBrowser = BrowserType.Edge;
                }
                else if (ProgId.Contains("ChromeHtml"))
                {
                    DetectedBrowser = BrowserType.Edge;
                }
                else if (ProgId.Contains("MSEdge"))
                {
                    DetectedBrowser = BrowserType.Edge;
                }
                else
                {
                    DetectedBrowser = BrowserType.Edge;
                }
            }

            DetectedBrowser = BrowserType.Edge;

            bool Downloaded = false;
            bool Downloaded2 = false;
            DialogResult dialogResult = MessageBox.Show($"{DetectedBrowser} detected, download web driver (REQUIRED)?", "Iris Roblox MultiTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string DownloadUrl = DriverDownloads[DetectedBrowser];
                string FileName = DownloadUrl.Substring(DownloadUrl.LastIndexOf("/")+1);

                string AdblockDownUrl = DriverAdBlocks[DetectedBrowser];
                string AdBlockFileName = AdblockDownUrl.Substring(AdblockDownUrl.LastIndexOf("/")+1);   

                if (File.Exists($"{Program.Directory}\\bin\\drivers\\{FileName}"))
                {
                    Downloaded = true;
                }
                else
                {
                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFileCompleted += (_, __) =>
                        {
                            Downloaded = true;
                        };
                        Client.DownloadFileAsync(new Uri(DownloadUrl), $"{Program.Directory}\\bin\\drivers\\{FileName}");
                    }
                }

                if (File.Exists($"{Program.Directory}\\bin\\drivers\\{AdBlockFileName}"))
                {
                    Downloaded2 = true;
                }
                else
                {
                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFileCompleted += (_, __) =>
                        {
                            Downloaded2 = true;
                        };
                        Client.DownloadFileAsync(new Uri(AdblockDownUrl), $"{Program.Directory}\\bin\\drivers\\{AdBlockFileName}");
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Unable to continue with keygen, please reload.", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            do
            {
                await Task.Delay(50);
            } while (!(Downloaded && Downloaded2));

            MessageBox.Show("Download completed, you may proceed!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                EdgeOptions edgeOptions = new EdgeOptions();
                edgeOptions.AddArgument("--no-sandbox");
                edgeOptions.AddArgument("--disable-dev-shm-usage");
                edgeOptions.AddArgument("--enable-logging");
                edgeOptions.AddExtension($"{Program.Directory}\\bin\\drivers\\extension_1_45_2_0.crx");

                EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService($"{Program.Directory}\\bin\\drivers");
                edgeDriverService.HideCommandPromptWindow = true;
                Driver = new EdgeDriver(edgeDriverService, edgeOptions);

                Driver.Manage().Window.Position = new(-2000, -2000);
            }
            catch (WebDriverException ex)
            {
                if (ex.ToString().Contains("cannot find"))
                {
                    MessageBox.Show($"{DetectedBrowser} binary cannot be found! ", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Driver.Manage().Window.Position = new(-2000, -2000);
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

                case "Fluxus":
#if DEBUG
                        StarterUrl.Text = "https://flux.li/windows/start.php?HWID=fbba28a7604a11eda702806e6f6e6963a4872ad2dd325cabc47545d3159dea67";
#else
                        MessageBox.Show("Please get a starter url via Fluxus client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif

                    break;
                case "Oxygen U":
#if DEBUG
                        StarterUrl.Text = "https://oxygenu.xyz/KeySystem/Start.php?HWID=bd69a7d29bc011ec913f806e6f6e6963";
#endif
                    MessageBox.Show("Please get a starter url via Oxygen client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private string GetLinkvertiseRedirect(string url)
        {
            Dictionary<string, string> Vals = new Dictionary<string, string>
            {
                {"url", url},
            }; 
            JToken JsonData = JToken.Parse(Client.PostAsync("https://api.bypass.vip/", new FormUrlEncodedContent(Vals)).Result.Content.ReadAsStringAsync().Result);
            
            if (JsonData["success"].ToString() == "false" || JsonData["destination"] == null || string.IsNullOrEmpty(JsonData["destination"].ToString()))
            {
                MessageBox.Show($"Failed to bypass please submit an issue request on github!", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Driver.Quit();
                return string.Empty;
            }
            else
            {
                return JsonData["destination"].ToString();
            }
        }

        private Task<string> NavigateForTitle(string url)
        {
            Driver.Navigate().GoToUrl(url);
            new WebDriverWait(Driver, TimeSpan.FromMinutes(1.0)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            return Task.FromResult(Driver.Title);
        }

        private Task<string> NavigateForSource(string url)
        {
            Driver.Navigate().GoToUrl(url);
            new WebDriverWait(Driver, TimeSpan.FromMinutes(1.0)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            return Task.FromResult(Driver.PageSource);
        }

        private Task<string> NavigateForUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            new WebDriverWait(Driver, TimeSpan.FromMinutes(1.0)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            return Task.FromResult(Driver.Url);
        }

        private string ExecuteJavaScript(string script)
        {
            try
            {
                return (string)(Driver as IJavaScriptExecutor).ExecuteScript(script);
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("document.body is null"))
                    ExecuteJavaScript(script);
                else
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Unknown error occured while bypassing, please restart the application!", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Driver.Quit();
                }

                return "";
            }
        }

        private string GetUrl()
        {
            try
            {
                return Driver.SwitchTo().Window(Driver.WindowHandles.Last()).Url;
            }
            catch
            {
                return "";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Key.Text);
        }
    }
}
