using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrialRTLService.Helpers;
using GrialRTLService.Localization;
using System.Globalization;

namespace GrialRTLService
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

