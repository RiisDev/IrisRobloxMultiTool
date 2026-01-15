namespace IrisRobloxMultiTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
		private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
		{
			TaskScheduler.UnobservedTaskException += (_, exception) => Log(exception.Exception);
			AppDomain.CurrentDomain.UnhandledException += (_, exception) => Log(exception.ExceptionObject.ToString()!);
			DispatcherUnhandledException += (_, exception) => Log(exception.Exception);
		}
	}

}
