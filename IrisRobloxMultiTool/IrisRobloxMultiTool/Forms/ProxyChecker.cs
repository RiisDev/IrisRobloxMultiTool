using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool.Forms
{
    public partial class ProxyChecker : Form
    {
        public ProxyChecker()
        {
            InitializeComponent();
        }

        private void ProxyChecker_Load(object sender, EventArgs e)
        {
            string[] proxies = new string[]
            {
                "192.168.0.1:8080",
                "192.168.0.2:8080",
                "192.168.0.3:8080",
                "192.168.0.4:8080",
                "192.168.0.5:8080"
            };

            Parallel.ForEach(proxies, proxy =>
            {
                // Split the proxy address and port into separate strings.
                string[] parts = proxy.Split(':');
                string proxyAddress = parts[0];
                int proxyPort = int.Parse(parts[1]);

                // Create a new WebProxy object with the proxy address and port.
                WebProxy webProxy = new WebProxy(proxyAddress, proxyPort);

                // Use the WebProxy object to create a new WebClient object.
                WebClient webClient = new WebClient { Proxy = webProxy };

                try
                {
                    // Try to download a small image from the web using the WebClient object.
                    byte[] imageBytes = webClient.DownloadData("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");

                    // If the download is successful, print a message to the console.
                    Console.WriteLine($"Proxy {proxy} is working.");
                }
                catch (WebException ex)
                {
                    // If the download fails, print a message to the console.
                    Console.WriteLine($"Proxy {proxy} is not working: {ex.Message}");
                }
            });

            // Wait for the user to press a key before exiting the program.
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}