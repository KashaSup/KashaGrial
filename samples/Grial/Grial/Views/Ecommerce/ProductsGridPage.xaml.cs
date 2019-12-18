using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace UXDivers.Artina.Grial
{
	public partial class ProductsGridPage : ContentPage
	{
		private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

		public ProductsGridPage()
		{
			InitializeComponent ();

			PopulateProductsLists (SampleData.Products);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			tapGestureRecognizer.Tapped += OnBannerTapped;
			EcommerceProductGridBanner.GestureRecognizers.Add(tapGestureRecognizer);
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			tapGestureRecognizer.Tapped -= OnBannerTapped;
			EcommerceProductGridBanner.GestureRecognizers.Remove(tapGestureRecognizer);
		}

		private void PopulateProductsLists(List<Product> productsList){
			var lastHeight = "100";
			var y = 0;
			var column = LeftColumn;
			var productTapGestureRecognizer = new TapGestureRecognizer();
			productTapGestureRecognizer.Tapped += OnProductTapped;

			for (var i = 0; i < productsList.Count; i++) {
				var item = new ProductGridItemTemplate();

				if (i % 2 == 0) {
					column = LeftColumn;
					y++;
				} else {	

					column = RightColumn;
				}

				productsList[i].ThumbnailHeight = lastHeight;
				item.BindingContext = productsList[i];
				item.GestureRecognizers.Add( productTapGestureRecognizer );
				column.Children.Add( item );
			}
		}

		private async void OnProductTapped(Object sender, EventArgs e){
			var selectedItem = (Product)((ProductGridItemTemplate)sender).BindingContext;

			var productView = new ProductItemViewPage() {
				BindingContext = selectedItem
			};

			await Navigation.PushAsync(productView);
		}

		private async void OnBannerTapped(Object sender, EventArgs e){
			uint duration = 500;
			var visualElement = (VisualElement)sender;

			await Task.WhenAll (
				visualElement.FadeTo(0, duration/2, Easing.CubicIn),
				visualElement.ScaleTo (0, duration/2, Easing.CubicInOut)
			);

			visualElement.HeightRequest = 0;
		}
	}
}

