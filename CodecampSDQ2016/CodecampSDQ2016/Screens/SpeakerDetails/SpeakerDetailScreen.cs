using System;

using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SpeakerDetailScreen : Screen<SpeakerDetailViewModel>
	{
		RelativeLayout _relativeLayout;

		public override View CreatePageContent ()
		{
			BackgroundColor = Color.White;

			var image = new Image
			{
				HeightRequest = 200,
				Aspect = Aspect.AspectFill
			};

			image.SetBinding<SpeakerDetailViewModel>(Image.SourceProperty, m => m.ProfilePicture);

			var speakerName = new Label
			{
				TextColor = Color.White,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold
			};

			speakerName.SetBinding<SpeakerDetailViewModel>(Label.TextProperty, m => m.SpeakerName);

			var bio = new Label
			{
				TextColor = Color.Gray,
				FontSize = 14
			};
				
			bio.SetBinding<SpeakerDetailViewModel>(Label.TextProperty, m => m.Bio);

			var charlasCount = new Label
			{
				TextColor = Color.White,
				FontSize = 14
			};

			charlasCount.SetBinding<SpeakerDetailViewModel>(Label.TextProperty, m => m.CharlasCount);

			var url = new Button
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 14,
				BackgroundColor = Color.Transparent
			};

			url.SetBinding<SpeakerDetailViewModel>(Button.TextProperty, m => m.Url);

			var socialApps = new Button
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 14,
				BackgroundColor = Color.Transparent
			};

			socialApps.SetBinding<SpeakerDetailViewModel>(Button.TextProperty, m => m.SocialApps);

			var sessionList = new ListView {
				ItemTemplate = new DataTemplate (typeof(SpeakerDetailsViewCell)),
				RowHeight = 80,
				HeightRequest = DataContext.Sessions.Count * 100
			};

			sessionList.ItemSelected += (sender, e) => 
			{
				if (e.SelectedItem == null)
					return;

				((ListView)sender).SelectedItem = null;
			};

			sessionList.SetBinding<SpeakerDetailViewModel>(ListView.ItemsSourceProperty, m => m.Sessions);

			var view = new BoxView { Color = Color.Black, HeightRequest = 200, Opacity = 0.6 };

			var urlContainer = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Spacing = 16,
				Children = 
				{
					url,
					socialApps
				}
			}; 

			var sessionTitle = new Label
			{
				Text = "Sessions",
				FontAttributes = FontAttributes.Bold,
				FontSize = 20,
				TextColor = Color.Gray
			};

			_relativeLayout = new RelativeLayout {
				Children = { {
						image,
						Constraint.RelativeToParent (p => 0),
						Constraint.RelativeToParent (p => 0),
						Constraint.RelativeToParent (p => p.Width) 
					}, {
						view,
						Constraint.RelativeToParent (p => 0),
						Constraint.RelativeToParent(p => 0),
						Constraint.RelativeToParent (p => p.Width) 
					}, {
						speakerName,
						Constraint.RelativeToParent (p => p.Width / 2 - speakerName.Width / 2),
						Constraint.RelativeToView (view, (p, v) => v.Height / 2 - (speakerName.Height / 2) - 15) 
					}, {
						charlasCount,
						Constraint.RelativeToParent (p => p.Width / 2 - charlasCount.Width / 2),
						Constraint.RelativeToView (speakerName, (p, v) => v.Y + v.Height + 12) 
					}
					,{
						urlContainer,
						Constraint.RelativeToParent (p => p.Width / 2 - urlContainer.Width / 2),
						Constraint.RelativeToView (charlasCount, (p, v) => v.Y + v.Height + 12) 
					}, {
						bio,
						Constraint.RelativeToParent (p => 24),
						Constraint.RelativeToView (image, (p, v) => v.Y + v.Height + 30),
						Constraint.RelativeToParent(p => p.Width - 48)
					},
					{
						sessionTitle,
						Constraint.RelativeToParent(p => p.Width / 2 - sessionTitle.Width / 2),
						Constraint.RelativeToView(bio,(p,v) => v.Y + v.Height + 16) 
					},
					{
						sessionList,
						Constraint.RelativeToParent(p => p.Width / 2 - sessionList.Width / 2),
						Constraint.RelativeToView(sessionTitle,(p,v) => v.Y + v.Height + 12)
					}
				}
			};
 			
			_relativeLayout.PropertyChanged += OnPropertyChangedA;

			return _relativeLayout;
		}

		public void OnPropertyChangedA (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(e.PropertyName.Equals ("Width") || e.PropertyName.Equals("Height"))
			{
				_relativeLayout.ForceLayout ();
			}
		}
	}

}

