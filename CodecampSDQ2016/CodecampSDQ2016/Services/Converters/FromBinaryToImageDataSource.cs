using System;
using Xamarin.Forms;
using Marioneta;
using System.IO;

namespace CodecampSDQ2016
{
	public class FromBinaryToImageDataSource : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var asBinary = value as byte[];

			if(asBinary != null)
				return ImageSource.FromStream(()=>new MemoryStream(asBinary));

			return value;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

	}

}

