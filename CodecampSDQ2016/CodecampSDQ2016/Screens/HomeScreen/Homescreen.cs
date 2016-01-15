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
			this.Children.Add(new NavigationPage(new SessionScreen (){Title = "Charlas",Icon = "sessions"}){Title = "Charlas",Icon = "sessions",BarBackgroundColor = Device.OnPlatform<Color>(Color.FromHex("3498db"),
				Color.Black,Color.Black),
				BarTextColor = Device.OnPlatform<Color>(Color.White,Color.Black,Color.Black)});
			this.Children.Add(new NavigationPage(new SpeakerScreen (){Title = "Charlistas"}){Title = "Charlistas" , Icon = "speakers", 
				BarBackgroundColor = Device.OnPlatform<Color>(Color.FromHex("3498db"),Color.Black,Color.Black), 
				BarTextColor = Device.OnPlatform<Color>(Color.White,Color.Black,Color.Black)});
			this.Children.Add(new NavigationPage(new SponsorScreen () { Title = "Espónsores" , Icon = "sponsors" }){Icon = "sponsors", Title = "Espónsores",
				BarBackgroundColor = Device.OnPlatform<Color>(Color.FromHex("3498db"),Color.Black,Color.Black), 
				BarTextColor = Device.OnPlatform<Color>(Color.White,Color.Black,Color.Black)});
		}
	}
}

