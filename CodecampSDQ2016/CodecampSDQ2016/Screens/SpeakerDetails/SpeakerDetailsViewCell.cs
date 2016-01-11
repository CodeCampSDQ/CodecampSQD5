using System;
using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SpeakerDetailsViewCell : ViewCell
	{
		public SpeakerDetailsViewCell ()
		{
			View = CreateView();
		}

		View CreateView ()
		{
			var builder = new RelativeBuilder();

			var sessionName = new Label
			{
				TextColor = Color.Black,
				FontSize = 12
			};

			var sessionNameContainer = new StackLayout
			{
				Padding = new Thickness(0,0,16,0),
				Children = 
				{
					sessionName
				}
			};

			sessionName.SetBinding<Session>(Label.TextProperty, m => m.Charla);

			var lugar = new Label
			{ 
				FontSize = 12,
				TextColor = Color.FromHex("3498db"),
			};

			lugar.SetBinding<Session>(Label.TextProperty, m => m.Lugar);

			var hora = new Label
			{
				FontSize = 10,
				TextColor = Color.FromHex("3498db"),
			};

			hora.SetBinding<Session>(Label.TextProperty, m => m.HoraInicio);

			builder
				.AddView(new BoxView{BackgroundColor= Color.FromHex("efeff4")})
				.ExpandViewToParentXY();

			builder
				.AddView(sessionNameContainer)
				.ExpandViewToParentWidth()
				.WithPadding(new Thickness(16,12,0,0));

			builder
				.AddView(lugar)
				.BelowOf(sessionNameContainer)
				.AlignLeft(sessionNameContainer)
				.WithPadding(new Thickness(0,18,0,0));
			
			builder
				.AddView(hora)
				.AlignTop(lugar) 
				.AlignParentRight()
				.WithPadding(new Thickness(0,4,20,0));

			builder
				.ApplyConfiguration((p,v)=>{
					p.Padding = new Thickness(10);
			});

			return builder.BuildLayout();
		}
	}
}

