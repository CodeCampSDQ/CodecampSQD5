using System;
using PropertyChanged;
using System.ComponentModel;
using CodecampSDQ2016.Services.Data;
using System.Threading.Tasks;

namespace CodecampSDQ2016
{
	[ImplementPropertyChanged]
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		protected readonly CodeCampSdqApi ApiService;

		public event PropertyChangedEventHandler PropertyChanged;

		public ViewModelBase ()
		{
			ApiService = new CodeCampSdqApi();
		}

		protected virtual void OnPropertyChanged (PropertyChangedEventArgs e)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler (this, e);
		}

		public virtual void NavigateTo()
		{
		}
	}

}

