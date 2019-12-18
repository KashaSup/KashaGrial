using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class Settings : ContentPage
	{
		public Settings ()
		{
			InitializeComponent ();


		}

		public void OnItemTapped (object sender, EventArgs e) {

			DisplayAlert("Item Tapped", "YEAH", "OK");
		}
	}
}

