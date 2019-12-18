using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class CategoriesListWithImagesPage : ContentPage
	{
		public CategoriesListWithImagesPage ()
		{
			InitializeComponent ();

			BindingContext = new SamplesViewModel(Navigation);
		}

		private async void OnItemTapped(Object sender, ItemTappedEventArgs e)
		{
			var selectedItem = ((ListView)sender).SelectedItem;
			var sampleCategory = (SampleCategory) selectedItem;

			await Navigation.PushAsync( GetPage( sampleCategory ) );
		}

		public static Page GetPage( SampleCategory sampleCategory )
		{
			return new SamplesListFromCategoryPage( sampleCategory );
		}
	}
}

