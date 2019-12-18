using System;
using System.Threading.Tasks;
using Xamarin.Forms;

using UXDivers.Artina.Shared;

namespace UXDivers.Artina.Grial
{
	public partial class ProfilePage : ContentPage
	{
		private bool _animate;

		public ProfilePage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			// Workaround to fix image placement issue in iOS. It occurrs only when this 
			// page (within a NavigationPage) is set as the detail of the MasterDetailPage 
			// i.e. Display it from the RootPage
			// navigation view
			var content = this.Content;
			this.Content = null;
			this.Content = content;

			_animate = true;

			AnimateIn().Forget();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();

			_animate = false;
		}

		public async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}

		public async Task AnimateIn(){
			await AnimateItem (img, 10500);
		}

		private async Task AnimateItem(View uiElement, uint duration ){
			while (_animate) {
				await uiElement.ScaleTo(1.05, duration, Easing.SinInOut);

				await Task.WhenAll (
					uiElement.FadeTo(1, duration, Easing.SinInOut),
					uiElement.LayoutTo (new Rectangle( new Point(0,0), new Size( uiElement.Width, uiElement.Height))),
					uiElement.FadeTo(.9, duration, Easing.SinInOut),
					uiElement.ScaleTo(1.15, duration, Easing.SinInOut)
				);
			}
		}
	}
}