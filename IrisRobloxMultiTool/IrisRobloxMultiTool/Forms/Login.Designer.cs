namespace IrisRobloxMultiTool.Forms
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseLogin = new System.Windows.Forms.Button();
            this.LoginPage = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.TitleText = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.TitleText);
            this.panel1.Controls.Add(this.CloseLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 25);
            this.panel1.TabIndex = 0;
            // 
            // CloseLogin
            // 
            this.CloseLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.CloseLogin.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseLogin.FlatAppearance.BorderSize = 0;
            this.CloseLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseLogin.ForeColor = System.Drawing.Color.White;
            this.CloseLogin.Location = new System.Drawing.Point(329, 0);
            this.CloseLogin.Name = "CloseLogin";
            this.CloseLogin.Size = new System.Drawing.Size(28, 25);
            this.CloseLogin.TabIndex = 0;
            this.CloseLogin.Text = "X";
            this.CloseLogin.UseVisualStyleBackColor = false;
            this.CloseLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginPage
            // 
            this.LoginPage.CreationProperties = null;
            this.LoginPage.DefaultBackgroundColor = System.Drawing.Color.White;
            this.LoginPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPage.Location = new System.Drawing.Point(0, 25);
            this.LoginPage.Name = "LoginPage";
            this.LoginPage.Size = new System.Drawing.Size(357, 458);
            this.LoginPage.TabIndex = 1;
            this.LoginPage.ZoomFactor = 1D;
            this.LoginPage.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.LoginPage_CoreWebView2InitializationCompleted);
            this.LoginPage.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.LoginPage_NavigationCompleted);
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Location = new System.Drawing.Point(151, 4);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(45, 16);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "Login";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(357, 483);
            this.Controls.Add(this.LoginPage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 LoginPage;
        private System.Windows.Forms.Button CloseLogin;
        private System.Windows.Forms.Label TitleText;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}