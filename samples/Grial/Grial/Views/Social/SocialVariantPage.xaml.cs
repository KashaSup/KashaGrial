using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class SocialVariantPage : ContentPage
	{
		public SocialVariantPage ()
		{
			InitializeComponent ();

			BindingContext = new SocialViewModel ();
		}
	}
}