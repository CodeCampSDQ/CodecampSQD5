using Akavache;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class CodeCampSDQApp : Application
	{
		public CodeCampSDQApp ()
		{
			MainPage = new HomeScreen();
		    BlobCache.ApplicationName = "CodeCampSDQ5";
		}
	}
}

