using System;

using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class HomeScreen : TabbedPage
	{
		public HomeScreen ()
		{
			SetBindings();
		}

		void SetBindings ()
		{
			//Not binding to ViewModel
//			this.SetBinding<HomeViewModel>(TabbedPage.ItemsSourceProperty, m => m.Tabs);

			this.Children.Add(new SessionScreen () { Title = "Sesiones" , Icon = "globe"});
			this.Children.Add(new SpeakerScreen () { Title = "Charlista" , Icon = "globe" });
			this.Children.Add(new ContentPage () { Title = "Sponsors" , Icon = "globe" });
			this.Children.Add(new ContentPage () { Title = "Redes Sociales"  , Icon = "globe"});
		}
	}
}

