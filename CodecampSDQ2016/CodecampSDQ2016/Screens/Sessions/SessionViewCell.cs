using System;
using Xamarin.Forms;
using Marioneta;

namespace CodecampSDQ2016
{
	public class SessionViewCell : ViewCell
	{
		public SessionViewCell ()
		{
			View = CreateView();
		}

		View CreateView ()
		{
			var builder = new RelativeBuilder();

			var charlista = new Label
			{
				FontAttributes = FontAttributes.Bold,
				FontSize = 18,
				TextColor = Color.Black
			};

			charlista.SetBinding<Session>(Label.TextProperty, m => m.SpeakerName);

			var sessionName = new Label
			{
				TextColor = Color.Gray,
				FontSize = 12
			};

			var sessionNameContainer = new StackLayout
			{
				Padding = new Thickness(0,0,20,0),
				Children = 
				{
					sessionName
				}
			};

			sessionName.SetBinding<Session>(Label.TextProperty, m => m.Name);

			var lugar = new Label
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 12
			};

			lugar.SetBinding<Session>(Label.TextProperty, m => m.Location);

			var hora = new Label
			{
				TextColor = Color.FromHex("3498db"),
				FontSize = 12
			};

			hora.SetBinding<Session>(Label.TextProperty, m => m.StartTime, BindingMode.Default, new TimeSpanToString());

			builder
				.AddView(charlista)
				.WithPadding(new Thickness(16,12,0,4));
			
			builder
				.AddView(sessionNameContainer)
				.BelowOf(charlista)
				.ExpandViewToParentWidth()
				.AlignLeft(charlista)
				.WithPadding(new Thickness(0,8,0,0));

			builder
				.AddView(lugar)
				.BelowOf(sessionNameContainer)
				.AlignLeft(sessionNameContainer)
				.WithPadding(new Thickness(0,10,0,0));
			
			builder
				.AddView(new StackLayout
					{
						Padding = new Thickness(0,0,12,0),
						Children = 
						{
							hora
						}
					})
				.AlignTop(lugar)
				.AlignParentRight()
				.WithPadding(new Thickness(0,4,16,0));

			return builder
				.ApplyConfiguration((p,v)=>{
					p.Padding = new Thickness(10);
			}).BuildLayout();
		}
	}
}

