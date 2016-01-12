using System;
using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SocialAppScreen : Screen<SocialAppViewModel>
	{
		public SocialAppScreen (Speaker speaker)
		{
			DataContext.Init(speaker);
		}

		public override View CreatePageContent ()
		{
			this.SetBinding<SocialAppViewModel>(BackgroundColorProperty, m => m.BackgroundColor);

			this.SetBinding<SocialAppViewModel>(TitleProperty, m => m.Title);

			var image = new Image
			{
				Aspect = Aspect.AspectFill,
				HeightRequest = 200
			};

			image.SetBinding<SocialAppViewModel>(Image.SourceProperty, m => m.Header, BindingMode.Default, new FromBinaryToImageDataSource());

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
			headerDescription.SetBinding<SocialAppViewModel>(Button.CommandProperty, m => m.HeaderSelected);

			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(SocialAppViewCell)),
				RowHeight = 80,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			listView.ItemSelected += (sender, e) => 
			{
				if (e.SelectedItem == null)
					return;

				DataContext.NavigateToSocial.Execute(e.SelectedItem);

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
				.WithPadding(new Thickness(0,70,0,0));

			content
				.AddView(headerDescription)
				.BelowOf(headerTitle)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,12,0,0))
				.ApplyConfiguration((p,v)=>
					{
					p.HeightRequest = 200;
				});

			var layout = (RelativeLayout) content.BuildLayout();
			layout.VerticalOptions = LayoutOptions.Start;
			
			return new StackLayout
			{
				Spacing = 0,
				Children = 
				{
					layout,
					listView
				}
			};
		}
	}
}

