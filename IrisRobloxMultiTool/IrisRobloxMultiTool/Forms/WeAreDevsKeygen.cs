﻿using IrisRobloxMultiTool.Classes;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V107.IndexedDB;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class WeAreDevsKeygen : Form
    {
        private LogInterface Log = Program.LogInterface;
        private bool DebugBrowser = true;

        private static readonly HttpClient Client = new HttpClient();

        Dictionary<string, bool> Downloads = new Dictionary<string, bool>()
        {
            {"https://cdn.discordapp.com/attachments/1044070738233151488/1044070770558636132/msedgedriver.exe", false},
            {"https://cdn.discordapp.com/attachments/1044070738233151488/1044815404582842429/extension_1_45_2_0.crx", false },
            {"https://cdn.discordapp.com/attachments/1044070738233151488/1045613743175892992/buster.crx", false}
        };

        IWebDriver Driver;

        public WeAreDevsKeygen()
        {
            InitializeComponent();
        }

        private void SetToken()
        {
            foreach (var Data in JObject.Parse(new WebClient().DownloadString("https://raw.githubusercontent.com/IrisV3rm/IrisRobloxMultiTool/main/hcaptcha_token.json")))
            {
                Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(Data.Key, Data.Value.ToString()));
            }
        }

        private void DoVertiseRedirect(int What, int OutaWhat, int WaitTime, string AdditionalInfo = "")
        {
            Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, $"Linkvertise {What}/{OutaWhat} Started {AdditionalInfo}...");
            while (!GetUrl().Contains("linkvertise")) Task.Delay(5).Wait();

            if (!DebugBrowser)
                Driver.Manage().Window.Position = new(-2000, -2000);

            Task.Delay(WaitTime).Wait();

            ExecuteJavaScript($@"
let Button = document.createElement(""button""); 
Button.Id = ""SPOOFBUTTON""; 
Button.onclick = function() {{ window.open(""{GetLinkvertiseRedirect(Driver.Url)}"", '_blank').focus(); }}; 
document.body.prepend(Button); 
Button.click();
");

            while (GetUrl().Contains("linkvertise")) Task.Delay(5).Wait();

           Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, $"Linkvertise {What++}/{OutaWhat} Passed...");
        }

        private void DoCaptcha(int What, int OutaWhat, string CaptchaUrl, string NextUrl, string ScriptToExecute, bool ShowWindow = true)
        {
            while (!GetUrl().Contains(CaptchaUrl)) Task.Delay(25).Wait();

            Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, $"Captcha {What}/{OutaWhat} Started...");

            ExecuteJavaScript(ScriptToExecute);
            if (ShowWindow) { 
                Driver.Manage().Window.Size = new(500, 300);
                Driver.Manage().Window.Position = new((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (Height / 2));
            }
            while (!GetUrl().Contains(NextUrl)) Task.Delay(25).Wait();

            Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, $"Captcha {What}/{OutaWhat} Passed...");

            if (!DebugBrowser)
                Driver.Manage().Window.Position = new(-2000, -2000);
        }
        
        private bool DoHCaptchaBypass(int What, int OutaWhat, string CaptchaUrl, string NextUrl)
        {
            while (!GetUrl().Contains(CaptchaUrl)) Task.Delay(25).Wait();

            SetToken();

            ExecuteJavaScript("document.getElementsByTagName(\"iframe\")[1].focus()");
            new WebDriverWait(Driver, TimeSpan.FromMinutes(60)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//iframe[@title='Widget containing checkbox for hCaptcha security challenge']"))).Click();

            Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, $"Captcha {What}/{OutaWhat} Started...");

            if (ExecuteJavaScript("return document.getElementById(\"status-help\").innerText") == "Accessibility cookie is not set. Retrieve accessibility cookie.")
            {
                return false;
            }
            else
            {
                ExecuteJavaScript("document.getElementById(\"checkbox\").click();");
                Task.Delay(1000).Wait();
                if (ExecuteJavaScript("return document.getElementsByClassName(\"check\")[0].style.display") == "none")
                {
                    return false;
                }
            }

            while (!GetUrl().Contains(NextUrl)) Task.Delay(25).Wait();

            Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, $"Captcha {What}/{OutaWhat} Passed...");

            if (!DebugBrowser)
                Driver.Manage().Window.Position = new(-2000, -2000);

            return true;
        }

        private async void BetaDoFluxusKeySystem()
        {
            string Title = NavigateForTitle(StarterUrl.Text).Result;

            if (GetUrl().Contains("start.php?HWID=") && GetUrl().Contains("flux"))
            {
                Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Fluxus chosen, attempting to auto solve the captcha!");

                if (!DoHCaptchaBypass(What: 1, OutaWhat: 1, CaptchaUrl: "flux.li", NextUrl: "linkvertise"))
                {
                    Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Auto captcha failed, please solve captcha...");
                    DoCaptcha(What: 1, OutaWhat: 1, CaptchaUrl: "flux.li", NextUrl: "linkvertise", ScriptToExecute: "document.body.prepend(document.querySelector('#captcha'));document.body.children[1].remove();");
                }

                DoVertiseRedirect(What: 1, OutaWhat: 3, WaitTime: 0);

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);

                DoVertiseRedirect(What: 2, OutaWhat: 3, WaitTime: 0);

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);

                DoVertiseRedirect(What: 3, OutaWhat: 3, WaitTime: 0);

                await Task.Delay(250);
                Key.Text = ExecuteJavaScript("for (let item of document.getElementsByTagName(\"code\")) {     if (item.innerText.length > 10) {         return item.innerText;     } }");
                Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Outputting key!");

            }

            Driver.Quit();

            MessageBox.Show("You may now close all opened browser windows if still open!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private async void DoFluxusKeySystem()
        {
            string Title = NavigateForTitle(StarterUrl.Text).Result;

            if (GetUrl().Contains("start.php?HWID=") && GetUrl().Contains("flux"))
            {
               Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Fluxus chosen, please solve the captcha!");

                DoCaptcha(What: 1, OutaWhat: 1, CaptchaUrl: "flux.li", NextUrl: "linkvertise", ScriptToExecute: "document.body.prepend(document.querySelector('#captcha'));document.body.children[1].remove();");

                DoVertiseRedirect(What: 1, OutaWhat: 3, WaitTime: 0);

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);

                DoVertiseRedirect(What: 2, OutaWhat: 3, WaitTime: 0);

                while (!GetUrl().Contains("flux.li")) await Task.Delay(50);

                DoVertiseRedirect(What: 3, OutaWhat: 3, WaitTime: 0);

                await Task.Delay(250);
                Key.Text = ExecuteJavaScript("for (let item of document.getElementsByTagName(\"code\")) {     if (item.innerText.length > 10) {         return item.innerText;     } }");
               Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Outputting key!");

            }
            else if (Title == "Oxygen u Key")
            {
               Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Oxygen U chosen, please solve the captcha!");

                DoCaptcha(What: 1, OutaWhat: 1, CaptchaUrl: "oxygenu.xyz", NextUrl: "linkvertise", ScriptToExecute: "document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"container\")[0].remove()");

                DoVertiseRedirect(What: 1, OutaWhat: 2, 7000);
                DoVertiseRedirect(What: 2, OutaWhat: 2, 7000);

                Key.Text = ExecuteJavaScript("return raw");
               Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Outputting key!");
            }
            else if (Title == "Oxygen U" && GetUrl() == "https://oxygenu.xyz/KeySystem/Main.php")
            {
                Key.Text = ExecuteJavaScript("return raw");
               Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Outputting key!");
            }


            Driver.Quit();

            MessageBox.Show("You may now close all opened browser windows if still open!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DoKiwiBypass()
        {
            NavigateForTitle("https://kiwiexploits.com/KeySystems/index.php?").Wait();

            DoCaptcha(What: 1, OutaWhat: 4, CaptchaUrl: "https://kiwiexploits.com/keystart", NextUrl: "kiwiexploits.com/Key1", ScriptToExecute: "setTimeout(() => { document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click(); }, 4000);", ShowWindow: false);
            DoCaptcha(What: 2, OutaWhat: 4, CaptchaUrl: "kiwiexploits.com/Key1", NextUrl: "linkvertise", ScriptToExecute: "setTimeout(() => { document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click(); }, 4000);", ShowWindow: false);
            DoVertiseRedirect(What: 1, OutaWhat: 2, WaitTime: 7000);
            DoCaptcha(What: 3, OutaWhat: 4, CaptchaUrl: "kiwiexploits.com/Key2", NextUrl: "linkvertise", ScriptToExecute: "setTimeout(() => { document.getElementById('txtInput').value = document.getElementById('mainCaptcha').value;document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click();document.getElementById('Button1').click(); }, 4000);", ShowWindow: false);
            DoVertiseRedirect(What: 2, OutaWhat: 2, WaitTime: 7000);

            Driver.Manage().Window.Size = new(800, 650);
            Driver.Manage().Window.Position = new((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2), (Screen.PrimaryScreen.WorkingArea.Height / 2) - (Height / 2));
            
            DoCaptcha(What: 4, OutaWhat: 4, CaptchaUrl: "https://kiwiexploits.com/KeySystems/index.php", NextUrl: "https://kiwiexploits.com/KeySystems/index.php?", ScriptToExecute: "return true", ShowWindow: false);

            Key.Text = ExecuteJavaScript("return document.getElementById(\"key\").innerText");
            Driver.Quit();
            MessageBox.Show("You may now close all opened browser windows if still open!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DoKrnlBypass()
        {
            Driver.Navigate().GoToUrl("https://cdn.krnl.place/getkey.php");


           Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Krnl chosen, please solve the captcha! 1/4");

            DoCaptcha(What: 1, OutaWhat: 4, CaptchaUrl: "cdn.krnl.place/getkey", NextUrl: "linkvertise", ScriptToExecute: "document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"form-group\")[0].style = \"\"");
            DoVertiseRedirect(What: 1, OutaWhat: 4, WaitTime: 20000, AdditionalInfo: "(Please wait 20 seconds per linkvertise)");

            DoCaptcha(What: 2, OutaWhat: 4, CaptchaUrl: "cdn.krnl.place", NextUrl: "linkvertise", ScriptToExecute: "document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"form-group\")[0].style = \"\"");
            DoVertiseRedirect(What: 2, OutaWhat: 4, WaitTime: 20000, AdditionalInfo: "(Please wait 20 seconds per linkvertise)");

            DoCaptcha(What: 3, OutaWhat: 4, CaptchaUrl: "cdn.krnl.place", NextUrl: "linkvertise", ScriptToExecute: "document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"form-group\")[0].style = \"\"");
            DoVertiseRedirect(What: 3, OutaWhat: 4, WaitTime: 20000, AdditionalInfo: "(Please wait 20 seconds per linkvertise)");

            DoCaptcha(What: 4, OutaWhat: 4, CaptchaUrl: "cdn.krnl.place", NextUrl: "linkvertise", ScriptToExecute: "document.body.prepend(document.getElementsByTagName(\"form\")[0]);document.getElementsByClassName(\"form-group\")[0].style = \"\"");
            DoVertiseRedirect(What: 4, OutaWhat: 4, WaitTime: 20000, AdditionalInfo: "(Please wait 20 seconds per linkvertise)");

            Key.Text = ExecuteJavaScript("return document.getElementsByTagName(\"input\")[0].value");

           Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Krnl key has been generated...");

            Driver.Quit();
        }

        private void DoNovalineBypass()
        {
            Driver.Navigate().GoToUrl("https://key.novaline.club/getkey/some-random-shit");

           Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Novaline chosen, please solve the captcha! 1/2");

            DoCaptcha(What: 1, OutaWhat: 2, CaptchaUrl: "https://key.novaline.club/getkey", NextUrl: "linkvertise", ScriptToExecute: "return true");
            DoVertiseRedirect(What: 1, OutaWhat: 2, WaitTime: 6000);
            DoCaptcha(What: 2, OutaWhat: 2, CaptchaUrl: "novaline.club", NextUrl: "linkvertise", ScriptToExecute: "return true");
            DoVertiseRedirect(What: 1, OutaWhat: 2, WaitTime: 6000);

            Key.Text = ExecuteJavaScript("return document.getElementById(\"createdKey\").value");

           Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Novaline key has been generated...");

            Driver.Quit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The application may appear frozen, it is not, do not force close / spam click", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            GenerateKey.Enabled = false;
            LogBox.Clear();
           Program.LogInterface.DoLog(LogBox, LogInterface.LogType.System, "Running, please wait... (May take up to a minute for some exploits)");

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
                    case "Novaline":
                        DoNovalineBypass();
                        break;
                    case "Fluxus":
                    case "Oxygen U":
                    case "":
                        #if DEBUG
                            BetaDoFluxusKeySystem();
                        #else
                            DoFluxusKeySystem();
                        #endif
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
            Process.GetProcessesByName("msedgedriver").ToList().ForEach(Proc => Proc.Kill());

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

            DialogResult dialogResult = MessageBox.Show($"Edge detected, download required binaries??", "Iris Roblox MultiTool", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (string DownUrl in Downloads.Keys.ToList())
                {
                    string FileName = DownUrl.Substring(DownUrl.LastIndexOf("/") + 1);

                    if (File.Exists($"{Program.Directory}\\bin\\drivers\\{FileName}"))
                    {
                        Downloads[DownUrl] = true;
                    }
                    else
                    {
                        using (WebClient Client = new WebClient())
                        {
                            Client.DownloadFileCompleted += (_, __) =>
                            {
                                Downloads[DownUrl] = true;
                            };
                            Client.DownloadFileAsync(new Uri(DownUrl), $"{Program.Directory}\\bin\\drivers\\{FileName}");
                        }
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Unable to continue with keygen, please reload.", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            do
            {
                await Task.Delay(50);
            } while (!Downloads.Values.Any(c=> c == true));

            MessageBox.Show("Download completed, you may proceed!", "Iris Roblox MultiTool", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                EdgeOptions edgeOptions = new EdgeOptions();
                edgeOptions.AddArgument("--no-sandbox");
                edgeOptions.AddArgument("--disable-dev-shm-usage");
                edgeOptions.AddArgument("--enable-logging");
                edgeOptions.AddExtension($"{Program.Directory}\\bin\\drivers\\extension_1_45_2_0.crx");
                edgeOptions.AddExtension($"{Program.Directory}\\bin\\drivers\\buster.crx");

                EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService($"{Program.Directory}\\bin\\drivers");
                edgeDriverService.HideCommandPromptWindow = true;
                Driver = new EdgeDriver(edgeDriverService, edgeOptions);

                if (!DebugBrowser)
                    Driver.Manage().Window.Position = new(-2000, -2000);
            }
            catch (WebDriverException ex)
            {
                if (ex.ToString().Contains("cannot find"))
                {
                    MessageBox.Show($"Edge cannot be found, is it installed?", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!DebugBrowser)
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
#else
                        MessageBox.Show("Please get a starter url via Oxygen client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
                    break;
                case "Novaline":
#if DEBUG
                        StarterUrl.Text = "https://oxygenu.xyz/KeySystem/Start.php?HWID=bd69a7d29bc011ec913f806e6f6e6963";
#else
                        MessageBox.Show("Please get a starter url via Oxygen client! (Click GetKey)", "IRMT", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
                    break;
            }
        }

        private string GetLinkvertiseRedirect(string url)
        {
            try
            {
                JToken JsonData = JToken.Parse(Client.PostAsync("https://api.bypass.vip/", new FormUrlEncodedContent(new Dictionary<string, string>() { { "url", url } })).Result.Content.ReadAsStringAsync().Result);

                if (JsonData["success"].ToString() == "false" || JsonData["destination"] == null || string.IsNullOrEmpty(JsonData["destination"].ToString()))
                {
                    MessageBox.Show($"Failed to bypass please submit an issue request on github!", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Driver.Quit();
                    return string.Empty;
                }

                return JsonData["destination"].ToString();
            }
            catch
            {
                MessageBox.Show($"Failed to bypass please submit an issue request on github!", "Iris Roblox MutliTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Driver.Quit();
                return string.Empty;
            }
        }

        private Task<string> NavigateForTitle(string url)
        {
            Driver.Navigate().GoToUrl(url);
            new WebDriverWait(Driver, TimeSpan.FromMinutes(1.0)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            return Task.FromResult(Driver.Title);
        }

        private string ExecuteJavaScript(string script)
        {
            try
            {
                object Data = (Driver as IJavaScriptExecutor).ExecuteScript(script);

                if (Data != null) return Data.ToString();
                else return "";
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
                if (Driver.WindowHandles == null)
                    return "";

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
