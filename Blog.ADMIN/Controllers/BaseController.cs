using Blog.DATA.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.ADMIN.Controllers
{
	public class BaseController : Controller
	{
		public int langID { get; set; } = 1;
		public int changeID { get; set; } = 0;


		private readonly Conn _db;

		#region Ctor   
		public BaseController(Conn context)
		{
			_db = context;
		}
		#endregion

		#region Açılışta Bu Çalışır
		public override void OnActionExecuting(ActionExecutingContext context)
		{

		}
		#endregion
	}
}
