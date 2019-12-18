using System.Collections.Generic;

namespace UXDivers.Artina.Grial
{
	public class DashboardViewModel
	{
		public List<SampleCategory> Items { 
			get 
			{ 
				return SamplesDefinition.SamplesCategoryList;
			} 
		}
	}
}