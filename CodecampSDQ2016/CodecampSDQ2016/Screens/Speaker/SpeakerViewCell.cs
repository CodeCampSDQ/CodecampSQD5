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

			var face = new Image
			{
				Aspect = Aspect.AspectFill
			};

			face.SetBinding<Speaker>(Image.SourceProperty, m => m.FaceBackground);

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

			charlista.SetBinding<Speaker>(Label.TextProperty, m => m.Name);

			builder
				.AddView(face)
				.ExpandViewToParentXY();

			builder
				.AddView(shim)
				.ExpandViewToParentXY();

			builder
				.AddView(charlista)
				.AlignParentCenterXY();

			return builder.BuildLayout();
		}
	}
}

