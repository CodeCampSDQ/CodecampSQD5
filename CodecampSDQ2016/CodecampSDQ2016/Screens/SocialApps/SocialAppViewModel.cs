using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace CodecampSDQ2016
{
	public class SocialAppViewModel : ViewModelBase
	{
		Speaker _speaker;

		public string Title { get; set; }

		public Color BackgroundColor { get; set; }

		public byte[] Header { get; set; }

		public string HeaderTitle { get; set; }

		public string HeaderDescription { get; set; }

		public bool GPlusExist { get; set; }

		public bool FacebookExist { get; set; }

		public bool TwitterExist { get; set; }

		public bool LinkedInExist { get; set; }

		public ICommand NavigateToSocial { get; set; }

		public ICommand HeaderSelected { get; set; }

		public ObservableCollection<SocialApp> SocialApps { get; set; }

		public SocialAppViewModel ()
		{
			NavigateToSocial = new Command<SocialApp>(OnNavigateToSocial);

			HeaderSelected = new Command(OnHeaderSelected);
		}

		void OnHeaderSelected ()
		{
			if(string.IsNullOrEmpty(_speaker.Email))
				return;

			Device.OpenUri(new Uri(string.Format("mailto:{0}",_speaker.Email)));
		}

		void OnNavigateToSocial (SocialApp selected)
		{
			if(string.IsNullOrEmpty(selected.Url))
				return;
			
			Device.OpenUri(new Uri(selected.Url));
		}

		public void Init (Speaker speaker)
		{
			_speaker = speaker;

			Header = speaker.BinaryPhoto;

			Title = speaker.Name;

			HeaderTitle = "See me on";

			HeaderDescription = string.Format("{0}", speaker.Email);

			BackgroundColor = Color.White;

			CheckSocialApps(speaker);
		}

		void CheckSocialApps (Speaker speaker)
		{
			GPlusExist = !string.IsNullOrWhiteSpace(speaker.GooglePlusAccount);

			FacebookExist = !string.IsNullOrEmpty(speaker.FacebookAccount);

			TwitterExist = !string.IsNullOrEmpty(speaker.TwitterAccount);

			LinkedInExist = !string.IsNullOrEmpty(speaker.LinkedInAccount);

			if(TwitterExist)
			{
				SocialApps.Add(new SocialApp
					{
						Logo = "twitter",
						Name = "Twitter",
						Url = speaker.TwitterAccount
					});
			}

			if(FacebookExist)
			{
				SocialApps.Add(new SocialApp
					{
						Logo = "fb",
						Name = "Facebook",
						Url = speaker.FacebookAccount
					});
			}

			if(GPlusExist)
			{
				SocialApps.Add(new SocialApp
					{
						Logo = "gplus",
						Name = "Google Plus",
						Url = speaker.GooglePlusAccount
					});
			}

			if(LinkedInExist)
			{
				SocialApps.Add(new SocialApp
					{
						Logo = "linked",
						Name = "LinkedIn",
						Url = speaker.LinkedInAccount
					});
			}
		}

		public override void NavigateTo ()
		{
			SocialApps = new ObservableCollection<SocialApp>();
		}
	}

}

