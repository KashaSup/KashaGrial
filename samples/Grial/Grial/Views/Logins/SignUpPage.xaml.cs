using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class SignUpPage : ContentPage
	{
		private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

		public SignUpPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			tapGestureRecognizer.Tapped += OnLoginStackTapped;
			loginStack.GestureRecognizers.Add(tapGestureRecognizer);
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			tapGestureRecognizer.Tapped -= OnLoginStackTapped;
			loginStack.GestureRecognizers.Remove(tapGestureRecognizer);
		}

		public async void OnLoginStackTapped(object sender, EventArgs e)
		{
			if (LoginPage.IsPageInNavigationStack<LoginPage> (Navigation)) {
				await Navigation.PopAsync ();
				return;
			}
				
			var loginPage = new LoginPage();
			await Navigation.PushAsync(loginPage);
		}
		
		async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
		}
	}
}