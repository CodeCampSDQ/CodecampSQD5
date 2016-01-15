using System;
using Xamarin.Forms;
using Marioneta;
using ImageCircle.Forms.Plugin.Abstractions;

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

			var face = new CircleImage
			{
				Aspect = Aspect.AspectFit,
				BorderColor = Color.White,
				BorderThickness = 3,
				HeightRequest = 64,
				WidthRequest = 64,
			};

			face.SetBinding<Speaker>(Image.SourceProperty, m => m.BinaryPhoto, BindingMode.Default, new FromBinaryToImageDataSource());

			var faceContainer = new StackLayout
			{	Padding = new Thickness(12,12,20,12),
				Children = 
				{
					face
				}
			};

			var charlista = new Label
			{
				TextColor = Color.Black,
				FontSize = 20
			};

			charlista.SetBinding<Speaker>(Label.TextProperty, m => m.Name);

			builder
				.AddView(faceContainer);

			builder
				.AddView(charlista)
				.ToRightOf(faceContainer)
				.AlignParentCenterVertical();

			return builder.BuildLayout();
		}
	}
}

