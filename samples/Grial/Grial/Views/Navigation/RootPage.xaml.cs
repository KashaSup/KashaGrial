using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class RootPage : MasterDetailPage
	{
		private bool _showWelcome;

		public RootPage () : this(false){
		}

		public RootPage (bool sayWelcome)
		{
			InitializeComponent ();

			_showWelcome = sayWelcome;

			// Empty pages are initially set to get optimal launch experience
			Master = new ContentPage { Title = "Artina" };
			Detail = new NavigationPage(new ContentPage());
		}
			
		public async void OnSettingsTapped( Object sender, EventArgs e ){
			await Navigation.PushAsync( new SettingsPage() );
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			SampleCoordinator.SampleSelected += SampleCoordinator_SampleSelected;

			if (_showWelcome) {
				_showWelcome = false;

				await Navigation.PushModalAsync (new NavigationPage (new WelcomePage ()));

				await Task.Delay (500)
					.ContinueWith(t => NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail));
			}
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();

			SampleCoordinator.SampleSelected -= SampleCoordinator_SampleSelected;
		}

		private void InitializeMasterDetail(){
			Master = new MainMenuPage (new NavigationService(Navigation, LaunchSampleInDetail));
			Detail = new NavigationPage ( new DashboardPage ());
		}

		private void LaunchSampleInDetail(Page page, bool animated){
			// CustomNavBarPage must be handled differently because XF seems not to be considering the
			// "NavigationPage.SetHasNavigationBar(this, false);" when you add the page as the 
			// root of the NavigationPage, when you are working in Android.
			if (page is CustomNavBarPage) {
				var navigationPage = new NavigationPage (new ContentPage());

				Detail = navigationPage;

				navigationPage.PushAsync (page, false);
			} else {
				Detail = new NavigationPage (page);
			}

			IsPresented = false;
		}

		private void SampleCoordinator_SampleSelected (object sender, SampleEventArgs e)
		{
			if (e.Sample.PageType == typeof(RootPage)){
				IsPresented = true;
			}
		}
	}
}