using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;

namespace UXDivers.Artina.Grial
{
	using System.Threading;

	using Android.App;
	using Android.OS;

	[Activity(
		Label = "Artina Grial",
		Theme = "@style/Theme.Splash", 
		Icon = "@drawable/icon", 
		MainLauncher = true, 
		NoHistory = true)
	]
	
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			StartActivity(typeof(MainActivity));
		}
	}
}