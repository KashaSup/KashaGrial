using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class ThemePage : ContentPage
	{
		public ThemePage ()
		{
			InitializeComponent ();

			BindingContext = new ThemeViewModel();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			themeNamesSearchBar.TextChanged += OnTextChanged;
			themeNamesSearchBar.SearchButtonPressed += OnSearchButtonPressed;
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			themeNamesSearchBar.TextChanged -= OnTextChanged;
			themeNamesSearchBar.SearchButtonPressed -= OnSearchButtonPressed;
		}

		private void OnTextChanged(object sender, EventArgs e){
			FilterNames (themeNamesSearchBar.Text);
		}

		private void OnSearchButtonPressed(object sender, EventArgs e){
			FilterNames (themeNamesSearchBar.Text);
		}

		public void FilterNames (string filter)
		{
			themeNamesSampleListView.BeginRefresh ();

			if (string.IsNullOrWhiteSpace (filter)) {
				themeNamesSampleListView.ItemsSource = SampleData.Names;
			} else {
				themeNamesSampleListView.ItemsSource = SampleData.Names
					.Where (x => x.ToLower ()
						.Contains (filter.ToLower ()));
			}

			themeNamesSampleListView.EndRefresh ();
		}

	}
}

