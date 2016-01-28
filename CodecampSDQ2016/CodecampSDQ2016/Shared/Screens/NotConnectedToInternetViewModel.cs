using Akavache;
using Xamarin.Forms;
using System.Threading.Tasks;
using CodecampSDQ2016.Services.Data;
using System;
using Tweetinvi.Core.Credentials;
using Plugin.Connectivity;

namespace CodecampSDQ2016
{
	public class NotConnectedToInternetViewModel : ViewModelBase
	{
		public string Icon { get; set; }

		public string Title { get; set; }

		public string SubText { get; set; }

		public override void NavigateTo ()
		{
			base.NavigateTo ();

			Icon = "wifi";

			Title = "No tienes una conexion a internet";

			SubText = "Reintente mas tarde por favor";
		}
	}

}

