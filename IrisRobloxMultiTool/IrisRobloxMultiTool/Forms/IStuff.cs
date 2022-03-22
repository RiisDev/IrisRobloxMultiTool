using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class IStuff : Form
    {
        public IStuff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string Line in File.ReadAllLines("C:\\Users\\irisd\\Desktop\\BadMeshIds.txt"))
            {
                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add(HttpRequestHeader.Cookie, Program.RbxApi.AccountData.Cookie);
                    Client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36");

                    Client.UploadString($"https://develop.roblox.com/v1/assets/{Line}/archive", "");
                }
            }
        }
    }
}
