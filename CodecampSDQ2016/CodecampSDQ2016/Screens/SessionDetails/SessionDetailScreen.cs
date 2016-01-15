using System;

using Xamarin.Forms;
using Marioneta;
using System.Threading.Tasks;

namespace CodecampSDQ2016
{
	public class SessionDetailScreen : Screen<SessionDetailViewModel>
	{
		RelativeLayout _relativeLayout;

		public SessionDetailScreen (Session session)
		{
			DataContext.Init(session);
		}

		public override View CreatePageContent ()
		{
			this.SetBinding<SessionDetailViewModel>(TitleProperty, m => m.SpeakerName);

			BackgroundColor = Color.White;

			var sessionTitle = new Label
			{
				TextColor = Color.Black,
				FontSize = 18,
				FontAttributes = FontAttributes.Bold
			};

			sessionTitle.SetBinding<SessionDetailViewModel>(Label.TextProperty, m => m.SessionName);

			var desc = new Label
			{
				TextColor = Color.Black,
				FontSize = 14
			};

			desc.SetBinding<SessionDetailViewModel>(Label.TextProperty, m => m.Description);

			var descTitle = new Label
			{
				TextColor = Color.Gray,
				FontSize = 14
			};

			descTitle.SetBinding<SessionDetailViewModel>(Label.TextProperty, m => m.DescriptionTitle);

			var timeTitle = new Label
			{
				TextColor = Color.Gray,
				FontSize = 14
			};

			timeTitle.SetBinding<SessionDetailViewModel>(Label.TextProperty, m => m.TimeTitle);

			var time = new Label
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 14
			};

			time.SetBinding<SessionDetailViewModel>(Label.TextProperty, m => m.Time);

			var Timecontainer = new StackLayout
			{
				Children = 
				{
					timeTitle,
					new BoxView
					{
						Color = Color.Gray,
						HeightRequest = 1,
						HorizontalOptions = LayoutOptions.FillAndExpand
					},
					time
				}
			};

			var descContainer = new StackLayout
			{
				Padding = new Thickness(0,0,12,0),
				Children = 
				{
					descTitle,
					new BoxView
					{
						Color = Color.Gray,
						HeightRequest = 1,
						HorizontalOptions = LayoutOptions.FillAndExpand
					},
					new StackLayout
					{
						Padding = new Thickness(0,0,0,8),
						Children = 
						{
							desc
						}
					}
				}
			};

			var locationTitle = new Label
			{
				TextColor = Color.Gray,
				FontSize = 14
			};

			locationTitle.SetBinding<SessionDetailViewModel>(Label.TextProperty, m => m.LocationTitle);

			var location = new Label
			{
				TextColor = Color.Black,
				FontSize = 14
			};

			location.SetBinding<SessionDetailViewModel>(Label.TextProperty, m => m.Location);

			var locationContainer = new StackLayout
			{
				Children = 
				{
					locationTitle,
					new BoxView
					{
						Color = Color.Gray,
						HeightRequest = 1,
						HorizontalOptions = LayoutOptions.FillAndExpand
					},
					location
				}
			};
			
			_relativeLayout = new RelativeLayout {
				Padding = new Thickness(0,0,0,20),
				Children = {
					 {
						sessionTitle,
						Constraint.RelativeToParent(p => 12),
						Constraint.RelativeToParent(p => 20),
						Constraint.RelativeToParent(p => p.Width - 16)
					},
					{
						Timecontainer,
						Constraint.RelativeToParent(p => 12),
						Constraint.RelativeToView(sessionTitle, (p,v) => v.Y + v.Height + 16),
						Constraint.RelativeToParent(p => p.Width - 12)
					},
					{
						locationContainer,
						Constraint.RelativeToParent(p => 12),
						Constraint.RelativeToView(Timecontainer , (p,v) => v.Y + v.Height + 16),
						Constraint.RelativeToParent(p => p.Width - 12)
					},
					{
						descContainer,
						Constraint.RelativeToParent(p => 12),
						Constraint.RelativeToView(locationContainer, (p,v) => v.Y + v.Height + 16),
						Constraint.RelativeToParent(p => p.Width - 12)
					}
				}
			};
 			
			_relativeLayout.PropertyChanged += OnPropertyChangedA;

			return new ScrollView
			{
				Content = _relativeLayout
			};
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

