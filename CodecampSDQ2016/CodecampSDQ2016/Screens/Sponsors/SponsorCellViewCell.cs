using System;
using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SponsorViewCell : ViewCell
	{
		public SponsorViewCell ()
		{
			View = CreateView();
		}

		View CreateView ()
		{
			var builder = new RelativeBuilder();

			var sponsor = new Image
			{
				Aspect = Aspect.AspectFit,
				WidthRequest = 200,
				HeightRequest = 200
			};

			sponsor.SetBinding<Sponsor>(Image.SourceProperty, m => m.Logo);

			builder
				.AddView(sponsor)
				.AlignParentCenterXY();

			return builder.BuildLayout();
		}
	}
}

