global using System.Net;
global using System.Net.Http;
global using System.Text.Json;
global using static IrisRobloxMultiTool.Classes.Config;
global using static IrisRobloxMultiTool.Classes.Logging;
global using static IrisRobloxMultiTool.Classes.TypeExtender;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace IrisRobloxMultiTool.Classes;

public static class Config
{
	public static readonly CookieContainer RobloxContainer = new();

	public static readonly HttpClient RobloxClient = new(new HttpClientHandler
	{
		AllowAutoRedirect = true,
		AutomaticDecompression = DecompressionMethods.All,
		ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
		UseCookies = true,
		UseProxy = false,
		Proxy = null,
		CookieContainer = RobloxContainer
	})
	{
		Timeout = TimeSpan.FromSeconds(30),
		DefaultRequestHeaders =
		{
			{"User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.6478.91 Safari/537.36"},
			{ "Referrer", "https://www.roblox.com/" }
		}
	};

	public static readonly CookieContainer BaseHttpContainer = new();

	public static readonly HttpClient BaseClient = new(new HttpClientHandler
	{
		AllowAutoRedirect = true,
		AutomaticDecompression = DecompressionMethods.All,
		ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
		UseCookies = true,
		UseProxy = false,
		Proxy = null,
		CookieContainer = RobloxContainer
	})
	{
		Timeout = TimeSpan.FromSeconds(30),
		DefaultRequestHeaders =
		{
			{"User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.6478.91 Safari/537.36"}
		}
	};

	public static RobloxApi Roblox { get; } = new ();

	public static bool UpdateAvailable { get; set; }
	
	public static string CurrentVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "-1";
}

public static class TypeExtender
{
	public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value) => string.IsNullOrEmpty(value);

	public static void AppInvoke(Action action) => Application.Current.Dispatcher.Invoke(action);
	public static TResult AppInvoke<TResult>(Func<TResult> func) => Application.Current.Dispatcher.Invoke(func);
	public static async Task AppInvokeAsync(Action action) => await Application.Current.Dispatcher.InvokeAsync(action);
	public static async Task<TResult> AppInvokeAsync<TResult>(Func<TResult> func) => await Application.Current.Dispatcher.InvokeAsync(func);

	public static void SetProperty<TControl, TValue>(TControl? control, Expression<Func<TControl, TValue>> propertyExpression, TValue newValue) where TControl : DependencyObject
	{
		ArgumentNullException.ThrowIfNull(control);
		
		if (propertyExpression.Body is not MemberExpression memberExpression)
			throw new ArgumentException("Expression must target a property.", nameof(propertyExpression));

		if (memberExpression.Member is not PropertyInfo propertyInfo)
			throw new ArgumentException("Member is not a property.", nameof(propertyExpression));

		Dispatcher dispatcher = control.Dispatcher;

		if (dispatcher.CheckAccess()) propertyInfo.SetValue(control, newValue);
		else AppInvoke(() => { propertyInfo.SetValue(control, newValue); });
	}

	public static void SetContent(ContentControl label, string content) => SetProperty(label, x=> x.Content, content);
}

public static class Logging
{
	private static readonly Lock LogLock = new();

	public enum State
	{
		Error,
		Warning,
		Info
	}

	public static void Log(string message, State state = State.Error, [CallerMemberName] string caller = "", [CallerFilePath] string callerFilePath = "")
	{
		lock (LogLock)
		{
			string className = Path.GetFileNameWithoutExtension(callerFilePath);
			string data = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{state}] [{className}.{caller}] {message}\n";
			Debug.WriteLine(data);
			File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\log.txt", data);

			Console.ForegroundColor = state switch
			{
				State.Error => ConsoleColor.Red,
				State.Warning => ConsoleColor.Yellow,
				State.Info => ConsoleColor.Green,
				_ => Console.ForegroundColor
			};
			Console.WriteLine(data);
			Console.ResetColor();
		}
	}

	public static void Log(Exception message, State state = State.Error, [CallerMemberName] string caller = "", [CallerFilePath] string callerFilePath = "") => Log(message.ToString(), state, caller, callerFilePath);
}