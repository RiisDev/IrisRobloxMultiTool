using System.Windows;
using System.Windows.Input;
using IrisRobloxMultiTool.Classes;
using Microsoft.Web.WebView2.Core;

namespace IrisRobloxMultiTool.Windows
{
    public partial class SignIn
    {
        public SignIn() => InitializeComponent();

        private void SignInView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e) => SignInView.CoreWebView2.ExecuteScriptAsync("document.body.classList.remove('light-theme');document.body.classList.add('dark-theme');document.querySelector('body').style.overflow='hidden';document.getElementById('header').remove();document.getElementById('footer-container').remove();document.getElementsByClassName('divider-text xsmall')[0].remove();");

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SignInButton.IsEnabled = false;
            try
            {
                Environment.SetEnvironmentVariable("WEBVIEW2_USER_DATA_FOLDER", $"{AppDomain.CurrentDomain.BaseDirectory}bin", EnvironmentVariableTarget.Process);
                SignInView.EnsureCoreWebView2Async();
            }
            catch (Exception ex) {
                Log(ex.ToString());
                CustomMessageBox.ShowDialog("Something went wrong while trying to sign in, please report on github.");
                return;
            }
            SignInView.CoreWebView2InitializationCompleted += SignInView_CoreWebView2InitializationCompleted;
        }

        private void SignInView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            SignInView.NavigationCompleted += SignInView_NavigationCompleted;
            SignInView.Source = new Uri("https://roblox.com/Login", UriKind.Absolute);
            SignInView.CoreWebView2.Settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36";
            SignInView.CoreWebView2.AddWebResourceRequestedFilter("https://roblox.com/*", CoreWebView2WebResourceContext.All);
            SignInView.CoreWebView2.AddWebResourceRequestedFilter("http://roblox.com/*", CoreWebView2WebResourceContext.All);
            SignInButton.IsEnabled = true;

            SignInView.CoreWebView2.WebResourceResponseReceived += async (_, ef) =>
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

                    string cookieValue = cookie[(cookie.IndexOf('=') + 1)..].Trim();
					Roblox.Account.Cookie = cookieValue;
                    await Roblox.SetupAccountData();

                    Close();

                    break;
                }
            };
        }

        private async void Login_Clicked(object sender, RoutedEventArgs e)
        {
			SignInView.CoreWebView2.FrameNavigationStarting += CoreWebView2_FrameNavigationStarting;
            await SignInView.CoreWebView2.ExecuteScriptAsync($$"""
                                                               function set(inputElement, value) {
                                                                   const setter = Object.getOwnPropertyDescriptor(
                                                                       HTMLInputElement.prototype,
                                                                       "value"
                                                                   ).set;
                                                               
                                                                   setter.call(inputElement, value);
                                                               
                                                                   for (const key in inputElement) {
                                                                       if (key.includes("__reactProps")) {
                                                                           inputElement.dispatchEvent(
                                                                               new Event("input", { bubbles: true })
                                                                           );
                                                                           break;
                                                                       }
                                                                   }
                                                               }
                                                               set(document.getElementById('login-username'), '{{UsernameTextBox.Text}}');
                                                               set(document.getElementById('login-password'), '{{PasswordTextBox.Password}}');
                                                               document.getElementById('login-button').click();
                                                               """);

            SignInButton.IsEnabled = false;

            while (true)
            {
                await Task.Delay(250);
                string loginError = await SignInView.CoreWebView2.ExecuteScriptAsync("document.getElementById('login-form-error').textContent;");
                if (loginError != "null")
                {
                    ErrorLabel.Content = loginError.Substring(1, loginError.Length - 2);
                    break;
                }

                string codeNeeded = await SignInView.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('modal-protection-shield-icon').length");
                if (codeNeeded != "0")
                {
	                await AppInvokeAsync(() =>
	                {
		                CustomSignInPanel.Visibility = Visibility.Visible;
		                Captcha.Visibility = Visibility.Hidden;

		                UsernameTextBox.Visibility = Visibility.Hidden;
		                PasswordTextBox.Visibility = Visibility.Hidden;
		                SignInButton.Visibility = Visibility.Hidden;

		                TwoFactorBox.Visibility = Visibility.Visible;
		                SubmitTwoFactor.Visibility = Visibility.Visible;
					});
					break;
                }

                if (!SignInView.CoreWebView2.Source.ToLower().Contains("login"))
				{
					await AppInvokeAsync(() => Captcha.Visibility = Visibility.Hidden);
					break;
				}
            }
        }

        private void CoreWebView2_FrameNavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
        {
            if (e.Uri == null || !e.Uri.Contains("arkoselabs.roblox.com")) return;

            CustomSignInPanel.Visibility = Visibility.Collapsed;
            Captcha.Visibility = Visibility.Visible;
        }

        private void OpenWebView_Click(object sender, RoutedEventArgs e)
        {
            CustomSignInPanel.Visibility = Visibility.Collapsed;
            Captcha.Visibility = Visibility.Visible;
        }

        private void SkipSignIn_Click(object sender, RoutedEventArgs e)
        {
	        Roblox.SkippedSignIn = true;
            Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            e.Handled = true;
            Login_Clicked(sender, new RoutedEventArgs());
        }

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
            // Do get help
		}

		private async void SubmitTwoFactor_Click(object sender, RoutedEventArgs e)
		{
			await SignInView.CoreWebView2.ExecuteScriptAsync($$"""
			                                                   set(document.getElementById('two-step-verification-code-input'), '{{TwoFactorBox.Text}}');
			                                                   document.querySelector('button[aria-label="Verify"]').click() 
			                                                   """);

			SubmitTwoFactor.IsEnabled = false;

			while (true)
			{
				await Task.Delay(250);
				string loginError = await SignInView.CoreWebView2.ExecuteScriptAsync("document.getElementsByClassName('form-control-label bottom-label xsmall')[0].textContent");
				if (!loginError.Trim().IsNullOrEmpty())
				{
					ErrorLabel.Content = loginError.Substring(1, loginError.Length - 2);
					SubmitTwoFactor.IsEnabled = true;
					break;
				}


				if (!SignInView.CoreWebView2.Source.ToLower().Contains("login"))
				{
					await AppInvokeAsync(() => Captcha.Visibility = Visibility.Hidden);
					break;
				}
			}
		}

		private void TwoFactorBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			bool isDigit = e.Text.All(char.IsDigit);
			e.Handled = !isDigit;
		}
	}
}
