using Blog.DATA.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
	}
}
