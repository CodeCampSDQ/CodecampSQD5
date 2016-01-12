using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;

namespace CodecampSDQ2016
{
	public class SpeakerViewModel : ViewModelBase
	{
		public ObservableCollection<Speaker> Speakers { get; set; }

		public string HeaderTitle { get; set; }

		public string Header { get; set; }

		public bool PullToRefreshEnabled { get; set; }

		public string HeaderDescription { get; set; }

		public bool IsLoading { get; set; }

		public ICommand PullToRefreshCommand { get; set; }

		public SpeakerViewModel ()
		{
			PullToRefreshCommand = new Command(OnPullToFreshCommand);

		}

		async void OnPullToFreshCommand ()
		{
			IsLoading = true;

			await ApiService.FetchData();

			await GetDataFromCache();
		}

		async Task GetDataFromCache ()
		{
			var list = await ApiService.GetSpeakers();

			Speakers = new ObservableCollection<Speaker>(list);

			IsLoading = false;
		}

		public async override void NavigateTo ()
		{
			PullToRefreshEnabled = true;

			HeaderTitle = "Speakers";

			Header = "sd";

			HeaderDescription = "Meet the experts";

			await GetDataFromCache();
		}
	}
}

