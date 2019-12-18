using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class OpenPost : ContentPage
	{
		private bool hasNavigationBar = false;

		public OpenPost ()
		{
			InitializeComponent ();

			//NavigationPage.SetHasNavigationBar(this, false);

			var postsViewModel = new PostsViewModel ();
			BindingContext = postsViewModel.PostsList [0];

			outerScrollView.Scrolled += (object sender, ScrolledEventArgs e) => {
				var imageHeight = img.Height * 2;
				var scrollRegion = layeringGrid.Height - outerScrollView.Height;
				var parallexRegion = imageHeight - outerScrollView.Height;
				var factor = outerScrollView.ScrollY - parallexRegion * (outerScrollView.ScrollY / scrollRegion);
				img.TranslationY = factor;
				img.Opacity = 1 - ( factor / imageHeight ) ;
				headers.Scale = 1 - ( (factor ) / (imageHeight * 2) ) ;
			};
		}

		public void OnMore (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}

		public void OnItemTapped (object sender, EventArgs e) {
			var userName = (((ListView)sender).SelectedItem as Message).From.Name;
			DisplayAlert("Message Tapped", "You tapped on " + userName + "'s message.", "OK");

			this.Navigation.PopModalAsync ();
		}

		public void OnPrimaryActionButtonClicked (object sender, EventArgs e){
			hasNavigationBar = !hasNavigationBar;

			NavigationPage.SetHasNavigationBar(this, hasNavigationBar);
		}
	}
}

