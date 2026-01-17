using System.Windows;

namespace IrisRobloxMultiTool.Windows
{
	public partial class CustomMessageBox
	{
		public CustomMessageBox() => InitializeComponent();

		public static MessageBoxResult ShowDialog(string description, string title = "Iris Roblox Multi Tool", MessageBoxButton messageBoxButton = MessageBoxButton.OK)
		{
			MessageBoxResult result = MessageBoxResult.None;

			AppInvoke(() =>
			{
				CustomMessageBox messageBox = new()
				{
					Owner = Application.Current.MainWindow,
					MainTitle =
					{
						Title = title
					},
					DescriptionLabel =
					{
						Content = description
					}
				};

				messageBox.ConfigureButtons(messageBoxButton);

				_ = messageBox.ShowDialog();
				result = messageBox.Result;
			});
			
			return result;
		}

		public MessageBoxResult Result { get; private set; }

		private void ConfigureButtons(MessageBoxButton messageBoxButton)
		{
			ButtonLeft.Visibility = Visibility.Hidden;
			ButtonMiddle.Visibility = Visibility.Hidden;
			ButtonRight.Visibility = Visibility.Hidden;

			ButtonLeft.Click -= Button_Click;
			ButtonMiddle.Click -= Button_Click;
			ButtonRight.Click -= Button_Click;

			switch (messageBoxButton)
			{
				case MessageBoxButton.OK:
					ButtonRight.Visibility = Visibility.Visible;
					ButtonRight.Content = "OK";
					ButtonRight.Tag = MessageBoxResult.OK;
					ButtonRight.Click += Button_Click;
					break;

				case MessageBoxButton.YesNo:
					ButtonMiddle.Visibility = Visibility.Visible;
					ButtonRight.Visibility = Visibility.Visible;

					ButtonMiddle.Content = "Yes";
					ButtonMiddle.Tag = MessageBoxResult.Yes;

					ButtonRight.Content = "No";
					ButtonRight.Tag = MessageBoxResult.No;

					ButtonMiddle.Click += Button_Click;
					ButtonRight.Click += Button_Click;
					break;

				case MessageBoxButton.YesNoCancel:
					ButtonLeft.Visibility = Visibility.Visible;
					ButtonMiddle.Visibility = Visibility.Visible;
					ButtonRight.Visibility = Visibility.Visible;

					ButtonLeft.Content = "Yes";
					ButtonLeft.Tag = MessageBoxResult.Yes;

					ButtonMiddle.Content = "No";
					ButtonMiddle.Tag = MessageBoxResult.No;

					ButtonRight.Content = "Cancel";
					ButtonRight.Tag = MessageBoxResult.Cancel;

					ButtonLeft.Click += Button_Click;
					ButtonMiddle.Click += Button_Click;
					ButtonRight.Click += Button_Click;
					break;

				default:
					throw new ArgumentOutOfRangeException(nameof(messageBoxButton));
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (sender is FrameworkElement element &&
				element.Tag is MessageBoxResult result)
			{
				Result = result;
				DialogResult = true;
				Close();
			}
		}

		private void MainTitle_CloseClicked(object sender, RoutedEventArgs e)
		{
			e.Handled = true;
			Result = MessageBoxResult.Cancel;
			DialogResult = false;
			Close();
		}
	}
}
