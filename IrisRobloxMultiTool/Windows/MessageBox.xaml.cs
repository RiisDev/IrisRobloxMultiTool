using System.Windows;

namespace IrisRobloxMultiTool.Windows
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox
    {
        public CustomMessageBox() => InitializeComponent();

        public MessageBoxResult Result { get; private set; }

        public MessageBoxResult ShowDialog(string description, string? title = "Iris Roblox Multi Tool", MessageBoxButton messageBoxButton = MessageBoxButton.OK, MessageBoxImage messageBoxImage = MessageBoxImage.None)
        {
            return Dispatcher.Invoke(() =>
            {
                MainTitle.Title = title;
                DescriptionLabel.Content = description;
                ButtonLeft.Visibility = Visibility.Hidden;
                ButtonMiddle.Visibility = Visibility.Hidden;
                ButtonRight.Visibility = Visibility.Hidden;
				
                switch (messageBoxButton)
                {
                    case MessageBoxButton.OK:
                        ButtonRight.Visibility = Visibility.Visible;
                        ButtonRight.Content = "OK";

                        ButtonRight.Click += delegate
                        {
                            Result = MessageBoxResult.OK;
                            Hide();
                        };

                        break;
                    case MessageBoxButton.OKCancel:
                        ButtonRight.Visibility = Visibility.Visible;
                        ButtonMiddle.Visibility = Visibility.Visible;

                        ButtonRight.Content = "Cancel";
                        ButtonMiddle.Content = "OK";

                        ButtonMiddle.Click += delegate
                        {
                            Result = MessageBoxResult.OK;
                            Hide();
                        };
                        ButtonRight.Click += delegate
                        {
                            Result = MessageBoxResult.Cancel;
                            Hide();
                        };

                        break;
                    case MessageBoxButton.YesNo:
                        ButtonRight.Visibility = Visibility.Visible;
                        ButtonMiddle.Visibility = Visibility.Visible;

                        ButtonRight.Content = "No";
                        ButtonMiddle.Content = "Yes";

                        ButtonMiddle.Click += delegate
                        {
                            Result = MessageBoxResult.Yes;
                            Hide();
                        };
                        ButtonRight.Click += delegate
                        {
                            Result = MessageBoxResult.No;
                            Hide();
                        };

                        break;
                    case MessageBoxButton.YesNoCancel:
                        ButtonRight.Visibility = Visibility.Visible;
                        ButtonMiddle.Visibility = Visibility.Visible;
                        ButtonLeft.Visibility = Visibility.Visible;

                        ButtonRight.Content = "Cancel";
                        ButtonMiddle.Content = "No";
                        ButtonLeft.Content = "Yes";

                        ButtonLeft.Click += delegate
                        {
                            Result = MessageBoxResult.Yes;
                            Hide();
                        };
                        ButtonMiddle.Click += delegate
                        {
                            Result = MessageBoxResult.No;
                            Hide();
                        };
                        ButtonRight.Click += delegate
                        {
                            Result = MessageBoxResult.Cancel;
                            Hide();
                        };

                        break;
                    case MessageBoxButton.AbortRetryIgnore:
                    case MessageBoxButton.RetryCancel:
                    case MessageBoxButton.CancelTryContinue:
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxButton), messageBoxButton, null);
                }

                ShowDialog();
                return Result;
            });
        }

    }

}
