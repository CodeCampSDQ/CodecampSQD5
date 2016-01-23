using System;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class TweetItViewModel : ViewModelBase
	{
		public string WhatToDoDescription { get; set; }

		public string SpeakerTitle { get; set; }

		public string SpeakerDropDownSelected { get; set; }

		public string PhraseTitle { get; set; }

		public string PhraseDropDownSelected { get; set; }

		public string TweetItButtonText { get; set; }

		public Color TweetButtonColor { get; set; }

		public override void NavigateTo ()
		{
			SpeakerTitle = "Charlista";

			WhatToDoDescription = "Postea tu tweet desde aqui, primero elige un charlista luego una frase ambos desde el dropdown y finalmente #daleparriba presionando el boton Tweet de abajo.";

			SpeakerDropDownSelected = "Pinedax";

			PhraseTitle = "Frase";

			PhraseDropDownSelected = "Doble sueldo me suena poco!";

			TweetItButtonText = "Tweet";

			TweetButtonColor = Color.FromHex("52B3D9");
		}
	}

}

