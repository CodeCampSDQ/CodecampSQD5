using System;

using Xamarin.Forms;

namespace CodecampSDQ2016
{
	public class HomeScreen : TabbedPage
	{
		public HomeScreen ()
		{
			SetBindings();
		}

		void SetBindings ()
		{
			this.SetBinding<HomeViewModel>(TabbedPage.ItemsSourceProperty, m => m.Tabs);
		}
	}
}

