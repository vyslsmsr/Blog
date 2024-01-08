using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Table
{
	public class tblUserLoginType
	{
		[Key]
		public int ElementID { get; set; }
		public string? UserID { get; set; }
		public Nullable<int> LoginType { get; set; }
	}
}
