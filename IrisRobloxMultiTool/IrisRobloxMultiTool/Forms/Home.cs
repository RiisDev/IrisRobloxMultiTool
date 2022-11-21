using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            HomePage.EnsureCoreWebView2Async(CoreWebView2Environment.CreateAsync(null, $"{AppDomain.CurrentDomain.BaseDirectory}\\bin\\WebViewCache", null).Result);

        }

        private void HomePage_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            HomePage.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            HomePage.CoreWebView2.Settings.AreDevToolsEnabled = false;
            HomePage.CoreWebView2.Navigate("https://irisapp.ca/");
        }

    }
}
