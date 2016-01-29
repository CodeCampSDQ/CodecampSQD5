using System;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class TweetItScreen : Screen<TweetItViewModel>
	{
		public TweetItScreen ()
		{
			DataContext.TwitterAppNotFound += OnTwitterNotFound;
		}

		async void OnTwitterNotFound (object sender, EventArgs e)
		{
			await DisplayAlert("Error","Se requiere la aplicacion de twitter para esta funcionalidad","Ok");
		}

		public override View CreatePageContent ()
		{
			this.BackgroundColor = Color.White;

			var whatToDo = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Start,
				TextColor = Color.Gray,
				FontSize = 14
			};

			whatToDo.SetBinding<TweetItViewModel>(Label.TextProperty, m => m.WhatToDoDescription);

			var speakerTitle = new Label
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Gray,
				FontSize = 12
			};

			speakerTitle.SetBinding<TweetItViewModel>(Label.TextProperty, m => m.SpeakerTitle);

			var speakerDropDown = new Label
			{
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Black,
				FontSize = 12
			};

			speakerDropDown.SetBinding<TweetItViewModel>(Label.TextProperty, m => m.SpeakerDropDownSelected);

			var speakerContainer = new StackLayout
			{
				BackgroundColor = Color.FromHex("f1eef3"),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(16),
				Children = 
				{
					speakerTitle,
					speakerDropDown
				}
			};

			speakerContainer.GestureRecognizers.Add(
				new TapGestureRecognizer
				{
					Command = new Command(()=>{
						OnSpeakerContainerSelected();
					})
				}
			);

			var phraseTitle = new Label
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Gray,
				FontSize = 12
			};

			phraseTitle.SetBinding<TweetItViewModel>(Label.TextProperty, m => m.PhraseTitle);

			var phrasedropDown = new Label
			{
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Black,
				FontSize = 12
			};

			phrasedropDown.SetBinding<TweetItViewModel>(Label.TextProperty, m => m.PhraseDropDownSelected);

			var phraseContainer = new StackLayout
			{
				BackgroundColor = Color.FromHex("f1eef3"),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(16),
				Children = 
				{
					phraseTitle,
					phrasedropDown
				}
			};

			phraseContainer.GestureRecognizers.Add(
				new TapGestureRecognizer
				{
					Command = new Command(OnPhraseContainerSelected)
				}
			);

			var tweetButton = new Button
			{
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.EndAndExpand,
				BorderRadius = 0
			};

			tweetButton.SetBinding<TweetItViewModel>(Button.TextProperty, m => m.TweetItButtonText);
			tweetButton.SetBinding<TweetItViewModel>(Button.BackgroundColorProperty, m => m.TweetButtonColor);
			tweetButton.SetBinding<TweetItViewModel>(Button.CommandProperty, m => m.TweetItCommand);
			tweetButton.SetBinding<TweetItViewModel>(Button.IsEnabledProperty,m => m.IsThereNetworkAvailable);

			var screenLayout = new StackLayout
			{
				Spacing = 8,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{
					new StackLayout
					{
						Padding = new Thickness(14),
						Children = 
						{
							whatToDo
						}
					},
					new StackLayout
					{
						Spacing = 12,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Children =
						{
							speakerContainer,
							phraseContainer
						}
					},
					new StackLayout
					{
						Children = 
						{
							tweetButton
						}
					}
				}
			};

			return screenLayout;
		}

		async void OnPhraseContainerSelected ()
		{
			var selected = await DisplayActionSheet("Charlistas", "Cancel", null, DataContext.PhraseList);

			if(selected != "Cancel")
			DataContext.PhraseDropDownSelected = selected;
		}

		async void OnSpeakerContainerSelected ()
		{
			var selected = await DisplayActionSheet("Charlistas", "Cancel", null, DataContext.SpeakersList);

			if(selected != "Cancel")
				DataContext.SpeakerDropDownSelected = selected;

			DataContext.UpdatePhrases();
		}
	}
}

