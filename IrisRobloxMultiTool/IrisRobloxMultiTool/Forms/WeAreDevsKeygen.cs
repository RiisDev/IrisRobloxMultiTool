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
        int DriverProcId = 0;
        IntPtr DriverHandle = IntPtr.Zero;

        Dictionary<BrowserType, string> DriverDownloads = new Dictionary<BrowserType, string>()
        {
            {BrowserType.Firefox, "https://cdn.discordapp.com/attachments/1044070738233151488/1044070779513491506/geckodriver.exe" },
            {BrowserType.Edge, "https://cdn.discordapp.com/attachments/1044070738233151488/1044070770558636132/msedgedriver.exe" },
            {BrowserType.Chrome, "https://cdn.discordapp.com/attachments/1044070738233151488/1044070797565767740/chromedriver.exe" },
        };
        private bool FluxusKeySystem = false;
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
            Chrome,
            Firefox,
            Edge
        }

        public WeAreDevsKeygen()
        {
            InitializeComponent();
        }

        private List<Process> GetProcessSubProcesses()
        {
            List<Process> children = new List<Process>();
            ManagementObjectSearcher mos = new ManagementObjectSearcher(String.Format("Select * From Win32_Process Where ParentProcessID={0}", Process.GetCurrentProcess().Id));

            foreach (ManagementObject mo in mos.Get())
            {
                children.Add(Process.GetProcessById(Convert.ToInt32(mo["ProcessID"])));
            }

            return children;
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

        private async void FluxusBypass()
        {
            string Title = NavigateForTitle(StarterUrl.Text).Result;

            if (Title == "Fluxus | Start")
            {
                ExecuteJavaScript("document.body.prepend(document.querySelector('#captcha'));document.body.children[1].remove();");

                while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);

                DoVertiseRedirect();

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);
                while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);

                DoVertiseRedirect();

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);
                while (!GetUrl().Contains("linkvertise")) await Task.Delay(50);

                DoVertiseRedirect();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LogBox.Clear();
            LogData(LogType.System, "Running, please wait... (May take up to 30 seconds for some exploits)");

            try
            {
                switch (SelectedExploit.Text)
                {
                    case "Kiwi X":
                        Driver.Url = "https://kiwiexploits.com/KeySystems/index.php?";
                        break;
                    case "Fluxus":
                    case "Oxygen U":
                    case "Comet":
                    case "":
                        FluxusBypass();
                        return;
                }
            } catch (WebDriverException ex)
            {
                if (ex.ToString().Contains("Reached error"))
                {
                    MessageBox.Show("Page URL Invalid", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    DetectedBrowser = BrowserType.Firefox;
                }
                else if (ProgId.Contains("ChromeHtml"))
                {
                    DetectedBrowser = BrowserType.Chrome;
                }
                else if (ProgId.Contains("MSEdge"))
                {
                    DetectedBrowser = BrowserType.Edge;
                }
            }

            bool Downloaded = false;

            DialogResult dialogResult = MessageBox.Show($"{DetectedBrowser} detected, download web driver (REQUIRED)?", "Iris Roblox MultiTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string DownloadUrl = DriverDownloads[DetectedBrowser];
                string FileName = DownloadUrl.Substring(DownloadUrl.LastIndexOf("/")+1);

                if (File.Exists($"{Program.Directory}\\bin\\drivers\\{FileName}"))
                {
                    MessageBox.Show("Downloaded completed, you may proceed!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Downloaded = true;
                }
                else
                {
                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFileCompleted += (_, __) =>
                        {
                            MessageBox.Show("Downloaded completed, you may proceed!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Downloaded = true;
                        };
                        Client.DownloadFileAsync(new Uri(DownloadUrl), $"{Program.Directory}\\bin\\drivers\\{FileName}");
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
            } while (!Downloaded);

            try
            {
                switch (DetectedBrowser)
                {
                    case BrowserType.Chrome:
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--no-sandbox");
                        chromeOptions.AddArgument("--disable-dev-shm-usage");
                        chromeOptions.AddArgument("--enable-logging");
                        ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService($"{Program.Directory}\\bin\\drivers");
                        chromeDriverService.HideCommandPromptWindow = true;
                        DriverProcId = chromeDriverService.ProcessId;
                        Driver = new ChromeDriver(chromeDriverService, chromeOptions);
                        break;
                    case BrowserType.Firefox:
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArgument("--no-sandbox");
                        firefoxOptions.AddArgument("--disable-dev-shm-usage");
                        firefoxOptions.AddArgument("--enable-logging");
                        FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService($"{Program.Directory}\\bin\\drivers");
                        firefoxDriverService.HideCommandPromptWindow = true;
                        DriverProcId = firefoxDriverService.ProcessId;
                        Driver = new FirefoxDriver(firefoxDriverService, firefoxOptions);
                        break;
                    case BrowserType.Edge:
                        EdgeOptions edgeOptions = new EdgeOptions();
                        edgeOptions.AddArgument("--no-sandbox");
                        edgeOptions.AddArgument("--disable-dev-shm-usage");
                        edgeOptions.AddArgument("--enable-logging");
                        EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService($"{Program.Directory}\\bin\\drivers");
                        edgeDriverService.HideCommandPromptWindow = true;
                        DriverProcId = edgeDriverService.ProcessId;
                        Driver = new EdgeDriver(edgeDriverService, edgeOptions);
                        break;
                }
            }
            catch (WebDriverException ex)
            {
                if (ex.ToString().Contains("cannot find"))
                {
                    MessageBox.Show($"{DetectedBrowser} binary cannot be found! ", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            foreach (Process proc in Process.GetProcesses())
                if (proc.Id == DriverProcId)
                    DriverHandle = proc.Handle;

            ShowWindow(DriverHandle, 0);
        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.ScrollToCaret();
        }
        //https://flux.li/windows/start.php?HWID=7fd482cc432f11edacd5806e6f6e696381d7985a07a290487eb3ea50f8dae3b7
        private void SelectedExploit_SelectedIndexChanged(object sender, EventArgs e)
        {
            FluxusKeySystem = false;
            switch (SelectedExploit.Text)
            {

                case "Fluxus":
                    #if DEBUG
                        StarterUrl.Text = "https://flux.li/windows/start.php?HWID=fbba28a7604a11eda702806e6f6e6963a4872ad2dd325cabc47545d3159dea67";
                    #else
                        MessageBox.Show("Please get a starter url via Fluxus client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #endif

                    FluxusKeySystem = true;
                    break;
                case "Oxygen U":
                    #if DEBUG
                        StarterUrl.Text = "https://oxygenu.xyz/KeySystem/Start.php?HWID=bd69a7d29bc011ec913f806e6f6e6963";
                    #endif
                    MessageBox.Show("Please get a starter url via Oxygen client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FluxusKeySystem = true;
                    break;
                case "Comet":
                    MessageBox.Show("Please get a starter url via Comet client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FluxusKeySystem = true;
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
                return "";
            }
        }

        private string GetUrl()
        {
            return Driver.SwitchTo().Window(Driver.WindowHandles.Last()).Url;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Key.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(GetUrl());
        }
    }
}
