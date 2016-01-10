using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class SponsorViewModel : ViewModelBase
	{
		public ObservableCollection<Sponsor> Sponsors { get; set; }

		public bool PullToRefreshEnabled { get; set; }

		public string Header { get; set; }

		public string HeaderTitle { get; set; }

		public string HeaderDescription { get; set; }

		public SponsorViewModel ()
		{
			
		}

		public override void NavigateTo ()
		{
			PullToRefreshEnabled = true;

			Header = "sd";

			HeaderTitle = "SPONSORS";

			HeaderDescription = "The people who made this event possible";

			Sponsors = new ObservableCollection<Sponsor>
			{
				new Sponsor
				{
					Logo = "megsoft"
				},
				new Sponsor
				{
					Logo = "microsoft"
				},
				new Sponsor
				{
					Logo = "mic"
				},
				new Sponsor
				{
					Logo = "fundacionBalaguer"
				}
			};
		}
	}
}

