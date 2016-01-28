using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using Plugin.Connectivity;
using System.Collections.Generic;

namespace CodecampSDQ2016
{
	public class SpeakerViewModel : ViewModelBase
	{
		public ObservableCollection<Speaker> Speakers { get; set; }

		public string HeaderTitle { get; set; }

		public string Header { get; set; }

		public bool PullToRefreshEnabled { get; set; }

		public string HeaderDescription { get; set; }

		public bool IsLoading { get; set; } = true;

		public ICommand PullToRefreshCommand { get; set; }

		public SpeakerViewModel ()
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

			await LoadData(null);
		}

		async Task LoadData (IEnumerable<Speaker> speakers)
		{
			IsLoading = true;

			IEnumerable<Speaker> speakerList = new List<Speaker>();

			if(speakers == null && CrossConnectivity.Current.IsConnected)
			{
				await ApiService.FetchData();

				speakerList = await ApiService.GetSpeakers();
			}else
			{
				speakerList = speakers;
			}

			IsLoading = true;

			if(speakerList != null)
			{
				Speakers = new ObservableCollection<Speaker>(speakerList.OrderBy(x => x.Name));
			}

			IsLoading = false;
		}

		public override async void OnConnectionAvailable ()
		{
			await LoadData(null);
		}

		public override async void OnReconnect ()
		{
			await LoadData(null);
		}

		public override async void NavigateTo ()
		{
			PullToRefreshEnabled = true;

			HeaderTitle = "Speakers";

			Header = "sd";

			HeaderDescription = "Meet the experts";

			await LoadData(await ApiService.GetSpeakersFromCache());
		}
	}
}

