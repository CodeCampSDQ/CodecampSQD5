using Akavache;
using Xamarin.Forms;
using System.Threading.Tasks;
using CodecampSDQ2016.Services.Data;
using System;
using Plugin.Connectivity;
using Marioneta;

namespace CodecampSDQ2016
{
	public class NotConnectedToInternetScreen : Screen<NotConnectedToInternetViewModel>
	{
		public View CreateEmptyState ()
		{
			var wifiIcon = new Image
			{
				Aspect = Aspect.AspectFit,
				WidthRequest = 100,
				HeightRequest = 100,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			wifiIcon.SetBinding<NotConnectedToInternetViewModel>(Image.SourceProperty, m => m.Icon);

			var title = new Label
			{
				FontAttributes = FontAttributes.Bold,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			title.SetBinding<NotConnectedToInternetViewModel>(Label.TextProperty, m => m.Title);

			var subText = new Label
			{
				FontSize = 14,
				TextColor = Color.Gray,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			subText.SetBinding<NotConnectedToInternetViewModel>(Label.TextProperty, m => m.SubText);

			return new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding = new Thickness(4),
				Spacing = 12,
				Children = 
				{
					wifiIcon,
					title,
					subText
				}
			};
		}
	}
}

