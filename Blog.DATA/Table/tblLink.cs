using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Table
{
	public partial class tblLink
	{
		[Key]
		public int ID { get; set; }
		public string? Link { get; set; }
		public string? Controller { get; set; }
		public string? Action { get; set; }
		public Nullable<System.DateTime> RegisterDate { get; set; }
		public Nullable<bool> Status { get; set; }
		public Nullable<bool> Deleted { get; set; }
		public string? LangCode { get; set; }
		public Nullable<int> LangID { get; set; }
		public string? GroupID { get; set; }
	}
}
