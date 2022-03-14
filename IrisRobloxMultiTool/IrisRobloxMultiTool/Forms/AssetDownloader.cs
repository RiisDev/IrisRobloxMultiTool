using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class AssetDownloader : Form
    {
        public AssetDownloader()
        {
            InitializeComponent();
        }

        private void AssetDownloader_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory($"{Program.Directory}\\AssetDownloader");
            Directory.CreateDirectory($"{Program.Directory}\\AssetDownloader\\Shirts");
            Directory.CreateDirectory($"{Program.Directory}\\AssetDownloader\\Pants");
            Directory.CreateDirectory($"{Program.Directory}\\AssetDownloader\\Audio");
            Directory.CreateDirectory($"{Program.Directory}\\AssetDownloader\\Acessories");
        }
    }
}
