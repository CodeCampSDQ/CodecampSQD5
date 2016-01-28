using System;

using Xamarin.Forms;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using CodecampSDQ2016.Services.Cache;
using System.Threading.Tasks;

namespace CodecampSDQ2016
{
	public class HomeScreen : TabbedPage
	{
		public HomeScreen ()
		{
			Title = "CodeCampSDQ";

			InitTabs();
		}

		void InitTabs ()
		{
			this.Children.Add(new NavigationPage(new SessionScreen (){Title = "Charlas",Icon = "ic_charlas_home"}){Title = "Charlas",Icon = "ic_charlas_home",BarBackgroundColor = Device.OnPlatform<Color>(Color.FromHex("3498db"),
				Color.Black,Color.Black),
				BarTextColor = Device.OnPlatform<Color>(Color.White,Color.Black,Color.Black)});

			this.Children.Add(new NavigationPage(new SpeakerScreen (){Title = "Charlistas"}){Title = "Charlistas" , Icon = "ic_charlistas_home", 
				BarBackgroundColor = Device.OnPlatform<Color>(Color.FromHex("3498db"),Color.Black,Color.Black), 
				BarTextColor = Device.OnPlatform<Color>(Color.White,Color.Black,Color.Black)});
			
			this.Children.Add(new NavigationPage(new SponsorScreen () { Title = "Sponsors" , Icon = "sponsors" }){Icon = "ic_patrocinadores_home", Title = "Sponsors",
				BarBackgroundColor = Device.OnPlatform<Color>(Color.FromHex("3498db"),Color.Black,Color.Black), 
				BarTextColor = Device.OnPlatform<Color>(Color.White,Color.Black,Color.Black)});
			
			this.Children.Add(new NavigationPage(new TweetItScreen () { Title = "ElCoro" , Icon = "sponsors" }){Icon = "sponsors", Title = "#ElCoro",
				BarBackgroundColor = Device.OnPlatform<Color>(Color.FromHex("3498db"),Color.Black,Color.Black), 
				BarTextColor = Device.OnPlatform<Color>(Color.White,Color.Black,Color.Black)});	
		} 
	}
}

