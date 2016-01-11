using System;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class SocialAppViewModel : ViewModelBase
	{
		public string Header { get; set; }

		public string HeaderTitle { get; set; }

		public string HeaderDescription { get; set; }

		public ObservableCollection<SocialApp> SocialApps { get; set; }

		public override void NavigateTo ()
		{
			Header = "gregorex";

			HeaderTitle = "Social Apps";

			HeaderDescription = "#codecampsdq";

			SocialApps = new ObservableCollection<SocialApp>
			{
				new SocialApp
				{
					Logo = "gplus",
					Name = "Google Plus"
				},
				new SocialApp
				{
					Logo = "fb",
					Name = "Facebook"
				},
				new SocialApp
				{
					Logo = "twitter",
					Name = "Twitter"
				},
				new SocialApp
				{
					Logo = "linked",
					Name = "LinkedIn"
				}
			};
		}
	}

}

