using Akavache;
using Xamarin.Forms;
using System.Threading.Tasks;
using CodecampSDQ2016.Services.Data;

namespace CodecampSDQ2016
{
	public class CodeCampSDQApp : Application
	{
		public CodeCampSDQApp ()
		{
            BlobCache.ApplicationName = "CodeCampSDQ5";

			MainPage = new NavigationPage(new HomeScreen());
        }
	}
}

