using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading;
using System.Collections.ObjectModel;

namespace CodecampSDQ2016
{
	public class TweetItViewModel : ViewModelBase
	{
		public string[] PhraseList { get; set; }

		public string[] SpeakersList { get; set; }

		public string WhatToDoDescription { get; set; }

		public string SpeakerTitle { get; set; }

		public string SpeakerDropDownSelected { get; set; }

		public string PhraseTitle { get; set; }

		public string PhraseDropDownSelected { get; set; }

		public string TweetItButtonText { get; set; }

		public bool IsThereNetworkAvailable { get; set; }

		public Color TweetButtonColor { get; set; }

		public ICommand TweetItCommand { get; set; }

		ITwitterService _twitter;

		public TweetItViewModel () : this(new TwitterService())
		{
			
		}

		public TweetItViewModel (ITwitterService twitter)
		{
			_twitter = twitter;

			TweetItCommand = new Command(OnTweetIt);
		}

		void OnTweetIt ()
		{
			if(string.IsNullOrEmpty(PhraseDropDownSelected))
				return;

			var token = new CancellationTokenSource();

			_twitter.TweetIt(PhraseDropDownSelected, token);
		}

		public override async void OnConnectionAvailable ()
		{ 
			IsThereNetworkAvailable = true;

			var speakers = new List<Speaker>(await ApiService.GetSpeakers()).OrderBy(x => x.Name);

			SpeakersList = speakers.Select<Speaker,string>((x)=>{

				return x.Name;
			}).ToArray();
		}

		public override void OnConnectionLost ()
		{
			IsThereNetworkAvailable = false;
		}

		public override void OnReconnect ()
		{
			IsThereNetworkAvailable = true;
		}

		public override void OnConnectionNotAvailable ()
		{
			IsThereNetworkAvailable = true;
		}

		public override void NavigateTo ()
		{
			SpeakerTitle = "Charlista";

			WhatToDoDescription = "Postea tu tweet desde aqui, primero elige un charlista luego una frase ambos desde el dropdown y finalmente #daleparriba presionando el boton Tweet de abajo.";

			SpeakerDropDownSelected = "Pinedax";

			PhraseTitle = "Frase";

			PhraseDropDownSelected = "Doble sueldo me suena poco!";

			TweetItButtonText = "Tweet";

			TweetButtonColor = Color.FromHex("3498db");

			SpeakersList = new string[]{string.Empty};

			PhraseList = new string[]
			{
				"Phrase 1.",
				"Phrase 2.",
				"Phrase 3.",
				"Phrase 4."
			};
		}
	}

}

