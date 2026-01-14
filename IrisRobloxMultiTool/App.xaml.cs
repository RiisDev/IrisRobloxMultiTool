using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;
using IrisRobloxMultiTool.Windows;

namespace IrisRobloxMultiTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
	    public static CustomMessageBox CustomMessageBox;
	    public static string CurrentVersion = "";

		private void Application_Startup(object sender, StartupEventArgs e)
	    {
		    CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "-1";
		    CustomMessageBox = new CustomMessageBox();
	    }
	}

}
