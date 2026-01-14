using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IrisRobloxMultiTool.Windows
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox
    {
        public CustomMessageBox() => InitializeComponent();

        public MessageBoxResult Result { get; private set; }

        private readonly Dictionary<MessageBoxImage, ImageSource> MessageBoxImageToSystemIcon = new();
        //{
        //    { MessageBoxImage.Information, ImageConvert.ImageSourceFromBitmap(Properties.Resources.information)},
        //    { MessageBoxImage.Exclamation, ImageConvert.ImageSourceFromBitmap(Properties.Resources.exclamation)},
        //    { MessageBoxImage.Question, ImageConvert.ImageSourceFromBitmap(Properties.Resources.question) },
        //    { MessageBoxImage.Error, ImageConvert.ImageSourceFromBitmap(Properties.Resources.error) }
        //};

        public MessageBoxResult ShowDialog(string description, string? title = "Iris Roblox Multi Tool", MessageBoxButton messageBoxButton = MessageBoxButton.OK, MessageBoxImage messageBoxImage = MessageBoxImage.None)
        {
            return Dispatcher.Invoke(() =>
            {
                mainTitle.Title = title;
                descriptionLabel.Content = description;
                ButtonLeft.Visibility = Visibility.Hidden;
                ButtonMiddle.Visibility = Visibility.Hidden;
                ButtonRight.Visibility = Visibility.Hidden;

                if (messageBoxImage != MessageBoxImage.None)
                {
                    mainTitle.Icon = messageBoxImage switch
                    {
                        //MessageBoxImage.Asterisk => MessageBoxImageToSystemIcon[MessageBoxImage.Information],
                        //MessageBoxImage.Hand => MessageBoxImageToSystemIcon[MessageBoxImage.Error],
                        //_ => MessageBoxImageToSystemIcon[messageBoxImage]
                    };
                }

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
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageBoxButton), messageBoxButton, null);
                }

                ShowDialog();
                return Result;
            });
        }

    }

    public class ImageConvert
    {
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public static ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            IntPtr handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }

    }
}
