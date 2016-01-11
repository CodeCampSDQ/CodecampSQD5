using System;
using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SocialAppScreen : Screen<SocialAppViewModel>
	{
		public override View CreatePageContent ()
		{
			BackgroundColor = Color.FromHex("D3D3D3");

			var image = new Image
			{
				Aspect = Aspect.AspectFill,
				HeightRequest = 200
			};

			image.SetBinding<SocialAppViewModel>(Image.SourceProperty, m => m.Header);

			var headerTitle = new Label
			{
				TextColor = Color.White,
				FontSize = 28,
				FontAttributes = FontAttributes.Bold
			};

			headerTitle.SetBinding<SocialAppViewModel>(Label.TextProperty, m => m.HeaderTitle);

			var headerDescription = new Button
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 14
			};

			headerDescription.SetBinding<SocialAppViewModel>(Button.TextProperty, m => m.HeaderDescription);

			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(SocialAppViewCell)),
				RowHeight = 80
			};

			listView.ItemSelected += (sender, e) => 
			{
				if (e.SelectedItem == null)
					return;

				((ListView)sender).SelectedItem = null;
			};

			listView.SetBinding<SocialAppViewModel>(ListView.ItemsSourceProperty, m => m.SocialApps);

			var content = new RelativeBuilder();

			content
				.AddView(image)
				.ExpandViewToParentWidth();

			content
				.AddView(new BoxView { Color = Color.Black, HeightRequest = 200, Opacity = 0.6 } )
				.ExpandViewToParentWidth();

			content
				.AddView(headerTitle)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,90,0,0));

			content
				.AddView(headerDescription)
				.BelowOf(headerTitle)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,12,0,0))
				.ApplyConfiguration((p,v)=>
					{
					p.HeightRequest = 160;
				});
				
			return new StackLayout
			{
				Spacing = 0,
				Children = 
				{
					content.BuildLayout(),
					listView
				}
			};
		}
	}
}

