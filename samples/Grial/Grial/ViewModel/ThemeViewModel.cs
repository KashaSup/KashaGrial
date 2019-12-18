using System;
namespace UXDivers.Artina.Grial
{
	public class ThemeViewModel
	{
		private readonly static DateTime MinDate = DateTime.Parse("Jan 1 2000");
		private readonly static DateTime MaxDate = DateTime.Parse("Dec 31 2050");

		public DateTime Now => DateTime.Now;

		public DateTime MinimumDate => MinDate;

		public DateTime MaximumDate => MaxDate;
	}
}
