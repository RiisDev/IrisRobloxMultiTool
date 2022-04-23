namespace IrisRobloxMultiTool.Forms
{
    partial class AssetFavouriteBot
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
            this.StatusPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.Status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.KeywordBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.StartDownload = new Guna.UI2.WinForms.Guna2Button();
            this.FindLocation = new Guna.UI2.WinForms.Guna2Button();
            this.CustomIdLocBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.HolderPanel.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HolderPanel
            // 
            this.HolderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HolderPanel.Controls.Add(this.StatusPanel);
            this.HolderPanel.Controls.Add(this.ProgressBar);
            this.HolderPanel.Controls.Add(this.KeywordBox);
            this.HolderPanel.Controls.Add(this.label7);
            this.HolderPanel.Controls.Add(this.StartDownload);
            this.HolderPanel.Controls.Add(this.FindLocation);
            this.HolderPanel.Controls.Add(this.CustomIdLocBox);
            this.HolderPanel.Controls.Add(this.label3);
            this.HolderPanel.Location = new System.Drawing.Point(12, 12);
            this.HolderPanel.Name = "HolderPanel";
            this.HolderPanel.Size = new System.Drawing.Size(623, 341);
            this.HolderPanel.TabIndex = 1;
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.Transparent;
            this.StatusPanel.Controls.Add(this.Status);
            this.StatusPanel.Controls.Add(this.label1);
            this.StatusPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.StatusPanel.Location = new System.Drawing.Point(414, 267);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.ShadowColor = System.Drawing.Color.Black;
            this.StatusPanel.Size = new System.Drawing.Size(204, 69);
            this.StatusPanel.TabIndex = 47;
            // 
            // Status
            // 
            this.Status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Status.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(154)))), ((int)(((byte)(249)))));
            this.Status.Location = new System.Drawing.Point(0, 31);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.Status.Size = new System.Drawing.Size(204, 38);
            this.Status.TabIndex = 4;
            this.Status.Text = "Checking...";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Favouriter Status";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar
            // 
            this.ProgressBar.FillColor = System.Drawing.Color.LightGray;
            this.ProgressBar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressBar.ForeColor = System.Drawing.Color.Black;
            this.ProgressBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.ProgressBar.Location = new System.Drawing.Point(165, 156);
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
            this.KeywordBox.Location = new System.Drawing.Point(251, 87);
            this.KeywordBox.Name = "KeywordBox";
            this.KeywordBox.PasswordChar = '\0';
            this.KeywordBox.PlaceholderText = "";
            this.KeywordBox.SelectedText = "";
            this.KeywordBox.ShadowDecoration.Parent = this.KeywordBox;
            this.KeywordBox.Size = new System.Drawing.Size(107, 22);
            this.KeywordBox.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(177, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 14);
            this.label7.TabIndex = 37;
            this.label7.Text = "Asset ID:";
            // 
            // StartDownload
            // 
            this.StartDownload.CheckedState.Parent = this.StartDownload;
            this.StartDownload.CustomImages.Parent = this.StartDownload;
            this.StartDownload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.StartDownload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartDownload.ForeColor = System.Drawing.Color.White;
            this.StartDownload.HoverState.Parent = this.StartDownload;
            this.StartDownload.Location = new System.Drawing.Point(218, 182);
            this.StartDownload.Name = "StartDownload";
            this.StartDownload.ShadowDecoration.Parent = this.StartDownload;
            this.StartDownload.Size = new System.Drawing.Size(180, 30);
            this.StartDownload.TabIndex = 32;
            this.StartDownload.Text = "Start";
            this.StartDownload.Click += new System.EventHandler(this.StartDownload_Click);
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
            this.FindLocation.Location = new System.Drawing.Point(477, 124);
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
            this.CustomIdLocBox.Location = new System.Drawing.Point(149, 124);
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
            this.label3.Location = new System.Drawing.Point(81, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Cookies: ";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(6, 2);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(233, 26);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Iris Asset Favourite Bot";
            // 
            // AssetFavouriteBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(649, 365);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.HolderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AssetFavouriteBot";
            this.Text = "AssetFavouriteBot";
            this.Load += new System.EventHandler(this.AssetFavouriteBot_Load);
            this.HolderPanel.ResumeLayout(false);
            this.HolderPanel.PerformLayout();
            this.StatusPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HolderPanel;
        private Guna.UI2.WinForms.Guna2ShadowPanel StatusPanel;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ProgressBar ProgressBar;
        private Guna.UI2.WinForms.Guna2TextBox KeywordBox;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button StartDownload;
        private Guna.UI2.WinForms.Guna2Button FindLocation;
        private Guna.UI2.WinForms.Guna2TextBox CustomIdLocBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TitleLabel;
    }
}