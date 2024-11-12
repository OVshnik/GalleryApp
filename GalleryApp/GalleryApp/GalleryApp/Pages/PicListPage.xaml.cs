using GalleryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;
using Path = System.IO.Path;

namespace GalleryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PicListPage : ContentPage
	{
		public ObservableCollection<Picture> PictureList { get; set; } = new ObservableCollection<Picture>();
		public Picture SelectedPicture { get; set; }
		public PicListPage()
		{
			InitializeComponent();
			FillPicList();
		}
		private void FillPicList()
		{
			var picList = new ObservableCollection<Picture>();

			var path = Path.Combine("storage", "emulated", "0", "DCIM", "Camera");

			var picArray = Directory.GetFiles(path);

			foreach (var file in picArray)
			{
				picList.Add(new Picture
				{
					Name = new FileInfo(file).Name,
					CreateDate = File.GetCreationTime(file),
					Size = new FileInfo(file).Length,
					PicPath = new FileInfo(file).FullName
				});
			}
			var sorted = picList.OrderByDescending(x => x.CreateDate).ToList();
			for (int i = 0; i < sorted.Count(); i++)
			{
				picList.Move(picList.IndexOf(sorted[i]), i);
			}
			PictureList = picList;
			BindingContext = this;
		}
		private void PicListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			SelectedPicture = (Picture)e.SelectedItem;
		}
		private async void OpenPicButton_Clicked(object sender, EventArgs e)
		{
			if (SelectedPicture == null)
			{
				await DisplayAlert(null, $"Please, select photo", "OK");
				return;
			}
			await Navigation.PushAsync(new PicPage(SelectedPicture));
		}
		private async void DeletePicButton_Clicked(Object sender, EventArgs e)
		{
			if (SelectedPicture == null)
			{
				await DisplayAlert(null, $"Please, select photo", "OK");
				return;
			}
			await Task.Run(()=>PictureList.Remove(SelectedPicture));
			await Task.Run(() => File.Delete(SelectedPicture.PicPath));
		}
		private async void MakePhoto(object sender, EventArgs e)
		{
			var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
			{
				Title = $"pic_{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpeg"
			});

			var photoPath = Path.Combine("storage", "emulated", "0", "DCIM", "Camera", $"{photo.FullPath}");
			File.OpenWrite(photoPath);
		}
	}
}