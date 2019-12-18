using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class DashboardPage : ContentPage
	{
		public DashboardPage ()
		{			
			InitializeComponent();

			BindingContext = new DashboardViewModel ();
		}
	}
}