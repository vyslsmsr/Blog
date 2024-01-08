using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Table
{
	public partial class tblSocialMedia
	{
		[Key]
		public int SocialMediaID { get; set; }
		public string? SocialMediaName { get; set; }
		public string? SocialMediaCode { get; set; }
		public string? FlagUrl { get; set; }
		public Nullable<System.DateTime> RegisterDate { get; set; }
		public Nullable<bool> Status { get; set; }
		public Nullable<bool> Deleted { get; set; }
	}
}
