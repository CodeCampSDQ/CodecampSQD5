using System;

using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodecampSDQ2016
{
	public class SessionDetailViewModel : ViewModelBase
	{
		public Session Session { get; set; }

		public ObservableCollection<Session> Sessions { get; set; }

		public string SpeakerName { get; set; }

		public string TimeTitle { get; set; }

		public string LocationTitle { get; set; }

		public string DescriptionTitle { get; set; }

		public string SessionName { get; set; }

		public string Description { get; set; }

		public string Time { get; set; }

		public string Location { get; set; }

		public byte[] ProfilePicture { get; set; }

		public bool HasBio { get; set; }

		public SessionDetailViewModel ()
		{
			
		}

		public async void Init (Session session)
		{
			Session = session;

			await ParseSpeaker(session);
		}

		async Task ParseSpeaker (Session session)
		{
			SessionName = session.Name;

			Description = session.Description;

			var startTime = DateTime.Today.Add(session.StartTime);

			var endTime = DateTime.Today.Add(session.EndTime);

			Time = string.Format("{0} - {1}", startTime.ToString(("hh:mm tt")), endTime.ToString(("hh:mm tt")));

			TimeTitle = "Tiempo";

			DescriptionTitle = "Descripcion";

			LocationTitle = "Lugar";

			Location = session.Location;

			var sessions = new List<Session>(await ApiService.GetAllSpeakerSessions(session.Id));

			var speaker = await ApiService.GetSpeakers();

			SpeakerName = speaker.FirstOrDefault(p => p.Id == session.SpeakerId).Name;

			Sessions = new ObservableCollection<Session>(sessions);
		}

		public override void NavigateTo ()
		{
			
		}
	}
}

