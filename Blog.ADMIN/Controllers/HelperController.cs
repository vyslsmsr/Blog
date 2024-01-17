using Blog.DATA.Context;
using Blog.DATA.Table;
using Microsoft.AspNetCore.Mvc;

namespace Blog.ADMIN.Controllers
{
	public class HelperController : BaseController
	{


		private readonly Conn _helperDB;

		#region Ctor
		public HelperController(Conn context) : base(context)
		{
			_helperDB = context;
		}
		#endregion

		#region Blog Content
		public tblBlogContent? BlogContent(int? blogID)
		{
			return _helperDB.tblBlogContent.FirstOrDefault(x => x.BlogID == blogID);
		}
		#endregion

		#region Blog Category Content
		public tblBlogCategoryContent? BlogCategoryContent(int? blogCategoryID)
		{
			return _helperDB.tblBlogCategoryContent.FirstOrDefault(x => x.BlogCategoryID == blogCategoryID);
		}
		#endregion
	}
}
