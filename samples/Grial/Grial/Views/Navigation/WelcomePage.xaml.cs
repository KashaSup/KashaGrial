using System;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();

			NavigationPage.SetHasNavigationBar(this, false);
		}

		public async void OnWalkthroughButtonTapped (object sender, EventArgs e) {
			await Navigation.PushAsync (new WalkthroughPage ());
		}

		public async void OnBrowseSamplesButtonTapped (object sender, EventArgs e) {
			await Navigation.PopModalAsync ();
		}

		async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync ();
		}
	}
}