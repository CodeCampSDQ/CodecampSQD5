using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class SessionViewModel : ViewModelBase
	{
		public ObservableCollection<Session> Sessions { get; set; }

		public bool PullToRefreshEnabled { get; set; }

		public string Header { get; set; }

		public string HeaderTitle { get; set; }

		public string HeaderDescription { get; set; }

		public SessionViewModel ()
		{
			
		}

		public override void NavigateTo ()
		{
			PullToRefreshEnabled = true;

			Header = "sd";

			HeaderTitle = "SESSIONS";

			HeaderDescription = "Conference sessions led by industry experts.";

			Sessions = new ObservableCollection<Session>
			{
				new Session
				{
					Charla = "SKILLS EVERY STARTUP TEAM NEEDS",
					Charlista = "Pinedax",
					HoraInicio = string.Format("{0}:{1}", "09","30"),
					Lugar = "Sala 10"
				},
				new Session
				{
					Charla = "SAMBA 4.0 COMO ACTIVE DIRECTORY",
					Charlista = "Luis Ramirez",
					HoraInicio = string.Format("{0}:{1}", "08","30"),
					Lugar = "Sala 03"
				},
				new Session
				{
					Charla = "REFACTORING: KEEPING YOUR CODE HEALTHY",
					Charlista = "Claudio Sanchez",
					HoraInicio = string.Format("{0}:{1}", "11","30"),
					Lugar = "Sala 01"
				},
				new Session
				{
					Charla = "DESARROLLO RÁPIDO EN RAILS",
					Charlista = "Jose Gregorio",
					HoraInicio = string.Format("{0}:{1}", "12","30"),
					Lugar = "Sala 06"
				}
			};
		}
	}
}

