using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;
using CodecampSDQ2016.Services.Cache;

namespace CodecampSDQ2016
{
	public class Screen<T> : ContentPage where T: ViewModelBase, new()
	{
		public T DataContext { get; set; }

		bool _connected;

		public Screen ()
		{
			Init();

			SetUpBindingContext();

			CrossConnectivity.Current.ConnectivityChanged += OnConnectivityChanged;
		}

		void OnConnectivityChanged (object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
		{
			if(e.IsConnected && !_connected)
			{
				Content = CreatePageContent();
			}
		}

		void SetUpBindingContext ()
		{
			DataContext = new T();

			BindingContext = DataContext;

			DataContext.NavigateTo();
		}

		//Se que esto es un picapollo, pero luego refactorizo.
		async void Init ()
		{
			_connected = CrossConnectivity.Current.IsConnected;

			var isEmpty = await GlobalCache.CheckIfEmpty();

			if(_connected || !isEmpty)
			{
				Content = CreatePageContent();
			}
			else if(isEmpty && !_connected)
			{
				Content = CreateEmptyState();
			}
		}

		public virtual View CreatePageContent()
		{
			return new StackLayout();
		}

		public View CreateEmptyState ()
		{
			var wifiIcon = new Image
			{
				Aspect = Aspect.AspectFit,
				WidthRequest = 100,
				HeightRequest = 100,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Source = "wifi"
			};

//			wifiIcon.SetBinding<T>(Image.SourceProperty, m => m.Icon);

			var title = new Label
			{
				FontAttributes = FontAttributes.Bold,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Text = "No tienes una conexion a internet"
			};

//			title.SetBinding<T>(Label.TextProperty, m => m.Title);

			var subText = new Label
			{
				FontSize = 14,
				TextColor = Color.Gray,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Text = "No se encontro una conexion a internet."
			};

//			subText.SetBinding<T>(Label.TextProperty, m => m.SubText);

			return new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding = new Thickness(4),
				Spacing = 12,
				Children = 
				{
					wifiIcon,
					title,
					subText
				}
			};
		}
	}
}

