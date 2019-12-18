using System;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class SocialPage : ContentPage
	{
		private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

		public SocialPage ()
		{
			InitializeComponent ();

			this.BindingContext = new SocialViewModel();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			tapGestureRecognizer.Tapped += OnProfileHeaderStackTapped;
			avatar.GestureRecognizers.Add(tapGestureRecognizer);
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			tapGestureRecognizer.Tapped -= OnProfileHeaderStackTapped;
			avatar.GestureRecognizers.Remove(tapGestureRecognizer);
		}

		public async void OnProfileHeaderStackTapped(object sender, EventArgs e)
		{
			var profilePage = new ProfilePage();
			await Navigation.PushAsync( profilePage );
		}
	}
}