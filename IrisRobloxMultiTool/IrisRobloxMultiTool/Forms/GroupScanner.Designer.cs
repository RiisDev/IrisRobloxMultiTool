namespace IrisRobloxMultiTool.Forms
{
    partial class GroupScanner
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
            this.KeywordBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SearchParamLabel = new System.Windows.Forms.Label();
            this.StartDownload = new Guna.UI2.WinForms.Guna2Button();
            this.HasFundsCheck = new System.Windows.Forms.CheckBox();
            this.JoinableCheck = new System.Windows.Forms.CheckBox();
            this.EmptyCheck = new System.Windows.Forms.CheckBox();
            this.StartIdBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.StartIdLabel = new System.Windows.Forms.Label();
            this.GroupsHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.GroupContext = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.openPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOBUXCOUNTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndIdBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EndIDLabel = new System.Windows.Forms.Label();
            this.UseSearchCheck = new System.Windows.Forms.CheckBox();
            this.WriteToFile = new System.Windows.Forms.CheckBox();
            this.UseProxies = new System.Windows.Forms.CheckBox();
            this.GroupContext.SuspendLayout();
            this.SuspendLayout();
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
            this.KeywordBox.Location = new System.Drawing.Point(293, 20);
            this.KeywordBox.Name = "KeywordBox";
            this.KeywordBox.PasswordChar = '\0';
            this.KeywordBox.PlaceholderText = "";
            this.KeywordBox.SelectedText = "";
            this.KeywordBox.ShadowDecoration.Parent = this.KeywordBox;
            this.KeywordBox.Size = new System.Drawing.Size(99, 22);
            this.KeywordBox.TabIndex = 40;
            // 
            // SearchParamLabel
            // 
            this.SearchParamLabel.AutoSize = true;
            this.SearchParamLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchParamLabel.ForeColor = System.Drawing.Color.White;
            this.SearchParamLabel.Location = new System.Drawing.Point(188, 23);
            this.SearchParamLabel.Name = "SearchParamLabel";
            this.SearchParamLabel.Size = new System.Drawing.Size(105, 14);
            this.SearchParamLabel.TabIndex = 39;
            this.SearchParamLabel.Text = "Search Param:";
            // 
            // StartDownload
            // 
            this.StartDownload.CheckedState.Parent = this.StartDownload;
            this.StartDownload.CustomImages.Parent = this.StartDownload;
            this.StartDownload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.StartDownload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartDownload.ForeColor = System.Drawing.Color.White;
            this.StartDownload.HoverState.Parent = this.StartDownload;
            this.StartDownload.Location = new System.Drawing.Point(212, 58);
            this.StartDownload.Name = "StartDownload";
            this.StartDownload.ShadowDecoration.Parent = this.StartDownload;
            this.StartDownload.Size = new System.Drawing.Size(180, 30);
            this.StartDownload.TabIndex = 41;
            this.StartDownload.Text = "Start";
            this.StartDownload.Click += new System.EventHandler(this.StartDownload_Click);
            // 
            // HasFundsCheck
            // 
            this.HasFundsCheck.AutoSize = true;
            this.HasFundsCheck.ForeColor = System.Drawing.Color.White;
            this.HasFundsCheck.Location = new System.Drawing.Point(398, 23);
            this.HasFundsCheck.Name = "HasFundsCheck";
            this.HasFundsCheck.Size = new System.Drawing.Size(77, 17);
            this.HasFundsCheck.TabIndex = 42;
            this.HasFundsCheck.Text = "Has Funds";
            this.HasFundsCheck.UseVisualStyleBackColor = true;
            // 
            // JoinableCheck
            // 
            this.JoinableCheck.AutoSize = true;
            this.JoinableCheck.ForeColor = System.Drawing.Color.White;
            this.JoinableCheck.Location = new System.Drawing.Point(481, 23);
            this.JoinableCheck.Name = "JoinableCheck";
            this.JoinableCheck.Size = new System.Drawing.Size(65, 17);
            this.JoinableCheck.TabIndex = 43;
            this.JoinableCheck.Text = "Joinable";
            this.JoinableCheck.UseVisualStyleBackColor = true;
            // 
            // EmptyCheck
            // 
            this.EmptyCheck.AutoSize = true;
            this.EmptyCheck.ForeColor = System.Drawing.Color.White;
            this.EmptyCheck.Location = new System.Drawing.Point(552, 23);
            this.EmptyCheck.Name = "EmptyCheck";
            this.EmptyCheck.Size = new System.Drawing.Size(79, 17);
            this.EmptyCheck.TabIndex = 44;
            this.EmptyCheck.Text = "Empty (0-3)";
            this.EmptyCheck.UseVisualStyleBackColor = true;
            // 
            // StartIdBox
            // 
            this.StartIdBox.Animated = true;
            this.StartIdBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.StartIdBox.DefaultText = "";
            this.StartIdBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.StartIdBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.StartIdBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.StartIdBox.DisabledState.Parent = this.StartIdBox;
            this.StartIdBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.StartIdBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.StartIdBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.StartIdBox.FocusedState.Parent = this.StartIdBox;
            this.StartIdBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartIdBox.ForeColor = System.Drawing.Color.White;
            this.StartIdBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.StartIdBox.HoverState.Parent = this.StartIdBox;
            this.StartIdBox.Location = new System.Drawing.Point(83, 18);
            this.StartIdBox.Name = "StartIdBox";
            this.StartIdBox.PasswordChar = '\0';
            this.StartIdBox.PlaceholderText = "";
            this.StartIdBox.SelectedText = "";
            this.StartIdBox.ShadowDecoration.Parent = this.StartIdBox;
            this.StartIdBox.Size = new System.Drawing.Size(99, 22);
            this.StartIdBox.TabIndex = 46;
            this.StartIdBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartIdBox_KeyPress);
            // 
            // StartIdLabel
            // 
            this.StartIdLabel.AutoSize = true;
            this.StartIdLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartIdLabel.ForeColor = System.Drawing.Color.White;
            this.StartIdLabel.Location = new System.Drawing.Point(12, 23);
            this.StartIdLabel.Name = "StartIdLabel";
            this.StartIdLabel.Size = new System.Drawing.Size(65, 14);
            this.StartIdLabel.TabIndex = 45;
            this.StartIdLabel.Text = "Start ID:";
            // 
            // GroupsHolder
            // 
            this.GroupsHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GroupsHolder.Location = new System.Drawing.Point(5, 125);
            this.GroupsHolder.Name = "GroupsHolder";
            this.GroupsHolder.Size = new System.Drawing.Size(642, 236);
            this.GroupsHolder.TabIndex = 48;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(10, 108);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(188, 26);
            this.TitleLabel.TabIndex = 49;
            this.TitleLabel.Text = "Iris Group Scanner";
            // 
            // ProgressBar
            // 
            this.ProgressBar.FillColor = System.Drawing.Color.LightGray;
            this.ProgressBar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressBar.ForeColor = System.Drawing.Color.Black;
            this.ProgressBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.ProgressBar.Location = new System.Drawing.Point(154, 94);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(155)))), ((int)(((byte)(251)))));
            this.ProgressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            this.ProgressBar.ShadowDecoration.Parent = this.ProgressBar;
            this.ProgressBar.ShowPercentage = true;
            this.ProgressBar.Size = new System.Drawing.Size(300, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 50;
            this.ProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // GroupContext
            // 
            this.GroupContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.GroupContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPageToolStripMenuItem,
            this.joinToolStripMenuItem,
            this.rOBUXCOUNTToolStripMenuItem});
            this.GroupContext.Name = "GroupContext";
            this.GroupContext.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.GroupContext.RenderStyle.BorderColor = System.Drawing.Color.White;
            this.GroupContext.RenderStyle.ColorTable = null;
            this.GroupContext.RenderStyle.RoundedEdges = true;
            this.GroupContext.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.GroupContext.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GroupContext.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GroupContext.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.GroupContext.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.GroupContext.Size = new System.Drawing.Size(158, 70);
            // 
            // openPageToolStripMenuItem
            // 
            this.openPageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openPageToolStripMenuItem.Name = "openPageToolStripMenuItem";
            this.openPageToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openPageToolStripMenuItem.Text = "Open Page";
            // 
            // joinToolStripMenuItem
            // 
            this.joinToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.joinToolStripMenuItem.Name = "joinToolStripMenuItem";
            this.joinToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.joinToolStripMenuItem.Text = "Join";
            // 
            // rOBUXCOUNTToolStripMenuItem
            // 
            this.rOBUXCOUNTToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.rOBUXCOUNTToolStripMenuItem.Name = "rOBUXCOUNTToolStripMenuItem";
            this.rOBUXCOUNTToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.rOBUXCOUNTToolStripMenuItem.Text = "ROBUX_COUNT";
            // 
            // EndIdBox
            // 
            this.EndIdBox.Animated = true;
            this.EndIdBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EndIdBox.DefaultText = "";
            this.EndIdBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EndIdBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EndIdBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EndIdBox.DisabledState.Parent = this.EndIdBox;
            this.EndIdBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EndIdBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.EndIdBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EndIdBox.FocusedState.Parent = this.EndIdBox;
            this.EndIdBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EndIdBox.ForeColor = System.Drawing.Color.White;
            this.EndIdBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EndIdBox.HoverState.Parent = this.EndIdBox;
            this.EndIdBox.Location = new System.Drawing.Point(83, 53);
            this.EndIdBox.Name = "EndIdBox";
            this.EndIdBox.PasswordChar = '\0';
            this.EndIdBox.PlaceholderText = "";
            this.EndIdBox.SelectedText = "";
            this.EndIdBox.ShadowDecoration.Parent = this.EndIdBox;
            this.EndIdBox.Size = new System.Drawing.Size(99, 22);
            this.EndIdBox.TabIndex = 53;
            this.EndIdBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartIdBox_KeyPress);
            // 
            // EndIDLabel
            // 
            this.EndIDLabel.AutoSize = true;
            this.EndIDLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndIDLabel.ForeColor = System.Drawing.Color.White;
            this.EndIDLabel.Location = new System.Drawing.Point(19, 58);
            this.EndIDLabel.Name = "EndIDLabel";
            this.EndIDLabel.Size = new System.Drawing.Size(56, 14);
            this.EndIDLabel.TabIndex = 52;
            this.EndIDLabel.Text = "End ID:";
            // 
            // UseSearchCheck
            // 
            this.UseSearchCheck.AutoSize = true;
            this.UseSearchCheck.ForeColor = System.Drawing.Color.White;
            this.UseSearchCheck.Location = new System.Drawing.Point(398, 49);
            this.UseSearchCheck.Name = "UseSearchCheck";
            this.UseSearchCheck.Size = new System.Drawing.Size(82, 17);
            this.UseSearchCheck.TabIndex = 54;
            this.UseSearchCheck.Text = "Use Search";
            this.UseSearchCheck.UseVisualStyleBackColor = true;
            // 
            // WriteToFile
            // 
            this.WriteToFile.AutoSize = true;
            this.WriteToFile.ForeColor = System.Drawing.Color.White;
            this.WriteToFile.Location = new System.Drawing.Point(481, 49);
            this.WriteToFile.Name = "WriteToFile";
            this.WriteToFile.Size = new System.Drawing.Size(140, 17);
            this.WriteToFile.TabIndex = 55;
            this.WriteToFile.Text = "Write to file **FASTER**";
            this.WriteToFile.UseVisualStyleBackColor = true;
            // 
            // UseProxies
            // 
            this.UseProxies.AutoSize = true;
            this.UseProxies.ForeColor = System.Drawing.Color.DarkGray;
            this.UseProxies.Location = new System.Drawing.Point(398, 72);
            this.UseProxies.Name = "UseProxies";
            this.UseProxies.Size = new System.Drawing.Size(132, 17);
            this.UseProxies.TabIndex = 56;
            this.UseProxies.Text = "Use Proxies (Disabled)";
            this.UseProxies.UseVisualStyleBackColor = true;
            this.UseProxies.CheckedChanged += new System.EventHandler(this.UseProxies_CheckedChanged);
            // 
            // GroupScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(649, 365);
            this.Controls.Add(this.UseProxies);
            this.Controls.Add(this.WriteToFile);
            this.Controls.Add(this.UseSearchCheck);
            this.Controls.Add(this.EndIdBox);
            this.Controls.Add(this.EndIDLabel);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.GroupsHolder);
            this.Controls.Add(this.StartIdBox);
            this.Controls.Add(this.StartIdLabel);
            this.Controls.Add(this.EmptyCheck);
            this.Controls.Add(this.JoinableCheck);
            this.Controls.Add(this.HasFundsCheck);
            this.Controls.Add(this.StartDownload);
            this.Controls.Add(this.KeywordBox);
            this.Controls.Add(this.SearchParamLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GroupScanner";
            this.Text = "GroupScanner";
            this.Load += new System.EventHandler(this.GroupScanner_Load);
            this.GroupContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox KeywordBox;
        private System.Windows.Forms.Label SearchParamLabel;
        private Guna.UI2.WinForms.Guna2Button StartDownload;
        private System.Windows.Forms.CheckBox HasFundsCheck;
        private System.Windows.Forms.CheckBox JoinableCheck;
        private System.Windows.Forms.CheckBox EmptyCheck;
        private Guna.UI2.WinForms.Guna2TextBox StartIdBox;
        private System.Windows.Forms.Label StartIdLabel;
        private System.Windows.Forms.FlowLayoutPanel GroupsHolder;
        private System.Windows.Forms.Label TitleLabel;
        private Guna.UI2.WinForms.Guna2ProgressBar ProgressBar;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip GroupContext;
        private System.Windows.Forms.ToolStripMenuItem openPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOBUXCOUNTToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2TextBox EndIdBox;
        private System.Windows.Forms.Label EndIDLabel;
        private System.Windows.Forms.CheckBox UseSearchCheck;
        private System.Windows.Forms.CheckBox WriteToFile;
        private System.Windows.Forms.CheckBox UseProxies;
    }
}