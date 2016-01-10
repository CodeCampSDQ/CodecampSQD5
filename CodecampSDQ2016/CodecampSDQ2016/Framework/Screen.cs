using System;
using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class Screen<T> : ContentPage where T: ViewModelBase, new()
	{
		public T DataContext { get; set; }

		public Screen ()
		{
			SetUpBindingContext();

			Content = CreatePageContent();
		}

		void SetUpBindingContext ()
		{
			DataContext = new T();

			BindingContext = DataContext;

			DataContext.NavigateTo();
		}

		public virtual View CreatePageContent ()
		{
			return new StackLayout();
		}
	}
}

