using System;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class TimeSpanToString : IValueConverter
	{
		
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var timespan = (TimeSpan) value;

			DateTime time = DateTime.Today.Add(timespan);

			string output = time.ToString(("hh:mm tt"));

			return output;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

