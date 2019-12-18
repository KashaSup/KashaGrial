using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class CategoriesListWithIconsPage : ContentPage
	{
		public CategoriesListWithIconsPage ()
		{
			InitializeComponent ();

			BindingContext = new SamplesViewModel(Navigation);
		}

		private async void OnItemTapped(Object sender, ItemTappedEventArgs e)
		{
			var selectedItem = ((ListView) sender).SelectedItem;
			var sampleCategory = (SampleCategory) selectedItem;

			await SamplesListFromCategoryPage.NavigateToCategory (sampleCategory, Navigation);
		}
	}
}

