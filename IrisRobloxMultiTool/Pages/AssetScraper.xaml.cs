using IrisRobloxMultiTool.Classes;
using IrisRobloxMultiTool.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Common;

namespace IrisRobloxMultiTool.Pages
{
	public partial class AssetScraper
	{
		public string AssetDataUrl => GetTextContent(AssetId);
		public string InputFile = null!;
		public string OutputLocation = null!;
		
	    private readonly AssetDownloadsViewModel _assetDownloads;
		private readonly Dictionary<long, AssetDownloadItem> _ongoingDownloads = new();

		public AssetScraper()
		{
			InitializeComponent();
			BaseAssetType_SelectionChanged(BaseAssetType, null!);
			_assetDownloads = new AssetDownloadsViewModel();
			DownloadControl.DataContext = _assetDownloads;

			Loaded += (_, _) =>
			{
				_assetDownloads.AssetDownloads.Add(new AssetDownloadItem()
				{
					PreviewImage = new Uri("https://tr.rbxcdn.com/180DAY-d3a466e4129542c484d6ec662d65b9f9/420/420/ShirtAccessory/Webp/noFilter"),
					Progress = 0,
					IsCompleted = false,
					StatusIcon = SymbolRegular.ArrowDownload20,
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
}
