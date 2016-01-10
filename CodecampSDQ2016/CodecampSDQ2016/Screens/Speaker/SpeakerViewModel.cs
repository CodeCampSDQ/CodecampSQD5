using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class SpeakerViewModel : ViewModelBase
	{
		public ObservableCollection<Session> Sessions { get; set; }

		public SpeakerViewModel ()
		{
			
		}

		public override void NavigateTo ()
		{
			Sessions = new ObservableCollection<Session>
			{
				new Session
				{
					Charlista = "Pinedax",
					Hora = DateTime.Today.AddMinutes(240),
					Lugar = "Sala 10",
					BackgroundImage = "pineda"
				},
				new Session
				{
					Charlista = "Luis Ramirez",
					Hora = DateTime.Today.AddMinutes(120),
					Lugar = "Sala 03",
					BackgroundImage = "luis"
				},
				new Session
				{
					Charlista = "Claudio Sanchez",
					Hora = DateTime.Today.AddMinutes(40),
					Lugar = "Sala 01",
					BackgroundImage = "claudio"
				},
				new Session
				{
					Charlista = "Jose Gregorio",
					Hora = DateTime.Today.AddMinutes(60),
					Lugar = "Sala 06",
					BackgroundImage = "gregorex"
				}
			};
		}
	}
}

