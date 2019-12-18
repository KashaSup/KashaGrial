using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class DashboardWithImagesPage : ContentPage
	{
		public DashboardWithImagesPage ()
		{
			InitializeComponent();

			BindingContext = new DashboardViewModel ();
		}
	}
}