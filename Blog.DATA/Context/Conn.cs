using Blog.DATA.Function;
using Blog.DATA.Identity;
using Blog.DATA.Table;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Context
{
	public class Conn : IdentityDbContext<AppUser, AppRole, string>
	{
		public Conn(DbContextOptions<Conn> options) : base(options)
		{

		}

        public virtual DbSet<tblBlogCategoryContent> tblBlogCategoryContent { get; set; }
        public virtual DbSet<tblBlogCategoryMain> tblBlogCategoryMain { get; set; }
        public virtual DbSet<tblBlogContent> tblBlogContent { get; set; }
        public virtual DbSet<tblBlogMain> tblBlogMain { get; set; }
        public virtual DbSet<tblException> tblException { get; set; }
        public virtual DbSet<tblLink> tblLink { get; set; }
        public virtual DbSet<tblLog> tblLog { get; set; }
        public virtual DbSet<tblSocialMedia> tblSocialMedia { get; set; }
        public virtual DbSet<tblUserDetail> tblUserDetail { get; set; }
        public virtual DbSet<tblUserLoginType> tblUserLoginType { get; set; }



        public virtual DbSet<_BlogList_Result> _BlogList_V { get; set; }
        public IQueryable<_BlogList_Result> _BlogList()
        {
            SqlParameter p0 = new SqlParameter();
            return this._BlogList_V.FromSqlRaw($"SELECT * FROM _BlogList()");
        }

		public virtual DbSet<_BlogCategoryList_Result> _BlogCategoryList_V { get; set; }
		public IQueryable<_BlogCategoryList_Result> _BlogCategoryList()
		{
			SqlParameter p0 = new SqlParameter();
			return this._BlogCategoryList_V.FromSqlRaw($"SELECT * FROM _BlogCategoryList()");
		}
	}
}
