using System;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class DashboardFlatPage : ContentPage
	{
		public DashboardFlatPage()
		{			
			InitializeComponent();

			BindingContext = new DashboardViewModel ();
		}			
	}
}