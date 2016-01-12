using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CodecampSDQ2016
{
	public class HomeViewModel : ViewModelBase
	{
		public ObservableCollection<ContentPage> Tabs { get; set; }

		public async override void NavigateTo ()
		{
			
			Tabs = new ObservableCollection<ContentPage>
			{
				new SessionScreen () { Title = "Sesiones" , Icon = "globe"},
				new SpeakerScreen () { Title = "Charlista" , Icon = "globe" },
				new ContentPage () { Title = "Sponsors" , Icon = "globe" },
				new ContentPage () { Title = "Redes Sociales"  , Icon = "globe"}
			};
		}
	}
}

