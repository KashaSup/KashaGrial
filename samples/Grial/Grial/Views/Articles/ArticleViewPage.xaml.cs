using System;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class ArticleViewPage : ContentPage
	{
		public ArticleViewPage () : this(new ArticleViewModel())
		{
		}

		public ArticleViewPage (ArticleViewModel viewModel)
		{
			InitializeComponent ();
			BindingContext = viewModel;
		}

		protected override void OnAppearing (){
			base.OnAppearing ();

			outerScrollView.Scrolled += OnScroll;
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			outerScrollView.Scrolled -= OnScroll;
		}

		public void OnScroll (object sender, ScrolledEventArgs e) {
			var imageHeight = img.Height * 2;
			var scrollRegion = layeringGrid.Height - outerScrollView.Height;
			var parallexRegion = imageHeight - outerScrollView.Height;
			var factor = outerScrollView.ScrollY - parallexRegion * (outerScrollView.ScrollY / scrollRegion);
			img.TranslationY = factor;
			img.Opacity = 1 - ( factor / imageHeight ) ;
			headers.Scale = 1 - ( (factor ) / (imageHeight * 2) ) ;
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
			var message = (Message)((ListView)sender).SelectedItem;
			DisplayAlert("Message Tapped", "You tapped on " + message.From.Name + "'s message.", "OK");

			this.Navigation.PopModalAsync ();
		}

		public void OnPrimaryActionButtonClicked (object sender, EventArgs e){

		}
	}
}

