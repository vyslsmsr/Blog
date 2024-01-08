using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Table
{
	public partial class tblBlogContent
	{
		[Key]
		public int BlogContentID { get; set; }
		public Nullable<int> BlogID { get; set; }
		public string? BlogSubName { get; set; }
        public string? ShortText { get; set; }
        public string? BlogContent { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Url { get; set; }
	}
}
