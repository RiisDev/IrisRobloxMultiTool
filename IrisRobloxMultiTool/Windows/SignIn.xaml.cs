using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using IrisRobloxMultiTool.Classes;
using Microsoft.Web.WebView2.Core;

namespace IrisRobloxMultiTool.Windows
{
    public partial class SignIn
    {
        public SignIn() => InitializeComponent();

        private void SignInView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e) => signInView.CoreWebView2.ExecuteScriptAsync("document.body.classList.remove('light-theme');document.body.classList.add('dark-theme');document.querySelector('body').style.overflow='hidden';document.getElementById('header').remove();document.getElementById('footer-container').remove();document.getElementsByClassName('divider-text xsmall')[0].remove();");

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SignInButton.IsEnabled = false;
            try
            {
                Environment.SetEnvironmentVariable("WEBVIEW2_USER_DATA_FOLDER", $"{AppDomain.CurrentDomain.BaseDirectory}bin", EnvironmentVariableTarget.Process);
                signInView.EnsureCoreWebView2Async();
            }
            catch (Exception ex) {
                Log(ex.ToString());
                App.CustomMessageBox.ShowDialog("Something went wrong while trying to sign in, please report on github.", null, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            signInView.CoreWebView2InitializationCompleted += SignInView_CoreWebView2InitializationCompleted;
        }

        private void SignInView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            signInView.NavigationCompleted += SignInView_NavigationCompleted;
            signInView.Source = new Uri("https://roblox.com/Login", UriKind.Absolute);
            signInView.CoreWebView2.Settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36";
            signInView.CoreWebView2.AddWebResourceRequestedFilter("https://roblox.com/*", CoreWebView2WebResourceContext.All);
            signInView.CoreWebView2.AddWebResourceRequestedFilter("http://roblox.com/*", CoreWebView2WebResourceContext.All);
            SignInButton.IsEnabled = true;

            signInView.CoreWebView2.WebResourceResponseReceived += async (_, ef) =>
			{
				if (!Roblox.Account.Cookie.IsNullOrEmpty()) return;
				if (ef.Request.Headers == null) return;
                if (!ef.Request.Headers.Contains("Cookie")) return;
                if (!ef.Request.Headers.GetHeader("Cookie").Contains(".ROBLOSECURITY")) return;

                string[] cookies = ef.Request.Headers.GetHeader("Cookie").Split([";"], StringSplitOptions.None);

                foreach (string cookie in cookies)
                {
                    if (!Roblox.Account.Cookie.IsNullOrEmpty()) return;
                    if (!cookie.Contains(".ROBLOSECURITY")) continue;

                    string cookieValue = cookie.Substring(cookie.IndexOf('=') + 1).Trim();
					Roblox.Account.Cookie = cookieValue;
                    await Roblox.SetupAccountData();

                    Close();

                    break;
                }
            };
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
			signInView.CoreWebView2.FrameNavigationStarting += CoreWebView2_FrameNavigationStarting;
            await signInView.CoreWebView2.ExecuteScriptAsync($$"""
                                                               function set(obj, callback) {
                                                               	callback(obj);

                                                               	for (let [k, v] of Object.entries(obj)) {
                                                               		if (k.includes('reactProps') && v.onChange) {
                                                               			v.onChange({target: obj});
                                                               		}
                                                               	}
                                                               }
                                                               set(document.getElementById('login-username'), obj => obj.value='{{usernameTextBox.Text}}');
                                                               set(document.getElementById('login-password'), obj => obj.value='{{passwordTextBox.Password}}');
                                                               document.getElementById('login-button').click();
                                                               """);
            while (true)
            {
                await Task.Delay(250);
                string loginError = await signInView.CoreWebView2.ExecuteScriptAsync("document.getElementById('login-form-error').textContent;");
                if (loginError != "null")
                {
                    errorLabel.Content = loginError.Substring(1, loginError.Length - 2);
                    break;
                }

                string codeNeeded = await signInView.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('modal-protection-shield-icon').length");
                
                if (codeNeeded != "0")
                {
					Application.Current.Dispatcher.Invoke(() =>
					{
						captcha.Visibility = Visibility.Visible;
					});
				}

                if (!signInView.CoreWebView2.Source.ToLower().Contains("login"))
				{
					Application.Current.Dispatcher.Invoke(() =>
					{
						captcha.Visibility = Visibility.Hidden;
					});
					break;
                }
            }
        }

        private void CoreWebView2_FrameNavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
        {
            if (e.Uri == null || !e.Uri.Contains("https://client-api.arkoselabs.com/fc/assets")) return;

            customSignInPanel.Visibility = Visibility.Collapsed;
            captcha.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            customSignInPanel.Visibility = Visibility.Collapsed;
            captcha.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
	        Roblox.SkippedSignIn = true;
            Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            e.Handled = true;
            Button_Click(sender, new RoutedEventArgs());
        }

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
            // Do get help
		}
	}
}
