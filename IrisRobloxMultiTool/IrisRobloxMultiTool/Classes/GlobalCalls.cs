using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IrisRobloxMultiTool.Classes
{
    public class GlobalCalls
    {
        public void SafeShutdown()
        {
            if (Program.RbxApi.AccountData.Cookie.Length > 5)
            {
                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add(HttpRequestHeader.Cookie, Program.RbxApi.AccountData.Cookie);
                    Client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36");
                    Client.Headers.Add(HttpRequestHeader.Accept, "application/json");

                    //Client.UploadString("https://auth.roblox.com/v2/logout", "{}");

                }
            }

            Environment.Exit(Environment.ExitCode);
        }

    }
}
