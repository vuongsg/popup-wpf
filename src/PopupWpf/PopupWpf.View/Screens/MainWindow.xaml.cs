using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PopupWpf.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : BaseWindow
	{
		#region Properties
		private string _photoPath;
		public string PhotoPath
		{
			get => _photoPath;
			set
			{
				_photoPath = value;
				OnPropertyChanged(nameof(PhotoPath));
			}
		}
		#endregion

		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
		}

		private void btnChoose_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = "Photos (.bmp, .jpg, .jpeg, .png) |*.bmp;*.jpg;*.jpeg;*.png"
			};

			if (ofd.ShowDialog() == true)
			{
				imgAvatar.Source = GetImage(ofd.FileName);
				PhotoPath = ofd.FileName;
			}
		}

		private static BitmapImage GetImage(string imageUri)
		{
			var bitmapImage = new BitmapImage();

			bitmapImage.BeginInit();
			bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
			bitmapImage.EndInit();

			return bitmapImage;
		}

		private void imgAvatar_MouseMove(object sender, MouseEventArgs e)
		{
			popInfo.IsOpen = true;
		}

		private void imgAvatar_MouseLeave(object sender, MouseEventArgs e)
		{
			if (popInfo.IsOpen && popInfo.IsMouseOver)
			{

			}
			else
			{
				popInfo.IsOpen = false;
			}
		}

		private void popInfo_MouseLeave(object sender, MouseEventArgs e)
		{
			if (popInfo.IsOpen && imgAvatar.IsMouseOver)
			{

			}
			else
			{
				popInfo.IsOpen = false;
			}
		}
	}
}
