using Akavache;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class CodeCampSDQApp : Application
	{
		public CodeCampSDQApp ()
		{
            BlobCache.ApplicationName = "CodeCampSDQ5";
            MainPage = new HomeScreen();
        }
	}
}

