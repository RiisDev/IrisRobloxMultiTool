namespace IrisRobloxMultiTool.Forms
{
    partial class Home
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
            this.HomePage = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.HomePage)).BeginInit();
            this.SuspendLayout();
            // 
            // HomePage
            // 
            this.HomePage.CreationProperties = null;
            this.HomePage.DefaultBackgroundColor = System.Drawing.Color.White;
            this.HomePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePage.Location = new System.Drawing.Point(0, 0);
            this.HomePage.Name = "HomePage";
            this.HomePage.Size = new System.Drawing.Size(524, 369);
            this.HomePage.TabIndex = 0;
            this.HomePage.ZoomFactor = 1D;
            this.HomePage.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.HomePage_CoreWebView2InitializationCompleted);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(524, 369);
            this.Controls.Add(this.HomePage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HomePage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 HomePage;
    }
}