using Guna.UI2.WinForms;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{

    public partial class GroupScanner : Form
    {
        // https://groups.roblox.com/v1/groups/3423188
        // https://groups.roblox.com/v1/groups/search?keyword=Yeet&prioritizeExactMatch=true&limit=100&cursor=
        // https://groups.roblox.com/v1/groups/3423188/membership
        // https://economy.roblox.com/v1/groups/3423188/currency

        private List<long> Groups = new List<long>();

        public GroupScanner()
        {
            InitializeComponent();
        }

        private void GroupScanner_Load(object sender, EventArgs e)
        {
            StartIdBox.Text = "1";
            EndIdBox.Text = "1";
            GroupsHolder.HorizontalScroll.Maximum = 0;
            GroupsHolder.HorizontalScroll.Visible = false;
            GroupsHolder.HorizontalScroll.Enabled = false;
            GroupsHolder.AutoScroll = true;
        }

        private string DoNet(string Type, string RequestUrl, string PostParams = "")
        {
            string Out = string.Empty;

            using (WebClient Client = new WebClient())
            {
                Client.Headers.Add(HttpRequestHeader.Cookie, Program.RbxApi.AccountData.Cookie);
                Client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36");

                if (Type == "GET")
                {
                    try
                    {
                        Out = Client.DownloadString(RequestUrl);
                    }
                    catch
                    {
                        Console.Write("Failed: ");
                        Console.WriteLine(RequestUrl);
                    }
                }
                else if (Type == "POST")
                {
                    try
                    {
                        Out = Client.UploadString(RequestUrl, PostParams);
                    }
                    catch
                    {
                        Console.Write("Failed: ");
                        Console.WriteLine(RequestUrl);
                    }
                }
            }

            return Out;
        }

        private void GetGroups()
        {
            if (!UseSearchCheck.Checked)
            {
                for (long i = long.Parse(StartIdBox.Text); i <= long.Parse(EndIdBox.Text); i++)
                {
                    Groups.Add(i);
                }
            }
            else
            {
                string Json = DoNet("GET", $"https://groups.roblox.com/v1/groups/search?keyword={KeywordBox.Text}&prioritizeExactMatch=true&limit=100");
                
                JToken JData = JObject.Parse(Json);

                if (JData["data"].Children().Count() > 0)
                {
                    Console.WriteLine(JData["data"].Children().Count());
                    for (int i = 0; i < JData["data"].Children().Count(); i++)
                    {
                        Groups.Add(long.Parse(JData["data"][i]["id"].ToString()));
                    }
                }
            }
        }

        private void AddGroup(string GroupName, string GroupImageUrl, string GroupID)
        {
            GroupsHolder.Invoke(new Action(() =>
            {
                Panel TemplatePanel = new Panel();
                Guna2HtmlLabel GroupText = new Guna2HtmlLabel();
                Guna2PictureBox GroupImage = new Guna2PictureBox();

                TemplatePanel.BackgroundImageLayout = ImageLayout.Stretch;
                TemplatePanel.Location = new Point(3, 3);
                TemplatePanel.Name = "TemplatePanel";
                TemplatePanel.Size = new Size(100, 100);
                TemplatePanel.TabIndex = 0;
                GroupText.AutoSize = true;
                GroupText.BackColor = Color.Transparent;
                GroupText.ContextMenuStrip = GroupContext;
                GroupText.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                GroupText.ForeColor = Color.White;
                GroupText.IsContextMenuEnabled = false;
                GroupText.IsSelectionEnabled = false;
                GroupText.Location = new Point(0, 0);
                GroupText.Name = "GroupText";
                GroupText.Size = new Size(100, 100);
                GroupText.TabIndex = 0;
                GroupText.Text = GroupName;
                GroupText.TextAlignment = ContentAlignment.MiddleCenter;
                GroupImage.Dock = DockStyle.Fill;
                GroupImage.Location = new Point(0, 0);
                GroupImage.Name = "GroupImage";
                GroupImage.ShadowDecoration.Parent = GroupImage;
                GroupImage.Size = new Size(100, 100);
                GroupImage.SizeMode = PictureBoxSizeMode.StretchImage;
                GroupImage.TabIndex = 1;
                GroupImage.TabStop = false;
                GroupImage.UseTransparentBackground = true;
                GroupImage.Cursor = Cursors.Hand;
                GroupText.Cursor = Cursors.Hand;

                if (GroupImageUrl.Length > 15)
                    GroupImage.LoadAsync(GroupImageUrl);

                TemplatePanel.Controls.Add(GroupImage);
                TemplatePanel.Controls.Add(GroupText);
                GroupText.BringToFront();

                GroupText.ContextMenuStrip = GroupContext;

                GroupText.MouseClick += (o, e) =>
                {
                    Process.Start($"https://www.roblox.com/groups/{GroupID}");
                };
                GroupImage.MouseClick += (o, e) =>
                {
                    Process.Start($"https://www.roblox.com/groups/{GroupID}");
                };

                GroupsHolder.Controls.Add(TemplatePanel);
            }));
        }

        private void StartIdBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void CheckJoinable()
        {
            List<long> GroupToDelete = new List<long>();
            ProgressBar.Value = 0;
            ProgressBar.Maximum = Groups.Count();
            foreach (long GroupID in Groups.ToList())
            {
                await Task.Delay(25);
                string Data = DoNet("GET", $"https://groups.roblox.com/v1/groups/{GroupID}");

                if (Data.Contains("errors."))
                    Console.WriteLine("");
                else if (Data.Contains("{\"data\":[]}"))
                    Console.WriteLine("");
                else if (Data.Length > 10)
                {
                    JToken JData = JToken.Parse(Data);

                    if (!Convert.ToBoolean(JData["publicEntryAllowed"]))
                    {
                        GroupToDelete.Add(GroupID);
                    }
                }
                ProgressBar.Value += 1;
            }

            foreach (long GroupID in GroupToDelete)
            {
                Groups.Remove(GroupID);
            }
        }

        private async void DoEmptyCheck()
        {
            List<long> GroupToDelete = new List<long>();
            ProgressBar.Value = 0;
            ProgressBar.Maximum = Groups.Count();

            foreach (long GroupID in Groups.ToList())
            {
                await Task.Delay(25);
                string Data = DoNet("GET", $"https://groups.roblox.com/v1/groups/{GroupID}");

                if (Data.Contains("errors."))
                    Console.WriteLine("");
                else if (Data.Contains("{\"data\":[]}"))
                    Console.WriteLine("");
                else if (Data.Length > 10)
                {
                    JToken JData = JToken.Parse(Data);

                    if (long.Parse(JData["memberCount"].ToString()) < 4)
                    {
                        GroupToDelete.Add(GroupID);
                    }
                }
                ProgressBar.Value += 1;
            }

            foreach (long GroupID in GroupToDelete)
            {
                Groups.Remove(GroupID);
            }
        }

        private async void CheckFundLevel()
        {
            List<long> GroupToDelete = new List<long>();
            ProgressBar.Value = 0;
            ProgressBar.Maximum = Groups.Count();
            foreach (long GroupID in Groups.ToList())
            {
                await Task.Delay(25);
                string Data = DoNet("GET", $"https://groups.roblox.com/v1/groups/{GroupID}/membership");

                if (Data.Contains("errors."))
                    Console.WriteLine("");
                else if (Data.Contains("{\"data\":[]}"))
                    Console.WriteLine("");
                else if (Data.Length > 10)
                {
                    JToken JData = JToken.Parse(Data);

                    if (!Convert.ToBoolean(JData["areGroupFundsVisible"]))
                    {
                        GroupToDelete.Add(GroupID);
                    }
                    else
                    {
                        Data = DoNet("GET", $"https://economy.roblox.com/v1/groups/{GroupID}/currency");

                        JData = JToken.Parse(Data);

                        if (Data.Contains("robux:"))
                        {
                            int Robux = int.Parse(JData["robux"].ToString());

                            if (Robux < 5)
                            {
                                GroupToDelete.Add(GroupID);
                            }
                        }
                    }
                }
                ProgressBar.Value += 1;
            }

            foreach (long GroupID in GroupToDelete)
            {
                Groups.Remove(GroupID);
            }
        }

        private async void DoGroupPlacement()
        {
            ProgressBar.Value = 0;
            ProgressBar.Maximum = Groups.Count();

            if (WriteToFile.Checked)
            {
                Directory.CreateDirectory($"{Program.Directory}\\GroupScanner");
                string Data = string.Join("\nhttps://www.roblox.com/groups/", Groups.ToList());
                using (StreamWriter Writer = new StreamWriter($"{Program.Directory}\\GroupScanner\\{DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss")}.txt"))
                {
                    Writer.Write($"https://www.roblox.com/groups/{Data}");
                }
                Process.Start($"{Program.Directory}\\GroupScanner");
                return;
            }

            foreach (long GroupID in Groups.ToList())
            {
                await Task.Delay(25);

                string ImageData = DoNet("GET", $"https://thumbnails.roblox.com/v1/groups/icons?groupIds={GroupID}&size=150x150&format=Png&isCircular=false");
                string GroupName = DoNet("GET", $"https://groups.roblox.com/v1/groups/{GroupID}");
                JToken JData = JToken.Parse(ImageData);

                if (ImageData.Contains("errors."))
                    Console.WriteLine("");
                else if (GroupName.Contains("errors."))
                    Console.WriteLine("");
                else if (ImageData.Contains("{\"data\":[]}"))
                    Console.WriteLine("");
                else if (GroupName.Contains("{\"data\":[]}"))
                    Console.WriteLine("");
                else if (ImageData.Length > 10 && GroupName.Length > 10)
                {
                    ImageData = JData["data"][0]["imageUrl"].ToString();

                    JData = JToken.Parse(GroupName);

                    GroupName = JData["name"].ToString();

                    
                    await Task.Run(() =>
                    {
                        AddGroup(GroupName, ImageData, GroupID.ToString());
                    });
                }
                ProgressBar.Value += 1;
            }
        }

        private async void StartDownload_Click(object sender, EventArgs e)
        {
            ProgressBar.Value = 0;
            ProgressBar.Maximum = 0;

            Groups.Clear();
            GroupsHolder.Controls.Clear();

            GetGroups();
            await Task.Delay(15);
            if (EmptyCheck.Checked)
                DoEmptyCheck();
            await Task.Delay(15);
            if (JoinableCheck.Checked)
                CheckJoinable();
            await Task.Delay(15);
            if (HasFundsCheck.Checked)
                CheckFundLevel();
            await Task.Delay(15);
            DoGroupPlacement();

        }

        private void UseProxies_CheckedChanged(object sender, EventArgs e)
        {
            UseProxies.Checked = false;
        }
    }
}
