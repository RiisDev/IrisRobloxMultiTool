using IrisRobloxMultiTool.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisRobloxMultiTool
{
    internal static class Program
    { 
        public static string Directory = AppDomain.CurrentDomain.BaseDirectory;
        public static GlobalCalls Global = new();
        public static DataHandler DataHandler = new();
        public static RobloxAPI RobloxAPI = new();
        public static LogInterface LogInterface = new();
        public static RobloxAccountAPI RobloxAccountAPI = new();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
