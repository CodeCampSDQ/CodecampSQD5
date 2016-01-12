using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using CodecampSDQ2016.Services.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;

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
			IsLoading = true;

			await ApiService.FetchData();

			await GetDataFromCache();
		}

		public async override void NavigateTo ()
		{
			PullToRefreshEnabled = true;

			Header = "sd";

			HeaderTitle = "SESSIONS";

			HeaderDescription = "Conference sessions led by industry experts.";

			await GetDataFromCache();
		}

		async Task GetDataFromCache ()
		{
			var session = await ApiService.GetSessions();

			Sessions = new ObservableCollection<Session>(session);

			IsLoading = (Sessions.Count < 0);
		}
	}
}

