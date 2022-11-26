using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class AssetFavouriteBot : Form
    {
        string CookieListDir;
        public AssetFavouriteBot()
        {
            InitializeComponent();
        }

        private void StartDownload_Click(object sender, EventArgs e)
        {
            foreach (string Cookie in File.ReadAllLines(CookieListDir))
            {
                new Thread(() =>
                {
                    try
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            
                            webClient.Headers.Add(HttpRequestHeader.Cookie, Cookie);
                            webClient.Headers.Add("x-csrf-token", Program.RobloxAccountAPI.GetXSRFToken(Cookie));

                            NameValueCollection Data = new NameValueCollection();
                            Data.Add("itemTargetId", KeywordBox.Text);
                            Data.Add("favoriteType", "Asset");

                            string Response = webClient.Encoding.GetString(webClient.UploadValues("https://www.roblox.com/v2/favorite/toggle", Data));

                            Console.WriteLine(Response);
                        }
                    }
                    catch (WebException)
                    {
                        
                    }
                }).Start();
            }
        }

        private void FindLocation_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Choose where the items will be saved to!";

                DialogResult Result = dialog.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    if (File.Exists(dialog.FileName))
                    {
                        CookieListDir = dialog.FileName;
                        CustomIdLocBox.Text = CookieListDir;
                    }
                }
            }
        }

        private void AssetFavouriteBot_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Program.RobloxAccountAPI.AccountData.Cookie);
        }
    }
}
