using System;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class SocialGalleryImagePreviewPage : ContentPage
	{
		private const uint animationDuration = 100;

		private TapGestureRecognizer doubleTapGestureRecognizer = null;

		public SocialGalleryImagePreviewPage ( ImageSource source )
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar( this, false );
			img.Source = source;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (doubleTapGestureRecognizer == null) {
				doubleTapGestureRecognizer = new TapGestureRecognizer ();
				doubleTapGestureRecognizer.NumberOfTapsRequired = 2;
			}

			doubleTapGestureRecognizer.Tapped += OnImagePreviewDoubleTapped;
			img.GestureRecognizers.Add( doubleTapGestureRecognizer );
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			doubleTapGestureRecognizer.Tapped -= OnImagePreviewDoubleTapped;
			img.GestureRecognizers.Remove( doubleTapGestureRecognizer );
		}

		private async void OnImagePreviewDoubleTapped(object sender, EventArgs args)
		{
			if ((int)img.Scale == 1) {
				await img.ScaleTo(2, animationDuration, Easing.SinInOut);
			} else {
				await img.ScaleTo(1, animationDuration, Easing.SinInOut);
			}
		}

		async void OnCloseButtonClicked( object sender, EventArgs args )
		{
			await Navigation.PopModalAsync();
		}
	}
}
