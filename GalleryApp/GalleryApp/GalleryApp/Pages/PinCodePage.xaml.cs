using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading;
//using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace GalleryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PinCodePage : ContentPage
	{
		public static string PinValue = "";

		static int clickCounter = 0;
		public static int ClickCounter
		{
			set
			{
				if (value < 4)
					clickCounter = value;
			}
			get
			{
				return clickCounter;
			}
		}
		public PinCodePage()
		{
			InitializeComponent();
			SetElements();
		}
		private void SetElements()
		{
			var stackLayout = new StackLayout { BackgroundColor = Color.LightGray };

			var text = new Label
			{
				Padding = 20,
				FontSize = 30,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			if (!Preferences.ContainsKey("PIN"))
			{
				text.Text = "Please setup PIN";
			}
			else
			{
				text.Text = "Please input PIN";
			}

			Grid grid = new Grid
			{
				RowDefinitions =
			{
				new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
				new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
				new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
				new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
			},
				ColumnDefinitions =
			{
				new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
			},
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.LightGray,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = 25,
				RowSpacing = 25,
				ColumnSpacing = 20,
				HeightRequest = 500,
			};

			Style pinButtonStyle = new Style(typeof(Button))
			{
				Setters =
						{
							new Setter
							{
								Property = Button.VerticalOptionsProperty,
								Value = LayoutAlignment.Center
							},
							new Setter
							{
								Property = Button.HorizontalOptionsProperty,
								Value = LayoutAlignment.Center
							},
							new Setter
							{
								Property = Button.WidthRequestProperty,
								Value = 100
							},
							new Setter
							{
								Property = Button.WidthRequestProperty,
								Value = 100
							},

							new Setter
							{
								Property = Button.WidthRequestProperty,
								Value = 100
							},
							new Setter
							{
								Property = Button.HeightRequestProperty,
								Value = 100
							},
							new Setter
							{
								Property= Button.BackgroundColorProperty,
								Value= Color.DarkGray,
							},
							new Setter
							{
								Property=Button.FontSizeProperty,
								Value= 30
							},
							new Setter
							{
								Property=Button.BorderColorProperty,
								Value= Color.LightGray,
							},
							new Setter
							{
								Property=Button.BorderWidthProperty,
								Value=2,
							},
							new Setter
							{
								Property=Button.CornerRadiusProperty,
								Value=80,
							}
						}
			};

			var grid1 = new Grid
			{
				RowDefinitions =
			{
				new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
			},
				ColumnDefinitions =
			{
				new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
			},
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.LightGray,
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness(40, 10, 40, 10),
				RowSpacing = 5,
				ColumnSpacing = 5,
			};

			grid1.Children.Add(new Frame
			{
				WidthRequest = 5,
				HeightRequest = 5,
				BorderColor = Color.DarkGray,
				CornerRadius = 30,
				HorizontalOptions = LayoutOptions.Center
			}, 0, 0);
			grid1.Children.Add(new Frame
			{
				WidthRequest = 5,
				HeightRequest = 5,
				BorderColor = Color.DarkGray,
				CornerRadius = 30,
				HorizontalOptions = LayoutOptions.Center
			}, 1, 0);
			grid1.Children.Add(new Frame
			{
				WidthRequest = 5,
				HeightRequest = 5,
				BorderColor = Color.DarkGray,
				CornerRadius = 30,
				HorizontalOptions = LayoutOptions.Center
			}, 2, 0);
			grid1.Children.Add(new Frame
			{
				WidthRequest = 5,
				HeightRequest = 5,
				BorderColor = Color.DarkGray,
				CornerRadius = 30,
				HorizontalOptions = LayoutOptions.Center
			}, 3, 0);

			var btn0 = new Button
			{
				Text = "0",
				Style = pinButtonStyle
			};
			btn0.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn0, grid1);

			var btn1 = new Button
			{
				Text = "1",
				Style = pinButtonStyle
			};
			btn1.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn1, grid1);

			var btn2 = new Button
			{
				Text = "2",
				Style = pinButtonStyle

			};
			btn2.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn2, grid1);

			var btn3 = new Button
			{
				Text = "3",
				Style = pinButtonStyle

			};
			btn3.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn3, grid1);

			var btn4 = new Button
			{
				Text = "4",
				Style = pinButtonStyle

			};
			btn4.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn4, grid1);

			var btn5 = new Button
			{
				Text = "5",
				Style = pinButtonStyle

			};
			btn5.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn5, grid1);

			var btn6 = new Button
			{
				Text = "6",
				Style = pinButtonStyle
			};
			btn6.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn6, grid1);

			var btn7 = new Button
			{
				Text = "7",
				Style = pinButtonStyle
			};
			btn7.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn7, grid1);

			var btn8 = new Button
			{
				Text = "8",
				Style = pinButtonStyle
			};
			btn8.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn8, grid1);

			var btn9 = new Button
			{
				Text = "9",
				Style = pinButtonStyle
			};
			btn9.Clicked += (sender, e) => NumButton_Clicked(sender, e, btn9, grid1);

			var backBtn = new Button
			{
				Text = "Back",
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Padding = 30
			};
			backBtn.Clicked += (sender, e) => BackButton_Clicked(sender, e, grid1);

			grid.Children.Add(btn1, 0, 0);
			grid.Children.Add(btn2, 1, 0);
			grid.Children.Add(btn3, 2, 0);

			grid.Children.Add(btn4, 0, 1);
			grid.Children.Add(btn5, 1, 1);
			grid.Children.Add(btn6, 2, 1);

			grid.Children.Add(btn7, 0, 2);
			grid.Children.Add(btn8, 1, 2);
			grid.Children.Add(btn9, 2, 2);

			grid.Children.Add(btn0, 1, 3);
			grid.Children.Add(backBtn, 2, 3);

			stackLayout.Children.Add(text);
			stackLayout.Children.Add(grid1);
			stackLayout.Children.Add(grid);

			Content = stackLayout;
		}
		private void NumButton_Clicked(object sender, EventArgs e, Button button, Grid grid)
		{
			if (PinValue.Length < 4)
			{
				FillCircles(grid);
				ClickCounter++;
				PinValue = String.Concat(PinValue, button.Text);
				PinValidation(grid);
			}
		}
		private void PinValidation(Grid grid)
		{
			if (PinValue.Length == 4)
			{
				if (!Preferences.ContainsKey("PIN"))
				{
					Preferences.Set("PIN", PinValue);
					DisplayAlert("", "PIN code successfully setup", "Continue");
					RedirectToGalleryPage();
					ResetPinAndCounterValues();
					ResetCircles(grid);
				}
				else
				{
					if (PinValue == Preferences.Get("PIN", ""))
					{
						RedirectToGalleryPage();
						ResetPinAndCounterValues();
						ResetCircles(grid);
					}
					else
					{
						DisplayAlert("", "PIN code is invalid, please try again!", "Back");
						ResetPinAndCounterValues();
						ResetCircles(grid);
					}
				}
			}
		}
		private void BackButton_Clicked(object sender, EventArgs e, Grid grid)
		{
			if(ClickCounter > 0)
			{
				foreach (var child in grid.Children)
				{
					if (Grid.GetColumn(child) == ClickCounter-1)
					{
						child.BackgroundColor = Color.Black;
					}
				}
				PinValue = PinValue.Remove(ClickCounter-1, 1);
				ClickCounter--;
			}
		}
		private void ResetPinAndCounterValues()
		{
			PinValue = PinValue.Remove(0, 4);
			ClickCounter = 0;
		}
		private void FillCircles(Grid grid)
		{
			foreach (var child in grid.Children)
			{
				if (Grid.GetColumn(child) == ClickCounter)
				{
					child.BackgroundColor = Color.LightGray;
				}
			}
		}
		private void ResetCircles(Grid grid)
		{
			foreach (var child in grid.Children)
			{
				child.BackgroundColor = Color.Black;
			}
		}
		private async void RedirectToGalleryPage()
		{
			await Navigation.PushAsync(new PicListPage());
		}
	}
}