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
            this.TabPageButtons = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.UserInfoHolder = new System.Windows.Forms.Panel();
            this.Robux = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Verified = new Guna.UI2.WinForms.Guna2PictureBox();
            this.RobuxText = new System.Windows.Forms.Label();
            this.UserPFP = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.Username = new System.Windows.Forms.LinkLabel();
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.TabPageButtons.SuspendLayout();
            this.UserInfoHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Robux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Verified)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPFP)).BeginInit();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(727, 26);
            this.TopBar.TabIndex = 0;
            // 
            // TabPageButtons
            // 
            this.TabPageButtons.Controls.Add(this.guna2Button1);
            this.TabPageButtons.Controls.Add(this.UserInfoHolder);
            this.TabPageButtons.Location = new System.Drawing.Point(0, 32);
            this.TabPageButtons.Name = "TabPageButtons";
            this.TabPageButtons.Size = new System.Drawing.Size(186, 401);
            this.TabPageButtons.TabIndex = 1;
            // 
            // guna2Button1
            // 
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(0, 57);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(186, 45);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "guna2Button1";
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
            this.UserInfoHolder.Size = new System.Drawing.Size(186, 57);
            this.UserInfoHolder.TabIndex = 2;
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
            // DragControl
            // 
            this.DragControl.TargetControl = this.TopBar;
            this.DragControl.UseTransparentDrag = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(727, 434);
            this.Controls.Add(this.TabPageButtons);
            this.Controls.Add(this.TopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.TabPageButtons.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel UserInfoHolder;
        private Guna.UI2.WinForms.Guna2PictureBox Verified;
        private System.Windows.Forms.Label RobuxText;
        private Guna.UI2.WinForms.Guna2CirclePictureBox UserPFP;
        private Guna.UI2.WinForms.Guna2PictureBox Robux;
        private System.Windows.Forms.LinkLabel Username;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
    }
}

