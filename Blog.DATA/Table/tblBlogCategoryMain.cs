using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Table
{
	public partial class tblBlogCategoryMain
	{
		[Key]
		public int BlogCategoryID { get; set; }
		public string? BlogCategoryName { get; set; }
		public Nullable<System.DateTime> RegisterDate { get; set; }
		public Nullable<bool> Status { get; set; }
		public Nullable<bool> Deleted { get; set; }
	}
}
