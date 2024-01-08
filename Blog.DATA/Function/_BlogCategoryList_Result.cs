using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Function
{
	public class _BlogCategoryList_Result
	{
		[Key]
		public int BlogCategoryID { get; set; }
		public string? BlogCategoryName { get; set; }
		public Nullable<bool> Status { get; set; }
		public DateTime RegisterDate { get; set; }
		public string? BlogCategorySubName { get; set; }
		public string? TranslateControl { get; set; }
	}
}
