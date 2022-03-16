using Guna.UI2.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class ToolsDownloader : Form
    {
        public ToolsDownloader()
        {
            InitializeComponent();
        }

        private void AddProgram(string ProgramName, string ProgramIcon, string ProgramDownload)
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
            GroupText.Font = new Font("Microsoft YaHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GroupText.ForeColor = Color.White;
            GroupText.IsContextMenuEnabled = false;
            GroupText.IsSelectionEnabled = false;
            GroupText.Location = new Point(0, 0);
            GroupText.Name = "GroupText";
            GroupText.Size = new Size(100, 100);
            GroupText.TabIndex = 0;
            GroupText.Text = ProgramName;
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

            if (ProgramIcon.Length > 5)
                GroupImage.LoadAsync(ProgramIcon);

            TemplatePanel.Controls.Add(GroupImage);
            TemplatePanel.Controls.Add(GroupText);
            GroupText.BringToFront();


            GroupText.MouseClick += (o, e) =>
            {
                Process.Start(ProgramDownload);
            };
            GroupImage.MouseClick += (o, e) =>
            {
                Process.Start(ProgramDownload);
            };

            flowLayoutPanel1.Controls.Add(TemplatePanel);

        }

        private void ToolsDownloader_Load(object sender, EventArgs e)
        {
            JToken Data = JToken.Parse(new WebClient().DownloadString("https://irisapp.ca/IRMT/API/VerifiedPrograms.php"));

            for (int i = 0; i < Data.Children().Count(); i++)
            {
                AddProgram(Data[i]["Name"].ToString(), Data[i]["ImageUrl"].ToString(), Data[i]["Download"].ToString());
            }
        }
    }
}
