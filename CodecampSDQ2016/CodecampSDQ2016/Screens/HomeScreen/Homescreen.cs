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
			Title = "CodeCampSDQ";

			//Not binding to ViewModel
//			this.SetBinding<HomeViewModel>(TabbedPage.ItemsSourceProperty, m => m.Tabs);

			this.Children.Add(new NavigationPage(new SessionScreen () { Title = "Charlas" , Icon = "sessions"}){Title = "Charlas", Icon = "sessions"});
			this.Children.Add(new NavigationPage(new SpeakerScreen (){Title = "Charlistas"}){Title = "Charlistas" , Icon = "speakers" });
			this.Children.Add(new SponsorScreen () { Title = "Patrocinadores" , Icon = "sponsors" });
//			this.Children.Add(new ContentPage () { Title = "Redes Sociales"  , Icon = "globe"});
		}
	}
}

