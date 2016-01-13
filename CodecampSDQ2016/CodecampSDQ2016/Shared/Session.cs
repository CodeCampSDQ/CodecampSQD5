using System;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class Session
	{
	    public int Id { get; set; }
        
		public string Name { get; set; }

		public string Description { get; set; }
        
		public string Location { get; set; }
        
		public TimeSpan StartTime { get; set; }
        
		public TimeSpan EndTime { get; set; }

		public string Time { get; set; }

        public int SpeakerId { get; set; }
	}
}

