using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Validation
{
	public class _Definition
	{

		public class _Blog
		{
			public class BlogModel
			{
				public int blogID { get; set; }
				public string? blogName { get; set; }
				public Nullable<int> blogCategoryID { get; set; }
				public string? blogSubName { get; set; }
				public string? shortText { get; set; }
				public string? blogContent { get; set; }
				public string? title { get; set; }
				public string? description { get; set; }
				public string? url { get; set; }
			}
		}


	}
}
