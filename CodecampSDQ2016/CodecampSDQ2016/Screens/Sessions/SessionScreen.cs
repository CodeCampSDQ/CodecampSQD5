using System;

using Xamarin.Forms;
using Marioneta;
using System.Collections.Generic;

namespace CodecampSDQ2016
{
	public class SessionScreen : Screen<SessionViewModel>
	{
		public SessionScreen ()
		{
			
		}

		public override View CreatePageContent ()
		{
//			var image = new Image
//			{
//				Aspect = Aspect.AspectFill,
//				HeightRequest = 200
//			};
//
//			image.SetBinding<SessionViewModel>(Image.SourceProperty, m => m.Header);
//
//			var headerTitle = new Label
//			{
//				TextColor = Color.White,
//				FontSize = 28,
//				FontAttributes = FontAttributes.Bold
//			};
//
//			headerTitle.SetBinding<SessionViewModel>(Label.TextProperty, m => m.HeaderTitle);
//
//			var headerDescription = new Label
//			{
//				TextColor = Color.White,
//				FontSize = 12
//			};
//
//			headerDescription.SetBinding<SessionViewModel>(Label.TextProperty, m => m.HeaderDescription);

			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(SessionViewCell)),
				HasUnevenRows = true,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			listView.SetBinding<SessionViewModel>(ListView.IsPullToRefreshEnabledProperty, m => m.PullToRefreshEnabled);

			listView.SetBinding<SessionViewModel>(ListView.RefreshCommandProperty, m => m.PullToRefreshCommand);

			listView.SetBinding<SessionViewModel>(ListView.IsRefreshingProperty, m => m.IsLoading);

			listView.ItemSelected += (sender, e) => 
			{
				if (e.SelectedItem == null)
					return;

				OnSelectedItem((Session)e.SelectedItem);

				((ListView)sender).SelectedItem = null;
			};

			listView.SetBinding<SessionViewModel>(ListView.ItemsSourceProperty, m => m.Sessions);

//			var content = (RelativeLayout) new RelativeBuilder()
//				.AddView(image)
//				.ExpandViewToParentWidth()
//				.AddView(headerTitle)
//				.AlignParentCenterHorizontal()
//				.WithPadding(new Thickness(0,70,0,0))
//				.ApplyConfiguration((p,v)=>
//				{
//					p.HeightRequest = 200;
//				})
//				.BuildLayout();
//			
//			content.VerticalOptions = LayoutOptions.Start;
//
//			content
//				.Children.Add(headerDescription,
//				Constraint.RelativeToParent(p => p.Width / 2 - 126),
//				Constraint.RelativeToView(headerTitle, (p,v) => (v.Y + v.Height + 16)));
//
//			return new StackLayout
//			{
//				Spacing = 0,
//				Children = 
//				{
//					content,
//					listView
//				}
//			};

			return listView;
		}

		void OnSelectedItem (Session session)
		{
			Navigation.PushAsync(new SessionDetailScreen(session));
		}
	}
}