using System;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	
	public class TweetItScreen : Screen<TweetItViewModel>
	{
		public override View CreatePageContent ()
		{

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
				TextColor = Color.Gray,
				FontSize = 14
			};

			speakerTitle.SetBinding<TweetItViewModel>(Label.TextProperty, m => m.SpeakerTitle);

			var speakerDropDown = new BoxView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Color = Color.Gray,
				HeightRequest = 12
			};

//			speakerDropDown.SetBinding<TweetItViewModel>(BoxView.Ba, m => m.SpeakerDropDownSelected);

			var speakerContainer = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(8),
				Children = 
				{
					speakerTitle,
					speakerDropDown
				}
			};
			
			var phraseTitle = new Label
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.Gray,
				FontSize = 14
			};

			phraseTitle.SetBinding<TweetItViewModel>(Label.TextProperty, m => m.PhraseTitle);

			var phrasedropDown = new BoxView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 12,
				Color = Color.Gray
			};

//			phrasedropDown.SetBinding<TweetItViewModel>(Label.TextProperty, m => m.PhraseDropDownSelected);

			var phraseContainer = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(8),
				Children = 
				{
					phraseTitle,
					phrasedropDown
				}
			};

			var tweetButton = new Button
			{
				WidthRequest = 200,
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.EndAndExpand
			};

			tweetButton.SetBinding<TweetItViewModel>(Button.TextProperty, m => m.TweetItButtonText);
			tweetButton.SetBinding<TweetItViewModel>(Button.BackgroundColorProperty, m => m.TweetButtonColor);

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
						Spacing = 20,
						BackgroundColor = Color.FromHex("f1eef3"),
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
						Padding = new Thickness(14),
						Children = 
						{
							tweetButton
						}
					}
				}
			};

			return screenLayout;
		}
	}
}

