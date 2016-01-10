using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class HomeViewModel : ViewModelBase
	{
		public ObservableCollection<ContentPage> Tabs { get; set; }

		public override void NavigateTo ()
		{
			Tabs = new ObservableCollection<ContentPage>
			{
				new ContentPage () { Title = "Sesiones" , Icon = "globe"},
				new SpeakerScreen () { Title = "Charlista" , Icon = "globe" },
				new ContentPage () { Title = "Sponsors" , Icon = "globe" },
				new ContentPage () { Title = "Redes Sociales"  , Icon = "globe"}
			};
		}
	}


}

