using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace CodecampSDQ2016
{
	public class Screen<T> : ContentPage where T: ViewModelBase, new()
	{
		public T DataContext { get; set; }

		public Screen ()
		{
			Content = CreatePageContent();

			SetUpBindingContext();
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

