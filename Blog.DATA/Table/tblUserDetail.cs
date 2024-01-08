using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Table
{
	public partial class tblUserDetail
	{
		[Key]
		public int ElementID { get; set; }
		public string? UserID { get; set; }
		public string? NameSurname { get; set; }
		public string? Phone { get; set; }
		public Nullable<int> Gender { get; set; }
		public string? Password { get; set; }
		public string? Address { get; set; }
		public Nullable<int> Country { get; set; }
		public string? City { get; set; }
		public string? Region { get; set; }
		public Nullable<int> DoctorID { get; set; }
		public Nullable<int> DefaultLang { get; set; }
		public Nullable<bool> IsAdmin { get; set; }
	}
}
