using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Table
{
	public partial class tblException
	{
		[Key]
		public int ID { get; set; }
		public string? Description { get; set; }
		public string? Controller { get; set; }
		public string? Action { get; set; }
		public Nullable<System.DateTime> RegisterDate { get; set; }
		public string? UserID { get; set; }
		public string? Username { get; set; }
		public string? IpNm { get; set; }
		public Nullable<int> GroupID { get; set; }
	}
}
