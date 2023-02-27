using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IrisRobloxMultiTool.Classes
{
    public class iHttpClient
    {
        private HttpClient Client = new HttpClient();

        public string DownloadString(string url, Dictionary<string, string> headers)
        {
            Client.DefaultRequestHeaders.Clear();
            foreach (var item in headers) Client.DefaultRequestHeaders.Add(item.Key, item.Value);

            return Client.GetStringAsync(new Uri(url)).Result;
        }

        public string UploadValues(string url, Dictionary<string, string> headers, HttpContent httpContent)
        {
            Client.DefaultRequestHeaders.Clear();
            foreach (var item in headers) Client.DefaultRequestHeaders.Add(item.Key, item.Value);

            return "";
        }
    }
}
