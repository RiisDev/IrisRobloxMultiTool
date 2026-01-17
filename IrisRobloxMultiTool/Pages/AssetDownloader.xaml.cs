using IrisRobloxMultiTool.Classes;
using IrisRobloxMultiTool.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Common;

namespace IrisRobloxMultiTool.Pages
{
	public enum InputType
	{
		SingleAsset,
		GroupAsset,
		FileInput
	}

	public partial class AssetDownloader
	{
		public string AssetDataUrl => GetTextContent(AssetId);
		public string InputFile = null!;
		public string OutputLocation = null!;
		
	    private readonly AssetDownloadsViewModel _assetDownloads;
		private readonly Dictionary<long, AssetDownloadItem> _ongoingDownloads = new();

		public AssetDownloader()
		{
			InitializeComponent();
			BaseAssetType_SelectionChanged(BaseAssetType, null!);
			_assetDownloads = new AssetDownloadsViewModel();
			DownloadControl.DataContext = _assetDownloads;

			Loaded += (_, _) =>
			{
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 0,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 25,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 50,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 100,
					IsCompleted = false,
					StatusIcon = SymbolRegular.CheckmarkCircle20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 0,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 25,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 50,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 100,
					IsCompleted = true,
					StatusIcon = SymbolRegular.CheckmarkCircle20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 0,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 25,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 50,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 100,
					IsCompleted = false,
					StatusIcon = SymbolRegular.CheckmarkCircle20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 0,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 25,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 50,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
					AssetId = 1354235
				});
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem(this)
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 100,
					IsCompleted = false,
					StatusIcon = SymbolRegular.CheckmarkCircle20,
					AssetId = 1354235
				});
			};
		}

		private static readonly Dictionary<string, IReadOnlyList<string>> AssetSubTypes = new ()
		{
			{ "Accessories", new List<string> { "Head", "Face", "Neck", "Shoulder", "Front", "Back", "Waist", "Gear" } },
			{ "Animations", new List<string> { "Bundle", "Emote" } },
			{ "Audio", new List<string>() },
			{ "Body", new List<string> { "Full Bodies", "Hair", "Head", "Classic Head", "Classic Face" } },
			{ "Clothing", new List<string> { "T-Shirt", "Shirt", "Sweaters", "Jackets", "Pants", "Shorts", "Dresses & Skirts", "Bodysuits", "Shoes", "Classic Shirts", "Classic T-Shirts", "Classic Pants" } },
			{ "Game Asset", new List<string> { "Mesh", "Model", "Plugin", "Texture", } }
		};
		
		private void OpenFileDialog(object sender, RoutedEventArgs e)
		{
			if (sender is not Control control) return;

			string controlName = control.Name;

			switch (controlName)
			{
				case "ClearInputFile":
					ClearInputFile.Visibility = Visibility.Collapsed;
					SelectInputFile.BorderBrush = new SolidColorBrush(Color.FromArgb(40, 243, 41, 41));
					InputFile = string.Empty;
					AssetId.IsEnabled = true;
					break;
				case "SelectInputFile":
				{
					OpenFileDialog openFileDialog = new()
					{
						Title = "Select Input File",
						Filter = "All Files (*.*)|*.*"
					};

					if (openFileDialog.ShowDialog() == true) InputFile = openFileDialog.FileName;
					if (InputFile.IsNullOrEmpty()) break;
					if (!File.Exists(InputFile)) CustomMessageBox.ShowDialog($"{Path.GetFileName(InputFile)} does not exist.");

					AssetId.Text = "";
					AssetId.IsEnabled = false;
					SelectInputFile.BorderBrush = new SolidColorBrush(Color.FromArgb(60, 0, 255, 0));
					ClearInputFile.Visibility = Visibility.Visible;

					break;
				}
				case "SelectOutputFolder":
				{
					FolderPicker dialog = new () { Multiselect = false };

					if (dialog.ShowDialog() == true) OutputLocation = dialog.ResultPath;
					if (OutputLocation.IsNullOrEmpty()) break;
					if (!Directory.Exists(OutputLocation))
					{
						try { Directory.CreateDirectory(OutputLocation); }
						catch (Exception ex)
						{
							CustomMessageBox.ShowDialog($"Failed to create missing directory: {ex.Message}");
							Log(ex);
						}
					}

					SetProperty(OutputBox, x=> x.Text, OutputLocation);
					break;
				}
			}
		}

		private string GetTextContent(TextBox textBox) => Dispatcher.Invoke(() => textBox.Text);

		private void BaseAssetType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			AppInvoke(() =>
			{
				if (AssetSubTypesBox is null) return;

				AssetSubTypesBox.Items.Clear();
				foreach (string subType in AssetSubTypes[((ComboBoxItem)BaseAssetType.SelectedItem).Content.ToString()!])
				{
					AssetSubTypesBox.Items.Add(new ComboBoxItem
					{
						Content = subType
					});
				}
				AssetSubTypesBox.SelectedIndex = 0;
				UpdateLayout();
			});
		}
	}

	public sealed class AssetDownloadItem(Page page)
    {
		public required long AssetId { get; set; }

		public required Uri? PreviewImage
	    {
		    get;
		    set { field = value; AppInvoke(page.UpdateLayout); }
	    }

		public required double Progress
	    {
		    get;
		    set { field = value; AppInvoke(page.UpdateLayout); }
	    }

		public required bool IsCompleted
	    {
		    get;
		    set { field = value; AppInvoke(page.UpdateLayout); }
	    }

		public required SymbolRegular StatusIcon
		{
			get;
			set { field = value; AppInvoke(page.UpdateLayout); }
		}
    }

	public sealed class AssetDownloadsViewModel
	{
		public ObservableCollection<AssetDownloadItem> AssetDownloads { get; } = [];
	}

	public sealed class PercentToBrushConverter : IValueConverter
	{
		private static readonly Dictionary<int, Color> PercentToColour = new()
		{
			{ -1, Color.FromRgb(255, 0, 0) },
			{ 0, Color.FromRgb(255, 0, 0) },
			{ 1, Color.FromRgb(255, 3, 0) },
			{ 2, Color.FromRgb(255, 6, 0) },
			{ 3, Color.FromRgb(255, 9, 0) },
			{ 4, Color.FromRgb(255, 13, 0) },
			{ 5, Color.FromRgb(255, 16, 0) },
			{ 6, Color.FromRgb(255, 19, 0) },
			{ 7, Color.FromRgb(255, 23, 0) },
			{ 8, Color.FromRgb(255, 26, 0) },
			{ 9, Color.FromRgb(255, 29, 0) },
			{ 10, Color.FromRgb(255, 33, 0) },
			{ 11, Color.FromRgb(255, 36, 0) },
			{ 12, Color.FromRgb(255, 39, 0) },
			{ 13, Color.FromRgb(255, 42, 0) },
			{ 14, Color.FromRgb(255, 46, 0) },
			{ 15, Color.FromRgb(255, 49, 0) },
			{ 16, Color.FromRgb(255, 52, 0) },
			{ 17, Color.FromRgb(255, 56, 0) },
			{ 18, Color.FromRgb(255, 59, 0) },
			{ 19, Color.FromRgb(255, 62, 0) },
			{ 20, Color.FromRgb(255, 66, 0) },
			{ 21, Color.FromRgb(255, 69, 0) },
			{ 22, Color.FromRgb(255, 72, 0) },
			{ 23, Color.FromRgb(255, 75, 0) },
			{ 24, Color.FromRgb(255, 79, 0) },
			{ 25, Color.FromRgb(255, 82, 0) },
			{ 26, Color.FromRgb(255, 85, 0) },
			{ 27, Color.FromRgb(255, 89, 0) },
			{ 28, Color.FromRgb(255, 92, 0) },
			{ 29, Color.FromRgb(255, 95, 0) },
			{ 30, Color.FromRgb(255, 99, 0) },
			{ 31, Color.FromRgb(255, 102, 0) },
			{ 32, Color.FromRgb(255, 105, 0) },
			{ 33, Color.FromRgb(255, 108, 0) },
			{ 34, Color.FromRgb(255, 112, 0) },
			{ 35, Color.FromRgb(255, 115, 0) },
			{ 36, Color.FromRgb(255, 118, 0) },
			{ 37, Color.FromRgb(255, 122, 0) },
			{ 38, Color.FromRgb(255, 125, 0) },
			{ 39, Color.FromRgb(255, 128, 0) },
			{ 40, Color.FromRgb(255, 132, 0) },
			{ 41, Color.FromRgb(255, 135, 0) },
			{ 42, Color.FromRgb(255, 138, 0) },
			{ 43, Color.FromRgb(255, 141, 0) },
			{ 44, Color.FromRgb(255, 145, 0) },
			{ 45, Color.FromRgb(255, 148, 0) },
			{ 46, Color.FromRgb(255, 151, 0) },
			{ 47, Color.FromRgb(255, 155, 0) },
			{ 48, Color.FromRgb(255, 158, 0) },
			{ 49, Color.FromRgb(255, 161, 0) },
			{ 50, Color.FromRgb(255, 165, 0) },
			{ 51, Color.FromRgb(255, 170, 6) },
			{ 52, Color.FromRgb(255, 174, 11) },
			{ 53, Color.FromRgb(254, 179, 17) },
			{ 54, Color.FromRgb(254, 183, 23) },
			{ 55, Color.FromRgb(254, 188, 29) },
			{ 56, Color.FromRgb(254, 192, 34) },
			{ 57, Color.FromRgb(254, 197, 40) },
			{ 58, Color.FromRgb(254, 201, 46) },
			{ 59, Color.FromRgb(253, 206, 52) },
			{ 60, Color.FromRgb(253, 210, 57) },
			{ 61, Color.FromRgb(253, 213, 61) },
			{ 62, Color.FromRgb(253, 214, 62) },
			{ 63, Color.FromRgb(253, 215, 63) },
			{ 64, Color.FromRgb(249, 216, 64) },
			{ 65, Color.FromRgb(245, 217, 65) },
			{ 66, Color.FromRgb(241, 217, 66) },
			{ 67, Color.FromRgb(237, 218, 67) },
			{ 68, Color.FromRgb(233, 219, 68) },
			{ 69, Color.FromRgb(229, 220, 69) },
			{ 70, Color.FromRgb(224, 221, 70) },
			{ 71, Color.FromRgb(220, 221, 71) },
			{ 72, Color.FromRgb(216, 222, 72) },
			{ 73, Color.FromRgb(212, 223, 73) },
			{ 74, Color.FromRgb(208, 224, 74) },
			{ 75, Color.FromRgb(204, 225, 75) },
			{ 76, Color.FromRgb(200, 225, 76) },
			{ 77, Color.FromRgb(196, 226, 77) },
			{ 78, Color.FromRgb(192, 227, 78) },
			{ 79, Color.FromRgb(188, 228, 79) },
			{ 80, Color.FromRgb(183, 229, 80) },
			{ 81, Color.FromRgb(179, 229, 81) },
			{ 82, Color.FromRgb(175, 230, 82) },
			{ 83, Color.FromRgb(171, 231, 83) },
			{ 84, Color.FromRgb(167, 232, 84) },
			{ 85, Color.FromRgb(163, 233, 85) },
			{ 86, Color.FromRgb(159, 233, 86) },
			{ 87, Color.FromRgb(155, 234, 87) },
			{ 88, Color.FromRgb(151, 235, 88) },
			{ 89, Color.FromRgb(147, 236, 89) },
			{ 90, Color.FromRgb(142, 237, 90) },
			{ 91, Color.FromRgb(138, 237, 91) },
			{ 92, Color.FromRgb(134, 238, 92) },
			{ 93, Color.FromRgb(130, 239, 93) },
			{ 94, Color.FromRgb(126, 240, 94) },
			{ 95, Color.FromRgb(122, 241, 95) },
			{ 96, Color.FromRgb(118, 241, 96) },
			{ 97, Color.FromRgb(114, 242, 97) },
			{ 98, Color.FromRgb(110, 243, 98) },
			{ 99, Color.FromRgb(106, 244, 99) },
			{ 100, Color.FromRgb(101, 245, 100) }
		};
		
		public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			if (value is not double progress) return Brushes.Red;

			int percent = (int)Math.Round(progress);
			Color color = PercentToColour[percent];

			return new SolidColorBrush(color);
		}

		public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
	}
}
