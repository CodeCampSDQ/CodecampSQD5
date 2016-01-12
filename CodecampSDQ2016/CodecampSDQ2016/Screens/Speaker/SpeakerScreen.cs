using System;

using Xamarin.Forms;
using Marioneta;
using System.Threading.Tasks;

namespace CodecampSDQ2016
{
	public class SpeakerScreen : Screen<SpeakerViewModel>
	{
		public SpeakerScreen ()
		{
			
		}

		public override View CreatePageContent ()
		{
			var image = new Image
			{
				Aspect = Aspect.AspectFill,
				HeightRequest = 200
			};

			image.SetBinding<SpeakerViewModel>(Image.SourceProperty, m => m.Header);

			var headerTitle = new Label
			{
				TextColor = Color.White,
				FontSize = 28,
				FontAttributes = FontAttributes.Bold
			};

			headerTitle.SetBinding<SpeakerViewModel>(Label.TextProperty, m => m.HeaderTitle);

			var headerDescription = new Label
			{
				TextColor = Color.White,
				FontSize = 14
			};

			headerDescription.SetBinding<SpeakerViewModel>(Label.TextProperty, m => m.HeaderDescription);

			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(SpeakerViewCell)),
				RowHeight = 180,
				IsPullToRefreshEnabled = true
			};

			listView.SetBinding<SpeakerViewModel>(ListView.RefreshCommandProperty, m => m.PullToRefreshCommand);

			listView.SetBinding<SpeakerViewModel>(ListView.IsRefreshingProperty, m => m.IsLoading);

			listView.SetBinding<SpeakerViewModel>(ListView.IsPullToRefreshEnabledProperty, m => m.PullToRefreshEnabled);

			listView.ItemSelected += async(sender, e) => 
			{
				if (e.SelectedItem == null)
					return;

				await SelectedSpeakerCommand(e.SelectedItem);

				((ListView)sender).SelectedItem = null;
			};

			listView.SetBinding<SpeakerViewModel>(ListView.ItemsSourceProperty, m => m.Speakers);

			var content = (RelativeLayout) new RelativeBuilder()
				.AddView(image)
				.ExpandViewToParentWidth()
				.AddView(headerTitle)
				.AlignParentCenterHorizontal()
				.WithPadding(new Thickness(0,70,0,0))
				.ApplyConfiguration((p,v)=>
					{
						p.HeightRequest = 200;
					})
				.BuildLayout();

			content.VerticalOptions = LayoutOptions.Start;

			content
				.Children.Add(headerDescription,
					Constraint.RelativeToParent(p => p.Width / 2 - 54),
					Constraint.RelativeToView(headerTitle, (p,v) => (v.Y + v.Height + 16)));

			return new StackLayout
			{
				Spacing = 0,
				Children = 
				{
					content,
					listView
				}
			};
		}

		async Task SelectedSpeakerCommand (object selectedItem)
		{
			var speaker = selectedItem as Speaker;

			if(speaker != null)
			{
				await Navigation.PushAsync(new SpeakerDetailScreen(speaker));
			}
		}
	}

}

