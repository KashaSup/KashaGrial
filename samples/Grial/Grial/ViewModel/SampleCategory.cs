using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public class SampleCategory
	{
		public string Name { get; set; }

		public Color BackgroundColor { get; set; }

		public String BackgroundImage { get; set; }

		public List<Sample> SamplesList { get; set; }

		public char Icon { get; set; }
	}
}