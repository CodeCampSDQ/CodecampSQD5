using Akavache;
using Xamarin.Forms;
using System.Threading.Tasks;
using CodecampSDQ2016.Services.Data;
using System;
using Tweetinvi.Core.Credentials;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using CodecampSDQ2016.Services.Cache;

namespace CodecampSDQ2016
{
	public class App : Application
	{ 
		public App ()
		{
			BlobCache.ApplicationName = "CodeCampSDQ5";

			MainPage = new HomeScreen();
        }
	}
}

