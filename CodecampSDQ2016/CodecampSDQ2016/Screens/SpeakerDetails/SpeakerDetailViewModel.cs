using System;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodecampSDQ2016
{
	public class SpeakerDetailViewModel : ViewModelBase
	{
		public Speaker Speaker { get; set; }

		public ObservableCollection<Session> Sessions { get; set; }

		public Command OnUrlTapCommand { get; set; }

		public string SpeakerName { get; set; }

		public string SessionTitle { get; set; }

		public string Bio { get; set; }

		public byte[] ProfilePicture { get; set; }

		public string CharlasCount { get; set; }

		public string GitHubUrlDesc { get; set; }

		public string SocialAppsDesc { get; set; }

		public bool HasBio { get; set; }

		public SpeakerDetailViewModel ()
		{
			OnUrlTapCommand = new Command(OnUrlTap);
		}

		void OnUrlTap ()
		{
			if(string.IsNullOrEmpty(Speaker.GitHubAccount))
				return;
			
			Device.OpenUri(new Uri(Speaker.GitHubAccount));
		}

		public async void Init (Speaker speaker)
		{
			Speaker = speaker;

			await ParseSpeaker(speaker);
		}

		async Task ParseSpeaker (Speaker speaker)
		{
			GitHubUrlDesc = "Github";

			ProfilePicture = speaker.BinaryPhoto;

			SpeakerName = speaker.Name;

			Bio = speaker.Bio;

			HasBio = !string.IsNullOrWhiteSpace(Bio);

			SocialAppsDesc = "See me on";

			SessionTitle = "Charlas";

			var sect = await ApiService.GetAllSpeakerSessions(speaker.Id);

			var filtered = sect.Select((sess)=>{

				var startTime = DateTime.Today.Add(sess.StartTime);

				var endTime = DateTime.Today.Add(sess.EndTime);

				sess.Time = string.Format("{0} - {1}", startTime.ToString(("hh:mm tt")), endTime.ToString(("hh:mm tt")));

				return sess;

			});

			var sessions = new List<Session>(filtered);

			CharlasCount = "Biografia";

			Sessions = new ObservableCollection<Session>(sessions);
		}

		public override void NavigateTo ()
		{
			
		}
	}
}

