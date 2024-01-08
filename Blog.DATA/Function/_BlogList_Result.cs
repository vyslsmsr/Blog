using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Function
{
    public class _BlogList_Result
    {
        [Key]
        public int BlogID { get; set; }
        public string? BlogName { get; set; }
        public Nullable<bool> Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? BlogSubName { get; set; }
        public string? BlogCategorySubName { get; set; }
    }
}
