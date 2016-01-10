using System;

using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SessionScreen : Screen<SessionViewModel>
	{
		public SessionScreen ()
		{
			
		}

		public override View CreatePageContent ()
		{
			var image = new Image
			{
				Aspect = Aspect.AspectFill,
				HeightRequest = 200
			};

			image.SetBinding<SessionViewModel>(Image.SourceProperty, m => m.Header);

			var headerTitle = new Label
			{
				TextColor = Color.White,
				FontSize = 28,
				FontAttributes = FontAttributes.Bold
			};

			headerTitle.SetBinding<SessionViewModel>(Label.TextProperty, m => m.HeaderTitle);

			var headerDescription = new Label
			{
				TextColor = Color.White,
				FontSize = 12
			};

			headerDescription.SetBinding<SessionViewModel>(Label.TextProperty, m => m.HeaderDescription);

			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(SessionViewCell)),
				RowHeight = 140
			};

			listView.ItemSelected += (sender, e) => 
			{
				if (e.SelectedItem == null)
					return;

				((ListView)sender).SelectedItem = null;
			};

			listView.SetBinding<SessionViewModel>(ListView.ItemsSourceProperty, m => m.Sessions);

			return new RelativeBuilder()
				.AddView(image)
				.ExpandViewToParentWidth()
				.AddView(headerTitle)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,90,0,0))
				.AddView(headerDescription)
				.BelowOf(headerTitle)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,12,0,0))
				.AddView(listView)
				.WithPadding(new Thickness(0,16,0,0))
				.BelowOf(image)
				.BuildLayout();
		}
	}

}

