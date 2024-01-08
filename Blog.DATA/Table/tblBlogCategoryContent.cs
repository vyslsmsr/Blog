using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Table
{
	public partial class tblBlogCategoryContent
	{
		[Key]
		public int BlogCategoryContentID { get; set; }
		public Nullable<int> BlogCategoryID { get; set; }
		public Nullable<int> LangID { get; set; }
		public string? BlogCategorySubName { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Url { get; set; }
	}
}
