using GalleryApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalleryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PicPage : ContentPage
	{
		public Picture Picture { get; set; }
		public PicPage(Picture picture)
		{
			Picture = picture;
			InitializeComponent();
			BindingContext=this;
		}

	}
}