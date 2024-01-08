using Blog.DATA.Context;
using Microsoft.AspNetCore.Mvc;

namespace Blog.ADMIN.Controllers
{
	public class DefinitionController : BaseController
	{
		private readonly Conn _definitionDB;

		#region Ctor
		public DefinitionController(Conn context) : base(context)
		{
			_definitionDB = context;
		}
        #endregion


        #region Blog

        #region Blog List
        [Route("blog")]
        public async Task<IActionResult> Blog()
        {
            var blogList = _definitionDB._BlogList().OrderByDescending(x=> x.BlogID).ToList();
            return await Task.FromResult(View(Tuple.Create(blogList)));
        }
		#endregion


		#region Blog Create
		[Route("blog-create")]
		public async Task<IActionResult> BlogCreate()
		{
			return await Task.FromResult(View());
		}
		#endregion


		#endregion


	}
}
