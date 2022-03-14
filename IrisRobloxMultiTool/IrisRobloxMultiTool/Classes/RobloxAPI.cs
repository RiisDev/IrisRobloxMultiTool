using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IrisRobloxMultiTool
{
    public class RobloxAPI
    {
        public class Account {
            public string Cookie { get; set; }
            public string Name { get; set; }
            public string ID { get; set; }
            public string ProfilePicture { get; set; }
            public string ProfileUrl { get; set; }
            public bool IsVerified { get; set; }
            public string RobuxCount { get; set; }
        }

        public Account AccountData = new Account();

        public void SetupAccount()
        {
            using (WebClient Client = new WebClient())
            {
                Client.Headers.Add(HttpRequestHeader.Cookie, AccountData.Cookie);
                Client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36");

                string JData = Client.DownloadString("https://www.roblox.com/my/account/json");
                JObject Data = JObject.Parse(JData);

                AccountData.ID = Data["UserId"].ToString();
                AccountData.Name = Data["Name"].ToString().Replace("\"", "");
                AccountData.IsVerified = Convert.ToBoolean(Data["IsEmailVerified"].ToString());
                AccountData.ProfileUrl = $"https://www.roblox.com/users/{AccountData.ID}/profile";

                JData = Client.DownloadString($"https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds={AccountData.ID}&size=150x150&format=Png&isCircular=true");
                Data = JObject.Parse(JData);

                AccountData.ProfilePicture = Data["data"][0]["imageUrl"].ToString();

                JData = Client.DownloadString($"https://economy.roblox.com/v1/users/{AccountData.ID}/currency");
                Data = JObject.Parse(JData);

                AccountData.RobuxCount = Data["robux"].ToString();
            }
        }
    }
}
