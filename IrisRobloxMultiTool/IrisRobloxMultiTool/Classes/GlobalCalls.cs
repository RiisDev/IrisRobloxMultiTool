using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            Process.GetProcessesByName("msedgedriver").ToList().ForEach(Proc => Proc.Kill());
            Process.GetProcessesByName("msedge").ToList().ForEach(Proc => Proc.Kill());
            Process.GetCurrentProcess().Kill();
        }

        public void HandleException(Exception ex)
        {
            try
            {
                using (StreamWriter logWriter = new StreamWriter($"{Program.Directory}\\bin\\cache\\Log_{Program.logId}.txt")) logWriter.WriteLine(ex.ToString());
            }
            catch { }
        }

    }
}
