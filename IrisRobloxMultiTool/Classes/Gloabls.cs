global using static IrisRobloxMultiTool.Classes.Logging;
global using static IrisRobloxMultiTool.Classes.Config;
global using System.Net;
global using System.Net.Http;
global using System.Text.Json;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

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
			{"User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.6478.91 Safari/537.36"}
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
}

public static class TypeExtender
{
	public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value) => string.IsNullOrEmpty(value);
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
}