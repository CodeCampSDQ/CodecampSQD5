using System;
using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SessionViewCell : ViewCell
	{
		public SessionViewCell ()
		{
			View = CreateView();
		}

		View CreateView ()
		{
			var sessionName = new Label
			{
				TextColor = Color.Black,
				FontSize = 14
			};

			var sessionNameContainer = new StackLayout
			{
				Padding = new Thickness(0,0,20,0),
				Children = 
				{
					sessionName
				}
			};

			sessionName.SetBinding<Session>(Label.TextProperty, m => m.Name);

			var lugar = new Label
			{
				TextColor = Color.Gray,
				FontSize = 12,
//				Text = "Location"
			};

			lugar.SetBinding<Session>(Label.TextProperty, m => m.Location);

			var hora = new Label
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 12
			};

			hora.SetBinding<Session>(Label.TextProperty, m => m.Time, BindingMode.Default, new TimeSpanToString());

			var stackLayout = new StackLayout
			{
				Padding = new Thickness(14,8,8,14),
				Spacing = 8,
				Children = 
				{
					new StackLayout
					{
						Spacing = 8,
						Orientation = StackOrientation.Horizontal,
						Children = 
						{
							hora
						}
					},
					new StackLayout
					{
						Spacing = 10,
						Children = 
						{
							sessionNameContainer,
							lugar
						}
					}
				}
			};

			return stackLayout;
		}
	}
}

