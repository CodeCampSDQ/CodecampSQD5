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
				FontSize = 18
			};

			charlista.SetBinding<Session>(Label.TextProperty, m => m.Charlista);

			var sessionName = new Label
			{
				TextColor = Color.Black,
				FontSize = 18
			};

			sessionName.SetBinding<Session>(Label.TextProperty, m => m.Charla);

			var lugar = new Label
			{
				TextColor = Color.Gray
			};

			lugar.SetBinding<Session>(Label.TextProperty, m => m.Lugar);

			var hora = new Label
			{
				TextColor = Color.Black,
				FontSize = 12
			};

			hora.SetBinding<Session>(Label.TextProperty, m => m.Hora);

			builder
				.AddView(charlista)
				.WithPadding(new Thickness(16,16,0,4));
			
			builder
				.AddView(sessionName)
				.BelowOf(charlista)
				.WithPadding(new Thickness(16,8,0,0));

			builder
				.AddView(lugar)
				.BelowOf(sessionName)
				.AlignLeft(sessionName)
				.WithPadding(new Thickness(0,10,0,0));
			
			builder
				.AddView(hora)
				.AlignTop(lugar)
				.AlignParentRight()
				.WithPadding(new Thickness(0,4,4,0));

			return builder
				.ApplyConfiguration((p,v)=>{
					p.Padding = new Thickness(10);
			}).BuildLayout();
		}
	}
}

