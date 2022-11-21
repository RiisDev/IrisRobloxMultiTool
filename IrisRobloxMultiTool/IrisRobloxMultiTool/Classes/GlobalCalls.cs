using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Process.GetCurrentProcess().Kill();
        }

    }
}
