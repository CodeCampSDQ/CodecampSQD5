using System;
using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SpeakerViewCell : ViewCell
	{
		public SpeakerViewCell ()
		{
			View = CreateView();
		}

		View CreateView ()
		{
			var builder = new RelativeBuilder();

			var background = new Image
			{
				Aspect = Aspect.AspectFill
			};

			background.SetBinding<Session>(Image.SourceProperty, m => m.BackgroundImage);

			var shim = new BoxView
			{
				BackgroundColor = Color.Black,
				Opacity = 0.4
			};

			var charlista = new Label
			{
				TextColor = Color.White,
				FontSize = 26
			};

			charlista.SetBinding<Session>(Label.TextProperty, m => m.Charlista);

			var lugar = new Label
			{
				TextColor = Color.White
			};

			lugar.SetBinding<Session>(Label.TextProperty, m => m.Lugar);

			var hora = new Label
			{
				TextColor = Color.White,
				FontSize = 12
			};

			hora.SetBinding<Session>(Label.TextProperty, m => m.Hora);

			builder
				.AddView(background)
				.ExpandViewToParentXY();

			builder
				.AddView(shim)
				.ExpandViewToParentXY();

			builder
				.AddView(charlista)
				.AlignParentCenterXY();

			builder
				.AddView(lugar)
				.BelowOf(charlista)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,32,0,0));

			builder
				.AddView(hora)
				.AlignTop(lugar)
				.AlignParentRight()
				.WithPadding(new Thickness(0,4,12,0));

			return builder.BuildLayout();
		}
	}
}

