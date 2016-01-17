using System;

using Xamarin.Forms;
using Marioneta;
using System.Threading.Tasks;
using ImageCircle.Forms.Plugin.Abstractions;

namespace CodecampSDQ2016
{
	public class SpeakerDetailScreen : Screen<SpeakerDetailViewModel>
	{
		RelativeLayout _relativeLayout;

		public SpeakerDetailScreen (Speaker speaker)
		{
			DataContext.Init(speaker);
		}

		public override View CreatePageContent ()
		{
			this.SetBinding<SpeakerDetailViewModel>(TitleProperty, m => m.SpeakerName);

			BackgroundColor = Color.White;

			var image = new CircleImage
			{
				Aspect = Aspect.AspectFit,
				BorderColor = Color.White,
				BorderThickness = 3,
				HeightRequest = 96,
				WidthRequest = 96,
			};
			image.SetBinding<SpeakerDetailViewModel>(Image.SourceProperty, m => m.ProfilePicture, BindingMode.Default, new FromBinaryToImageDataSource());

			var biox = new Label
			{
				TextColor = Color.Gray,
				FontSize = 14
			};
				
			biox.SetBinding<SpeakerDetailViewModel>(Label.TextProperty, m => m.Bio);

			var bio = new StackLayout
			{
				Padding = new Thickness(10,0),
				Children = 
				{
					biox
				}
			};

			var bioDesc = new Label
			{
				FontAttributes = FontAttributes.Bold,
				FontSize = 20,
				TextColor = Color.Black
			};

			bioDesc.SetBinding<SpeakerDetailViewModel>(Label.TextProperty, m => m.CharlasCount);

			var url = new Button
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 14,
				BackgroundColor = Color.Transparent
			};

			url.SetBinding<SpeakerDetailViewModel>(Button.CommandProperty,m => m.OnUrlTapCommand);

			url.SetBinding<SpeakerDetailViewModel>(Button.TextProperty, m => m.GitHubUrlDesc);

			var socialApps = new Button
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 14,
				BackgroundColor = Color.Transparent
			};

			socialApps.Clicked += OnSocialAppsSelected;

			socialApps.SetBinding<SpeakerDetailViewModel>(Button.TextProperty, m => m.SocialAppsDesc);

			var sessionList = new ListView {
				ItemTemplate = new DataTemplate (typeof(SessionViewCell)),
				RowHeight = 100,
//				HeightRequest = DataContext.Sessions.Count * 100
			};

			sessionList.ItemSelected += (sender, e) => 
			{
				if (e.SelectedItem == null)
					return;
				
				OnSelectedItem((Session) e.SelectedItem);

				((ListView)sender).SelectedItem = null;
			};

			sessionList.SetBinding<SpeakerDetailViewModel>(ListView.ItemsSourceProperty, m => m.Sessions);

//			var view = new BoxView { Color = Color.Black, HeightRequest = 200, Opacity = 0.6 };
//
//			var urlContainer = new StackLayout
//			{
//				Orientation = StackOrientation.Horizontal,
//				Spacing = 16,
//				Children = 
//				{
//					url,
//					socialApps
//				}
//			}; 

			var sessionTitle = new Label
			{
				FontAttributes = FontAttributes.Bold,
				FontSize = 18,
				TextColor = Color.Black
			};

			sessionTitle.SetBinding<SpeakerDetailViewModel>(Label.TextProperty,m => m.SessionTitle);

			var container = new StackLayout
			{
				Children = 
				{
					sessionTitle,
					new BoxView
					{
						Color = Color.Gray,
						HeightRequest = 1,
						HorizontalOptions = LayoutOptions.FillAndExpand
					}
				}
			};

			var container2 = new StackLayout
			{
				Children = 
				{
					bioDesc,
					new BoxView
					{
						Color = Color.Gray,
						HeightRequest = 1,
						HorizontalOptions = LayoutOptions.FillAndExpand
					}
				}
			};

			container2.SetBinding<SpeakerDetailViewModel>(VisualElement.IsVisibleProperty,m => m.HasBio);

			_relativeLayout = new RelativeLayout {
				Children = { 
					{
						image,
						Constraint.RelativeToParent (p => 0),
						Constraint.RelativeToParent (p => 0),
						Constraint.RelativeToParent (p => p.Width) 
					},
//					{
//						view,
//						Constraint.RelativeToParent (p => 0),
//						Constraint.RelativeToParent(p => 0),
//						Constraint.RelativeToParent (p => p.Width) 
//					},
					{
						container2,
						Constraint.RelativeToParent (p => 10),
						Constraint.RelativeToParent (p => 16),
						Constraint.RelativeToParent(p => p.Width)
					}
//					,{
//						urlContainer,
//						Constraint.RelativeToParent (p => p.Width / 2 - urlContainer.Width / 2),
//						Constraint.RelativeToView (charlasCount, (p, v) => v.Y + v.Height + 12) 
//					}, 
					,{
						bio,
						Constraint.RelativeToParent (p => 0),
						Constraint.RelativeToView (container2, (p, v) => v.Y + v.Height + 12),
						Constraint.RelativeToParent(p => p.Width)
					},
					 {
						container,
						Constraint.RelativeToView(container2, (p,v) => v.X),
						Constraint.RelativeToView(bio,(p,v) => v.Y + v.Height + 10) ,
						Constraint.RelativeToParent(p => p.Width)
					},
					{
						sessionList,
						Constraint.RelativeToParent(p => p.Width / 2 - sessionList.Width / 2),
						Constraint.RelativeToView(container,(p,v) => v.Y + v.Height + 16)
					}
				}
			};
 			
			_relativeLayout.PropertyChanged += OnPropertyChangedA;

			return _relativeLayout;
		}

		async void OnSocialAppsSelected(object sender, EventArgs e)
		{
			await Navigation.PushAsync (new SocialAppScreen (DataContext.Speaker));
		}

		public void OnPropertyChangedA (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(e.PropertyName.Equals ("Width") || e.PropertyName.Equals("Height"))
			{
				_relativeLayout.ForceLayout ();
			}
		}

		void OnSelectedItem (Session session)
		{
			Navigation.PushAsync(new SessionDetailScreen(session));
		}
	}

}

