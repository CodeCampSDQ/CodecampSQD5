using System;
using PropertyChanged;
using System.ComponentModel;

namespace CodecampSDQ2016
{
	[ImplementPropertyChanged]
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

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

