using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class CustomNavBar : ContentView
	{
		public CustomNavBar ()
		{
			InitializeComponent ();
		}

		public void OnHamburgerIconTapped(Object sender, EventArgs e)
		{
			Element current = this;

			while (current.Parent != null ) {
				current = current.Parent;
				if (current.GetType().Name == "RootPage") {
					break;
				}
			}

			var master = current as MasterDetailPage;

			if (master != null) {
				master.IsPresented = true;
			}
		}

		public async void OnCogIconTapped(Object sender, EventArgs e)
		{
			await Navigation.PushAsync( new SettingsPage() );
		}
	}
}

