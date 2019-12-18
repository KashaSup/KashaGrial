using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}

		public void OnItemTapped (object sender, EventArgs e) {

			DisplayAlert("Item Tapped", "YEAH", "OK");
		}
	}
}

