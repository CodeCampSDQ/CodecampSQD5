using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class SpeakerViewModel : ViewModelBase
	{
		public ObservableCollection<Speaker> Speakers { get; set; }

		public bool PullToRefreshEnabled { get; set; }

		public SpeakerViewModel ()
		{
			
		}

		public override void NavigateTo ()
		{
			PullToRefreshEnabled = true;

			Speakers = new ObservableCollection<Speaker>
			{
				new Speaker
				{
					Name = "Pinedax",
					FaceBackground = "pineda"
				},
				new Speaker
				{
					Name = "Luis Ramirez",
					FaceBackground = "luis"
				},
				new Speaker
				{
					Name = "Claudio Sanchez",
					FaceBackground = "claudio"
				},
				new Speaker
				{
					Name = "Jose Gregorio",
					FaceBackground = "gregorex"
				}
			};
		}
	}
}

