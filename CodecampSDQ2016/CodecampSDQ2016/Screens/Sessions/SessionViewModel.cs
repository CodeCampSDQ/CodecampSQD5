using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class SessionViewModel : ViewModelBase
	{
		public ObservableCollection<Session> Sessions { get; set; }

		public string Header { get; set; }

		public string HeaderTitle { get; set; }

		public string HeaderDescription { get; set; }

		public SessionViewModel ()
		{
			
		}

		public override void NavigateTo ()
		{
			Header = "sd";

			HeaderTitle = "SESSIONS";

			HeaderDescription = "Conference sessions led by industry experts.";

			Sessions = new ObservableCollection<Session>
			{
				new Session
				{
					Charla = "Discutir primeros pasos para un Developer que quiere trabajar como freelancer",
					Charlista = "Pinedax",
					Hora = DateTime.Today.AddMinutes(240),
					Lugar = "Sala 10"
				},
				new Session
				{
					Charla = "Nuestro miedo a cambiar de trabajo y ambiente que nos estanca",
					Charlista = "Luis Ramirez",
					Hora = DateTime.Today.AddMinutes(120),
					Lugar = "Sala 03"
				},
				new Session
				{
					Charla = "Breve explicación del acrónimo S.O.L.I.D",
					Charlista = "Claudio Sanchez",
					Hora = DateTime.Today.AddMinutes(40),
					Lugar = "Sala 01"
				},
				new Session
				{
					Charla = "Esta charla resalta el importante rol que jugamos los developers en el desarrollo eCommerce",
					Charlista = "Jose Gregorio",
					Hora = DateTime.Today.AddMinutes(60),
					Lugar = "Sala 06"
				}
			};
		}
	}
}

