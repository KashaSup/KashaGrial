using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;

namespace UXDivers.Artina.Grial
{
	public partial class MessagesListPage : ContentPage
	{
		public MessagesListPage ()
		{
			InitializeComponent ();
			listViewMessages.ItemsSource = SampleData.Messages;
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
			var list = (sender as ListView);
			var selectedItem = list.SelectedItem;
			var userName = (selectedItem as Message).From.Name;
			DisplayAlert("Message Tapped", "You tapped on " + userName + "'s message.", "OK");
			this.Navigation.PopModalAsync();
		}

		public void OnRefreshing (object sender, EventArgs e) {
			var listView = (sender as ListView);
			listView.EndRefresh();
		}

		public void animateIn( View uiElement ){
			animateItem (uiElement, 10500);
		}

		private void animateItem( View uiElement, uint duration ){
			uiElement.RotateYTo(99, duration, Easing.SinInOut);
		}
	}
}

