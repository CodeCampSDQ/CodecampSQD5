using System;

using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SpeakerScreen : Screen<SpeakerViewModel>
	{
		public SpeakerScreen ()
		{
			
		}

		public override View CreatePageContent ()
		{
			var listView = new ListView
			{
				ItemTemplate = new DataTemplate(typeof(SpeakerViewCell)),
				RowHeight = 180
			};

			listView.ItemSelected += (sender, e) => 
			{
				if (e.SelectedItem == null)
					return;

				((ListView)sender).SelectedItem = null;
			};

			listView.SetBinding<SpeakerViewModel>(ListView.ItemsSourceProperty, m => m.Speakers);

			return listView;
		}
	}

}

