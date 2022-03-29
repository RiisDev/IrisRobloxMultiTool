namespace IrisRobloxMultiTool
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.TopBar = new System.Windows.Forms.Panel();
            this.UpdAv = new System.Windows.Forms.Label();
            this.MinimizeButton = new Guna.UI2.WinForms.Guna2Button();
            this.CloseButton = new Guna.UI2.WinForms.Guna2Button();
            this.Title = new System.Windows.Forms.Label();
            this.TabPageButtons = new System.Windows.Forms.Panel();
            this.ButtonHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.HomeButton = new Guna.UI2.WinForms.Guna2Button();
            this.AssetDownloaderButton = new Guna.UI2.WinForms.Guna2Button();
            this.GroupScannerButton = new Guna.UI2.WinForms.Guna2Button();
            this.WeAreDevsKeygenButton = new Guna.UI2.WinForms.Guna2Button();
            this.ToolDownloader = new Guna.UI2.WinForms.Guna2Button();
            this.IrisStuff = new Guna.UI2.WinForms.Guna2Button();
            this.SupportMeButton = new Guna.UI2.WinForms.Guna2Button();
            this.LogOutButton = new Guna.UI2.WinForms.Guna2Button();
            this.UserInfoHolder = new System.Windows.Forms.Panel();
            this.Username = new System.Windows.Forms.LinkLabel();
            this.Robux = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Verified = new Guna.UI2.WinForms.Guna2PictureBox();
            this.RobuxText = new System.Windows.Forms.Label();
            this.UserPFP = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.FormHolder = new System.Windows.Forms.Panel();
            this.TopBar.SuspendLayout();
            this.TabPageButtons.SuspendLayout();
            this.ButtonHolder.SuspendLayout();
            this.UserInfoHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Robux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Verified)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPFP)).BeginInit();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TopBar.Controls.Add(this.UpdAv);
            this.TopBar.Controls.Add(this.MinimizeButton);
            this.TopBar.Controls.Add(this.CloseButton);
            this.TopBar.Controls.Add(this.Title);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(845, 26);
            this.TopBar.TabIndex = 0;
            // 
            // UpdAv
            // 
            this.UpdAv.AutoSize = true;
            this.UpdAv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.UpdAv.Location = new System.Drawing.Point(188, 6);
            this.UpdAv.Name = "UpdAv";
            this.UpdAv.Size = new System.Drawing.Size(108, 13);
            this.UpdAv.TabIndex = 3;
            this.UpdAv.Text = "* Update(s) available!";
            this.UpdAv.Visible = false;
            this.UpdAv.Click += new System.EventHandler(this.label1_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Animated = true;
            this.MinimizeButton.CheckedState.Parent = this.MinimizeButton;
            this.MinimizeButton.CustomImages.Parent = this.MinimizeButton;
            this.MinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.MinimizeButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeButton.ForeColor = System.Drawing.Color.White;
            this.MinimizeButton.HoverState.Parent = this.MinimizeButton;
            this.MinimizeButton.Location = new System.Drawing.Point(793, 0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.ShadowDecoration.Parent = this.MinimizeButton;
            this.MinimizeButton.Size = new System.Drawing.Size(26, 26);
            this.MinimizeButton.TabIndex = 2;
            this.MinimizeButton.Text = "─";
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Animated = true;
            this.CloseButton.CheckedState.Parent = this.CloseButton;
            this.CloseButton.CustomImages.Parent = this.CloseButton;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CloseButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.HoverState.Parent = this.CloseButton;
            this.CloseButton.Location = new System.Drawing.Point(819, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.ShadowDecoration.Parent = this.CloseButton;
            this.CloseButton.Size = new System.Drawing.Size(26, 26);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "✕";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(2, 2);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(180, 19);
            this.Title.TabIndex = 0;
            this.Title.Text = "Iris\'s Roblox Multi Tool";
            // 
            // TabPageButtons
            // 
            this.TabPageButtons.Controls.Add(this.ButtonHolder);
            this.TabPageButtons.Controls.Add(this.SupportMeButton);
            this.TabPageButtons.Controls.Add(this.LogOutButton);
            this.TabPageButtons.Controls.Add(this.UserInfoHolder);
            this.TabPageButtons.Location = new System.Drawing.Point(1, 26);
            this.TabPageButtons.Name = "TabPageButtons";
            this.TabPageButtons.Size = new System.Drawing.Size(190, 365);
            this.TabPageButtons.TabIndex = 1;
            // 
            // ButtonHolder
            // 
            this.ButtonHolder.AutoSize = true;
            this.ButtonHolder.Controls.Add(this.HomeButton);
            this.ButtonHolder.Controls.Add(this.AssetDownloaderButton);
            this.ButtonHolder.Controls.Add(this.GroupScannerButton);
            this.ButtonHolder.Controls.Add(this.WeAreDevsKeygenButton);
            this.ButtonHolder.Controls.Add(this.ToolDownloader);
            this.ButtonHolder.Controls.Add(this.IrisStuff);
            this.ButtonHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHolder.Location = new System.Drawing.Point(0, 57);
            this.ButtonHolder.Name = "ButtonHolder";
            this.ButtonHolder.Size = new System.Drawing.Size(190, 218);
            this.ButtonHolder.TabIndex = 7;
            // 
            // HomeButton
            // 
            this.HomeButton.Animated = true;
            this.HomeButton.CheckedState.Parent = this.HomeButton;
            this.HomeButton.CustomImages.Parent = this.HomeButton;
            this.HomeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.HomeButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.HomeButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.HoverState.Parent = this.HomeButton;
            this.HomeButton.Image = global::IrisRobloxMultiTool.Properties.Resources.Home;
            this.HomeButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.HomeButton.ImageSize = new System.Drawing.Size(33, 33);
            this.HomeButton.Location = new System.Drawing.Point(3, 3);
            this.HomeButton.MaximumSize = new System.Drawing.Size(170, 45);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.ShadowDecoration.Parent = this.HomeButton;
            this.HomeButton.Size = new System.Drawing.Size(170, 45);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "Home Page";
            this.HomeButton.TextOffset = new System.Drawing.Point(5, 0);
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // AssetDownloaderButton
            // 
            this.AssetDownloaderButton.Animated = true;
            this.AssetDownloaderButton.CheckedState.Parent = this.AssetDownloaderButton;
            this.AssetDownloaderButton.CustomImages.Parent = this.AssetDownloaderButton;
            this.AssetDownloaderButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AssetDownloaderButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.AssetDownloaderButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssetDownloaderButton.ForeColor = System.Drawing.Color.White;
            this.AssetDownloaderButton.HoverState.Parent = this.AssetDownloaderButton;
            this.AssetDownloaderButton.Image = global::IrisRobloxMultiTool.Properties.Resources.Download;
            this.AssetDownloaderButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AssetDownloaderButton.ImageSize = new System.Drawing.Size(33, 33);
            this.AssetDownloaderButton.Location = new System.Drawing.Point(3, 54);
            this.AssetDownloaderButton.MaximumSize = new System.Drawing.Size(170, 45);
            this.AssetDownloaderButton.Name = "AssetDownloaderButton";
            this.AssetDownloaderButton.ShadowDecoration.Parent = this.AssetDownloaderButton;
            this.AssetDownloaderButton.Size = new System.Drawing.Size(170, 45);
            this.AssetDownloaderButton.TabIndex = 4;
            this.AssetDownloaderButton.Text = "Asset Downloader";
            this.AssetDownloaderButton.TextOffset = new System.Drawing.Point(20, 0);
            this.AssetDownloaderButton.Click += new System.EventHandler(this.AssetDownloaderButton_Click);
            // 
            // GroupScannerButton
            // 
            this.GroupScannerButton.Animated = true;
            this.GroupScannerButton.CheckedState.Parent = this.GroupScannerButton;
            this.GroupScannerButton.CustomImages.Parent = this.GroupScannerButton;
            this.GroupScannerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupScannerButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.GroupScannerButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupScannerButton.ForeColor = System.Drawing.Color.White;
            this.GroupScannerButton.HoverState.Parent = this.GroupScannerButton;
            this.GroupScannerButton.Image = global::IrisRobloxMultiTool.Properties.Resources.People;
            this.GroupScannerButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GroupScannerButton.ImageSize = new System.Drawing.Size(33, 33);
            this.GroupScannerButton.Location = new System.Drawing.Point(3, 105);
            this.GroupScannerButton.MaximumSize = new System.Drawing.Size(170, 45);
            this.GroupScannerButton.Name = "GroupScannerButton";
            this.GroupScannerButton.ShadowDecoration.Parent = this.GroupScannerButton;
            this.GroupScannerButton.Size = new System.Drawing.Size(170, 45);
            this.GroupScannerButton.TabIndex = 6;
            this.GroupScannerButton.Text = "Group Scanner";
            this.GroupScannerButton.TextOffset = new System.Drawing.Point(22, 0);
            this.GroupScannerButton.Click += new System.EventHandler(this.GroupScannerButton_Click);
            // 
            // WeAreDevsKeygenButton
            // 
            this.WeAreDevsKeygenButton.Animated = true;
            this.WeAreDevsKeygenButton.CheckedState.Parent = this.WeAreDevsKeygenButton;
            this.WeAreDevsKeygenButton.CustomImages.Parent = this.WeAreDevsKeygenButton;
            this.WeAreDevsKeygenButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.WeAreDevsKeygenButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.WeAreDevsKeygenButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeAreDevsKeygenButton.ForeColor = System.Drawing.Color.White;
            this.WeAreDevsKeygenButton.HoverState.Parent = this.WeAreDevsKeygenButton;
            this.WeAreDevsKeygenButton.Image = global::IrisRobloxMultiTool.Properties.Resources.Key;
            this.WeAreDevsKeygenButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.WeAreDevsKeygenButton.ImageSize = new System.Drawing.Size(33, 33);
            this.WeAreDevsKeygenButton.Location = new System.Drawing.Point(3, 156);
            this.WeAreDevsKeygenButton.MaximumSize = new System.Drawing.Size(170, 45);
            this.WeAreDevsKeygenButton.Name = "WeAreDevsKeygenButton";
            this.WeAreDevsKeygenButton.ShadowDecoration.Parent = this.WeAreDevsKeygenButton;
            this.WeAreDevsKeygenButton.Size = new System.Drawing.Size(170, 45);
            this.WeAreDevsKeygenButton.TabIndex = 7;
            this.WeAreDevsKeygenButton.Text = "WRD Keygen";
            this.WeAreDevsKeygenButton.TextOffset = new System.Drawing.Point(15, 0);
            this.WeAreDevsKeygenButton.Click += new System.EventHandler(this.WeAreDevsKeygenButton_Click);
            // 
            // ToolDownloader
            // 
            this.ToolDownloader.Animated = true;
            this.ToolDownloader.CheckedState.Parent = this.ToolDownloader;
            this.ToolDownloader.CustomImages.Parent = this.ToolDownloader;
            this.ToolDownloader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolDownloader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ToolDownloader.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolDownloader.ForeColor = System.Drawing.Color.White;
            this.ToolDownloader.HoverState.Parent = this.ToolDownloader;
            this.ToolDownloader.Image = global::IrisRobloxMultiTool.Properties.Resources.Tools;
            this.ToolDownloader.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ToolDownloader.ImageSize = new System.Drawing.Size(33, 33);
            this.ToolDownloader.Location = new System.Drawing.Point(3, 207);
            this.ToolDownloader.MaximumSize = new System.Drawing.Size(170, 45);
            this.ToolDownloader.Name = "ToolDownloader";
            this.ToolDownloader.ShadowDecoration.Parent = this.ToolDownloader;
            this.ToolDownloader.Size = new System.Drawing.Size(170, 45);
            this.ToolDownloader.TabIndex = 8;
            this.ToolDownloader.Text = "Tool Downloads";
            this.ToolDownloader.TextOffset = new System.Drawing.Point(15, 0);
            this.ToolDownloader.Click += new System.EventHandler(this.ToolDownloader_Click);
            // 
            // IrisStuff
            // 
            this.IrisStuff.Animated = true;
            this.IrisStuff.CheckedState.Parent = this.IrisStuff;
            this.IrisStuff.CustomImages.Parent = this.IrisStuff;
            this.IrisStuff.Dock = System.Windows.Forms.DockStyle.Top;
            this.IrisStuff.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.IrisStuff.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IrisStuff.ForeColor = System.Drawing.Color.White;
            this.IrisStuff.HoverState.Parent = this.IrisStuff;
            this.IrisStuff.Image = global::IrisRobloxMultiTool.Properties.Resources.ForIris2White;
            this.IrisStuff.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IrisStuff.ImageSize = new System.Drawing.Size(33, 33);
            this.IrisStuff.Location = new System.Drawing.Point(3, 258);
            this.IrisStuff.MaximumSize = new System.Drawing.Size(170, 45);
            this.IrisStuff.Name = "IrisStuff";
            this.IrisStuff.ShadowDecoration.Parent = this.IrisStuff;
            this.IrisStuff.Size = new System.Drawing.Size(170, 45);
            this.IrisStuff.TabIndex = 9;
            this.IrisStuff.Text = "iris Stuff";
            this.IrisStuff.TextOffset = new System.Drawing.Point(15, 0);
            this.IrisStuff.Visible = false;
            this.IrisStuff.Click += new System.EventHandler(this.IrisStuff_Click);
            // 
            // SupportMeButton
            // 
            this.SupportMeButton.Animated = true;
            this.SupportMeButton.CheckedState.Parent = this.SupportMeButton;
            this.SupportMeButton.CustomImages.Parent = this.SupportMeButton;
            this.SupportMeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SupportMeButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.SupportMeButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupportMeButton.ForeColor = System.Drawing.Color.White;
            this.SupportMeButton.HoverState.Parent = this.SupportMeButton;
            this.SupportMeButton.Image = global::IrisRobloxMultiTool.Properties.Resources.Smile;
            this.SupportMeButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SupportMeButton.ImageSize = new System.Drawing.Size(33, 33);
            this.SupportMeButton.Location = new System.Drawing.Point(0, 275);
            this.SupportMeButton.Name = "SupportMeButton";
            this.SupportMeButton.ShadowDecoration.Parent = this.SupportMeButton;
            this.SupportMeButton.Size = new System.Drawing.Size(190, 45);
            this.SupportMeButton.TabIndex = 5;
            this.SupportMeButton.Text = "Support Me!";
            this.SupportMeButton.TextOffset = new System.Drawing.Point(10, 0);
            this.SupportMeButton.Click += new System.EventHandler(this.SupportMe_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.Animated = true;
            this.LogOutButton.CheckedState.Parent = this.LogOutButton;
            this.LogOutButton.CustomImages.Parent = this.LogOutButton;
            this.LogOutButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogOutButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.HoverState.Parent = this.LogOutButton;
            this.LogOutButton.Image = global::IrisRobloxMultiTool.Properties.Resources.Logout;
            this.LogOutButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.LogOutButton.ImageSize = new System.Drawing.Size(33, 33);
            this.LogOutButton.Location = new System.Drawing.Point(0, 320);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.ShadowDecoration.Parent = this.LogOutButton;
            this.LogOutButton.Size = new System.Drawing.Size(190, 45);
            this.LogOutButton.TabIndex = 3;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // UserInfoHolder
            // 
            this.UserInfoHolder.Controls.Add(this.Username);
            this.UserInfoHolder.Controls.Add(this.Robux);
            this.UserInfoHolder.Controls.Add(this.Verified);
            this.UserInfoHolder.Controls.Add(this.RobuxText);
            this.UserInfoHolder.Controls.Add(this.UserPFP);
            this.UserInfoHolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserInfoHolder.Location = new System.Drawing.Point(0, 0);
            this.UserInfoHolder.Name = "UserInfoHolder";
            this.UserInfoHolder.Size = new System.Drawing.Size(190, 57);
            this.UserInfoHolder.TabIndex = 2;
            // 
            // Username
            // 
            this.Username.ActiveLinkColor = System.Drawing.Color.White;
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.LinkColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(57, 3);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(59, 18);
            this.Username.TabIndex = 6;
            this.Username.TabStop = true;
            this.Username.Text = "lrisDev";
            this.Username.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // Robux
            // 
            this.Robux.FillColor = System.Drawing.Color.Lime;
            this.Robux.Image = global::IrisRobloxMultiTool.Properties.Resources.Robux1;
            this.Robux.Location = new System.Drawing.Point(82, 24);
            this.Robux.Name = "Robux";
            this.Robux.ShadowDecoration.Parent = this.Robux;
            this.Robux.Size = new System.Drawing.Size(21, 21);
            this.Robux.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Robux.TabIndex = 5;
            this.Robux.TabStop = false;
            // 
            // Verified
            // 
            this.Verified.Image = ((System.Drawing.Image)(resources.GetObject("Verified.Image")));
            this.Verified.Location = new System.Drawing.Point(55, 24);
            this.Verified.Name = "Verified";
            this.Verified.ShadowDecoration.Parent = this.Verified;
            this.Verified.Size = new System.Drawing.Size(21, 21);
            this.Verified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Verified.TabIndex = 3;
            this.Verified.TabStop = false;
            // 
            // RobuxText
            // 
            this.RobuxText.AutoSize = true;
            this.RobuxText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RobuxText.ForeColor = System.Drawing.Color.Green;
            this.RobuxText.Location = new System.Drawing.Point(109, 27);
            this.RobuxText.Name = "RobuxText";
            this.RobuxText.Size = new System.Drawing.Size(28, 15);
            this.RobuxText.TabIndex = 2;
            this.RobuxText.Text = "850";
            // 
            // UserPFP
            // 
            this.UserPFP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.UserPFP.Location = new System.Drawing.Point(3, 3);
            this.UserPFP.Name = "UserPFP";
            this.UserPFP.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.UserPFP.ShadowDecoration.Parent = this.UserPFP;
            this.UserPFP.Size = new System.Drawing.Size(48, 48);
            this.UserPFP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPFP.TabIndex = 0;
            this.UserPFP.TabStop = false;
            // 
            // DragControl
            // 
            this.DragControl.TargetControl = this.TopBar;
            this.DragControl.UseTransparentDrag = true;
            // 
            // FormHolder
            // 
            this.FormHolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.FormHolder.Location = new System.Drawing.Point(196, 26);
            this.FormHolder.Name = "FormHolder";
            this.FormHolder.Size = new System.Drawing.Size(649, 365);
            this.FormHolder.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(845, 391);
            this.Controls.Add(this.FormHolder);
            this.Controls.Add(this.TabPageButtons);
            this.Controls.Add(this.TopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.TabPageButtons.ResumeLayout(false);
            this.TabPageButtons.PerformLayout();
            this.ButtonHolder.ResumeLayout(false);
            this.UserInfoHolder.ResumeLayout(false);
            this.UserInfoHolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Robux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Verified)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPFP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopBar;
        private System.Windows.Forms.Panel TabPageButtons;
        private System.Windows.Forms.Panel UserInfoHolder;
        private Guna.UI2.WinForms.Guna2PictureBox Verified;
        private System.Windows.Forms.Label RobuxText;
        private Guna.UI2.WinForms.Guna2CirclePictureBox UserPFP;
        private Guna.UI2.WinForms.Guna2PictureBox Robux;
        private System.Windows.Forms.LinkLabel Username;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private Guna.UI2.WinForms.Guna2Button HomeButton;
        private Guna.UI2.WinForms.Guna2Button LogOutButton;
        private Guna.UI2.WinForms.Guna2Button MinimizeButton;
        private Guna.UI2.WinForms.Guna2Button CloseButton;
        private System.Windows.Forms.Label Title;
        private Guna.UI2.WinForms.Guna2Button AssetDownloaderButton;
        private Guna.UI2.WinForms.Guna2Button SupportMeButton;
        private Guna.UI2.WinForms.Guna2Button GroupScannerButton;
        private System.Windows.Forms.Panel FormHolder;
        private System.Windows.Forms.FlowLayoutPanel ButtonHolder;
        private Guna.UI2.WinForms.Guna2Button WeAreDevsKeygenButton;
        private Guna.UI2.WinForms.Guna2Button ToolDownloader;
        private Guna.UI2.WinForms.Guna2Button IrisStuff;
        private System.Windows.Forms.Label UpdAv;
    }
}

