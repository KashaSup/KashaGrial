using System.Collections.Generic;

namespace UXDivers.Artina.Grial
{
	public class PostsViewModel
	{
		public List<Post> PostsList 
		{ 
			get 
			{
				return SampleData.Posts;
			}
		}
	}
}

