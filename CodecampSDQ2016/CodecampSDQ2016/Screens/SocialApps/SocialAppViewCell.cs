using System;
using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SocialAppViewCell : ViewCell
	{
		public SocialAppViewCell ()
		{
			View = CreateContent();
		}

		View CreateContent ()
		{
			var icon = new Image
			{
				WidthRequest = 52,
				HeightRequest = 52
			};

			icon.SetBinding<SocialApp>(Image.SourceProperty, m => m.Logo);

			var label = new Label
			{
				TextColor = Color.Black
			};

			label.SetBinding<SocialApp>(Label.TextProperty, m => m.Name);

			var builder = new RelativeBuilder();

			builder
				.AddView(icon)
				.WithPadding(new Thickness(16,0,0,0));

			builder
				.AddView(label)
				.AlignParentCenterHorizontal()
				.AlignParentCenterVertical()
				.WithPadding(new Thickness (0,0,16,16));

			return new StackLayout
			{
				BackgroundColor = Color.White,
				Padding = new Thickness(8, 16),
				Children = 
				{
					builder.BuildLayout()
				}
			};
		}
	}

}

