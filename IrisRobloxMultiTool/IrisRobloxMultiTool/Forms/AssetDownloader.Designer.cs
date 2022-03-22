namespace IrisRobloxMultiTool.Forms
{
    partial class AssetDownloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HolderPanel = new System.Windows.Forms.Panel();
            this.ProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.ManualIDCheck = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.KeywordBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ItemCount = new System.Windows.Forms.ComboBox();
            this.PageCountForAudio = new System.Windows.Forms.ComboBox();
            this.StartDownload = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ItemTypeCombo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FindLocation = new Guna.UI2.WinForms.Guna2Button();
            this.CustomIdLocBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LogBox = new VertexFramework.UIControls.VRichTextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.RealAssetName = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.HolderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HolderPanel
            // 
            this.HolderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HolderPanel.Controls.Add(this.RealAssetName);
            this.HolderPanel.Controls.Add(this.ProgressBar);
            this.HolderPanel.Controls.Add(this.ManualIDCheck);
            this.HolderPanel.Controls.Add(this.label11);
            this.HolderPanel.Controls.Add(this.label10);
            this.HolderPanel.Controls.Add(this.KeywordBox);
            this.HolderPanel.Controls.Add(this.label7);
            this.HolderPanel.Controls.Add(this.ItemCount);
            this.HolderPanel.Controls.Add(this.PageCountForAudio);
            this.HolderPanel.Controls.Add(this.StartDownload);
            this.HolderPanel.Controls.Add(this.label5);
            this.HolderPanel.Controls.Add(this.ItemTypeCombo);
            this.HolderPanel.Controls.Add(this.label4);
            this.HolderPanel.Controls.Add(this.FindLocation);
            this.HolderPanel.Controls.Add(this.CustomIdLocBox);
            this.HolderPanel.Controls.Add(this.label3);
            this.HolderPanel.Controls.Add(this.comboBox1);
            this.HolderPanel.Location = new System.Drawing.Point(17, 14);
            this.HolderPanel.Name = "HolderPanel";
            this.HolderPanel.Size = new System.Drawing.Size(623, 242);
            this.HolderPanel.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.ProgressBar.FillColor = System.Drawing.Color.LightGray;
            this.ProgressBar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressBar.ForeColor = System.Drawing.Color.Black;
            this.ProgressBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.ProgressBar.Location = new System.Drawing.Point(183, 208);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(155)))), ((int)(((byte)(251)))));
            this.ProgressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            this.ProgressBar.ShadowDecoration.Parent = this.ProgressBar;
            this.ProgressBar.ShowPercentage = true;
            this.ProgressBar.Size = new System.Drawing.Size(300, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 44;
            this.ProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // ManualIDCheck
            // 
            this.ManualIDCheck.AutoSize = true;
            this.ManualIDCheck.ForeColor = System.Drawing.Color.White;
            this.ManualIDCheck.Location = new System.Drawing.Point(66, 177);
            this.ManualIDCheck.Name = "ManualIDCheck";
            this.ManualIDCheck.Size = new System.Drawing.Size(152, 17);
            this.ManualIDCheck.TabIndex = 43;
            this.ManualIDCheck.Text = "Only download custom IDs";
            this.ManualIDCheck.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(296, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(311, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "*";
            // 
            // KeywordBox
            // 
            this.KeywordBox.Animated = true;
            this.KeywordBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.KeywordBox.DefaultText = "";
            this.KeywordBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.KeywordBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.KeywordBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KeywordBox.DisabledState.Parent = this.KeywordBox;
            this.KeywordBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KeywordBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.KeywordBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KeywordBox.FocusedState.Parent = this.KeywordBox;
            this.KeywordBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KeywordBox.ForeColor = System.Drawing.Color.White;
            this.KeywordBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KeywordBox.HoverState.Parent = this.KeywordBox;
            this.KeywordBox.Location = new System.Drawing.Point(168, 99);
            this.KeywordBox.Name = "KeywordBox";
            this.KeywordBox.PasswordChar = '\0';
            this.KeywordBox.PlaceholderText = "";
            this.KeywordBox.SelectedText = "";
            this.KeywordBox.ShadowDecoration.Parent = this.KeywordBox;
            this.KeywordBox.Size = new System.Drawing.Size(322, 22);
            this.KeywordBox.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(63, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 14);
            this.label7.TabIndex = 37;
            this.label7.Text = "Search Param:";
            // 
            // ItemCount
            // 
            this.ItemCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ItemCount.DisplayMember = "1";
            this.ItemCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemCount.ForeColor = System.Drawing.Color.White;
            this.ItemCount.FormattingEnabled = true;
            this.ItemCount.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000",
            "1100",
            "1200",
            "1300",
            "1400",
            "1500",
            "1600",
            "1700",
            "1800",
            "1900",
            "2000"});
            this.ItemCount.Location = new System.Drawing.Point(169, 68);
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.Size = new System.Drawing.Size(121, 21);
            this.ItemCount.TabIndex = 33;
            // 
            // PageCountForAudio
            // 
            this.PageCountForAudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PageCountForAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PageCountForAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PageCountForAudio.ForeColor = System.Drawing.Color.White;
            this.PageCountForAudio.FormattingEnabled = true;
            this.PageCountForAudio.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            });
            this.PageCountForAudio.Location = new System.Drawing.Point(169, 68);
            this.PageCountForAudio.Name = "PageCountForAudio";
            this.PageCountForAudio.Size = new System.Drawing.Size(121, 21);
            this.PageCountForAudio.TabIndex = 36;
            // 
            // StartDownload
            // 
            this.StartDownload.CheckedState.Parent = this.StartDownload;
            this.StartDownload.CustomImages.Parent = this.StartDownload;
            this.StartDownload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.StartDownload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartDownload.ForeColor = System.Drawing.Color.White;
            this.StartDownload.HoverState.Parent = this.StartDownload;
            this.StartDownload.Location = new System.Drawing.Point(243, 166);
            this.StartDownload.Name = "StartDownload";
            this.StartDownload.ShadowDecoration.Parent = this.StartDownload;
            this.StartDownload.Size = new System.Drawing.Size(180, 30);
            this.StartDownload.TabIndex = 32;
            this.StartDownload.Text = "Start";
            this.StartDownload.Click += new System.EventHandler(this.StartDownload_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(68, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 14);
            this.label5.TabIndex = 31;
            this.label5.Text = "Item Count:";
            // 
            // ItemTypeCombo
            // 
            this.ItemTypeCombo.BackColor = System.Drawing.Color.Transparent;
            this.ItemTypeCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ItemTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemTypeCombo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ItemTypeCombo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ItemTypeCombo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ItemTypeCombo.FocusedState.Parent = this.ItemTypeCombo;
            this.ItemTypeCombo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ItemTypeCombo.ForeColor = System.Drawing.Color.White;
            this.ItemTypeCombo.HoverState.Parent = this.ItemTypeCombo;
            this.ItemTypeCombo.ItemHeight = 30;
            this.ItemTypeCombo.Items.AddRange(new object[] {
            "ClassicShirts",
            "ClassicPants",
            "Audio",
            "Accessories"});
            this.ItemTypeCombo.ItemsAppearance.Parent = this.ItemTypeCombo;
            this.ItemTypeCombo.Location = new System.Drawing.Point(169, 26);
            this.ItemTypeCombo.Name = "ItemTypeCombo";
            this.ItemTypeCombo.ShadowDecoration.Parent = this.ItemTypeCombo;
            this.ItemTypeCombo.Size = new System.Drawing.Size(136, 36);
            this.ItemTypeCombo.StartIndex = 0;
            this.ItemTypeCombo.TabIndex = 30;
            this.ItemTypeCombo.SelectedIndexChanged += new System.EventHandler(this.ItemTypeCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(68, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 14);
            this.label4.TabIndex = 29;
            this.label4.Text = "Catalog Type: ";
            // 
            // FindLocation
            // 
            this.FindLocation.Animated = true;
            this.FindLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.FindLocation.BorderThickness = 1;
            this.FindLocation.CheckedState.Parent = this.FindLocation;
            this.FindLocation.CustomImages.Parent = this.FindLocation;
            this.FindLocation.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.FindLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FindLocation.ForeColor = System.Drawing.Color.White;
            this.FindLocation.HoverState.Parent = this.FindLocation;
            this.FindLocation.Location = new System.Drawing.Point(496, 134);
            this.FindLocation.Name = "FindLocation";
            this.FindLocation.ShadowDecoration.Parent = this.FindLocation;
            this.FindLocation.Size = new System.Drawing.Size(31, 22);
            this.FindLocation.TabIndex = 28;
            this.FindLocation.Text = "...";
            this.FindLocation.Click += new System.EventHandler(this.FindLocation_Click);
            // 
            // CustomIdLocBox
            // 
            this.CustomIdLocBox.Animated = true;
            this.CustomIdLocBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CustomIdLocBox.DefaultText = "";
            this.CustomIdLocBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CustomIdLocBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CustomIdLocBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomIdLocBox.DisabledState.Parent = this.CustomIdLocBox;
            this.CustomIdLocBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomIdLocBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CustomIdLocBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomIdLocBox.FocusedState.Parent = this.CustomIdLocBox;
            this.CustomIdLocBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CustomIdLocBox.ForeColor = System.Drawing.Color.White;
            this.CustomIdLocBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomIdLocBox.HoverState.Parent = this.CustomIdLocBox;
            this.CustomIdLocBox.Location = new System.Drawing.Point(168, 134);
            this.CustomIdLocBox.Name = "CustomIdLocBox";
            this.CustomIdLocBox.PasswordChar = '\0';
            this.CustomIdLocBox.PlaceholderText = "";
            this.CustomIdLocBox.ReadOnly = true;
            this.CustomIdLocBox.SelectedText = "";
            this.CustomIdLocBox.ShadowDecoration.Parent = this.CustomIdLocBox;
            this.CustomIdLocBox.Size = new System.Drawing.Size(322, 22);
            this.CustomIdLocBox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(59, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Custom ID List:";
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.Black;
            this.LogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LogBox.ForeColor = System.Drawing.Color.White;
            this.LogBox.Location = new System.Drawing.Point(5, 262);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(635, 91);
            this.LogBox.TabIndex = 1;
            this.LogBox.Text = "";
            this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(12, 14);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(220, 26);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Iris Asset Downloader";
            // 
            // RealAssetName
            // 
            this.RealAssetName.AutoSize = true;
            this.RealAssetName.ForeColor = System.Drawing.Color.White;
            this.RealAssetName.Location = new System.Drawing.Point(66, 207);
            this.RealAssetName.Name = "RealAssetName";
            this.RealAssetName.Size = new System.Drawing.Size(108, 17);
            this.RealAssetName.TabIndex = 45;
            this.RealAssetName.Text = "Get Asset Names";
            this.RealAssetName.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(169, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 46;
            this.comboBox1.Text = "1";
            // 
            // AssetDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(649, 365);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.HolderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AssetDownloader";
            this.Text = "AssetDownloader";
            this.Load += new System.EventHandler(this.AssetDownloader_Load);
            this.HolderPanel.ResumeLayout(false);
            this.HolderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HolderPanel;
        private Guna.UI2.WinForms.Guna2ProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox ManualIDCheck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox KeywordBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ItemCount;
        private System.Windows.Forms.ComboBox PageCountForAudio;
        private Guna.UI2.WinForms.Guna2Button StartDownload;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox ItemTypeCombo;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button FindLocation;
        private Guna.UI2.WinForms.Guna2TextBox CustomIdLocBox;
        private System.Windows.Forms.Label label3;
        private VertexFramework.UIControls.VRichTextBox LogBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.CheckBox RealAssetName;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}