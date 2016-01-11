using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class SpeakerDetailViewModel : ViewModelBase
	{
		public ObservableCollection<Session> Sessions { get; set; }

		public string SpeakerName { get; set; }

		public string Bio { get; set; }

		public string ProfilePicture { get; set; }

		public string CharlasCount { get; set; }

		public string Url { get; set; }

		public string SocialApps { get; set; }

		public SpeakerDetailViewModel ()
		{
			
		}

		public override void NavigateTo ()
		{
			Url = "Github";

			ProfilePicture = "luis";

			SpeakerName = "Luis Ramirez";

			Bio = "Luis Ramirez tiene mas de 8 años de experiencia escribiendo software tanto el mercado local como internacional en la plataforma .NET y es una de las personas responsables de que comunidades como c#.do y Mobile.Do existan. Ademas de que es un apasionado a las buenas practicas y del buen software.";

			CharlasCount = "1 Sessions";

			SocialApps = "Social Apps";

			Sessions = new ObservableCollection<Session>
			{
				new Session
				{
					Charla = "AUTOMATING PORTABILITY ANALYSIS AND PERFORMANCE OPTIMIZATION OF NATIVE CODE",
					Charlista = "Luis Ramirez",
					HoraInicio = string.Format("{0}:{1}", "11","30"),
					Lugar = "Sala 01"
				}
			};
		}
	}
}

