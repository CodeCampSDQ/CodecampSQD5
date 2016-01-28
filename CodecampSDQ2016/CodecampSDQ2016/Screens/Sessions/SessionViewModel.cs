using System;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using CodecampSDQ2016.Services.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using Plugin.Connectivity;

namespace CodecampSDQ2016
{
	public class SessionViewModel : ViewModelBase
	{
		public ObservableCollection<Session> Sessions { get; set; }

		public ICommand PullToRefreshCommand { get; set; }

		public bool PullToRefreshEnabled { get; set; }

		public string Header { get; set; }

		public string HeaderTitle { get; set; }

		public string HeaderDescription { get; set; }

		public bool IsLoading { get; set; } = true;

		public SessionViewModel ()
		{
			PullToRefreshCommand = new Command(OnPullToFreshCommand);
		}

		async void OnPullToFreshCommand ()
		{
			if(!CrossConnectivity.Current.IsConnected)
			{
				IsLoading = false;

				return;
			}
	
			await ApiService.FetchData();

			await LoadDataFromAPi(null);
		}

		public override async void NavigateTo ()
		{
			PullToRefreshEnabled = true;

			Header = "sd";

			HeaderTitle = "SESSIONS";

			HeaderDescription = "Conference sessions led by industry experts.";

			await LoadDataFromCache();
		}

		async Task LoadDataFromCache ()
		{
			var session = await ApiService.GetSessionsFromCache();

			await LoadDataFromAPi(session);
		}

		public override async void OnConnectionAvailable ()
		{
			await LoadDataFromAPi(null);
		}

		public override async void OnReconnect ()
		{
			await LoadDataFromAPi(null);
		}

		async Task LoadDataFromAPi (IEnumerable<Session> sessions)
		{
			IsLoading = true;

			IEnumerable<Session> session = new List<Session>();

			if(sessions == null && CrossConnectivity.Current.IsConnected)
			{
				 await ApiService.FetchData();

				 session = await ApiService.GetSessions();
			}
			else
				session = sessions;

			if(session != null)
			{
				var sorted = session.OrderBy(x => x.StartTime).Select((sess)=>{

					var startTime = DateTime.Today.Add(sess.StartTime);

					var endTime = DateTime.Today.Add(sess.EndTime);

					sess.Time = string.Format("{0} - {1}", startTime.ToString(("hh:mm tt")), endTime.ToString(("hh:mm tt")));

					return sess;

				});

				Sessions = new ObservableCollection<Session>(sorted);

				IsLoading = false;
			}
		}
	}
}

