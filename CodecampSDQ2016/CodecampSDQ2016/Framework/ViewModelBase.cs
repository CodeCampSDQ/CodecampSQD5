using System;
using PropertyChanged;
using System.ComponentModel;
using CodecampSDQ2016.Services.Data;
using System.Threading.Tasks;
using Plugin.Connectivity;

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

			if(CrossConnectivity.Current.IsConnected)
			{
				OnConnectionAvailable();
			}

			CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
		}

		void OnConnectivityChanged (object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
		{
			if(e.IsConnected)
				OnReconnect();
			else
				OnConnectionLost();
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

		public virtual void OnConnectionAvailable()
		{
			
		}

		public virtual void OnConnectionNotAvailable()
		{
			
		}

		public virtual void OnConnectionLost()
		{
			
		}

		public virtual void OnReconnect()
		{
			
		}
	}

}

