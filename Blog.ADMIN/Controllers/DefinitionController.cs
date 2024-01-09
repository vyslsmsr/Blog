using Blog.DATA.Context;
using Blog.DATA.Helper;
using Blog.DATA.Table;
using Microsoft.AspNetCore.Mvc;
using static Blog.DATA.Validation._Definition._Blog;

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
        [Route("blogs")]
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

		#region Blog Create Model
		[Route("blog-create")]
		[HttpPost]		
		public async Task<string> BlogCreate(BlogModel model)
		{
			try
			{
				var mainTbl = _definitionDB.tblBlogMain.FirstOrDefault(x => x.BlogName == model.blogName);

				if(mainTbl == null)
				{
					tblBlogMain blogMainTbl = new tblBlogMain();
					blogMainTbl.BlogName = model.blogName;
					blogMainTbl.BlogCategoryID = model.blogCategoryID;
					blogMainTbl.Status = true;
					blogMainTbl.Deleted = false;
					blogMainTbl.RegisterDate = DateTime.Now;

					_definitionDB.tblBlogMain.Add(blogMainTbl);
					_definitionDB.SaveChanges();

					int blogID = _definitionDB.tblBlogMain.Max(x => x.BlogID);

					if(model.blogSubName != null)
					{
						string url = GlobalFunction.TextLinkReturning(model.url);

						tblBlogContent cntTbl = new tblBlogContent();
						cntTbl.BlogID = blogID;
						cntTbl.BlogSubName = model.blogSubName;
						cntTbl.ShortText = model.shortText;
						cntTbl.BlogContent = model.blogContent;
						cntTbl.Title = model.title;
						cntTbl.Description = model.description;
						cntTbl.Url = url;

						_definitionDB.tblBlogContent.Add(cntTbl);
						_definitionDB.SaveChanges();

					}
					else return await Task.FromResult("Blog Content Başlık Boş Olamaz.");

					LogSave(blogID, "Definition", "BlogCreate");
					return "___";
				}
				else return await Task.FromResult("Bu Blog Daha Önce Eklenmiştir.");

			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogCreate");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}
			
		}
		#endregion

		#region Blog Update
		[Route("blog-update")]
		public async Task<IActionResult> BlogUpdate(int blogID)
		{
			var getBlog = _definitionDB.tblBlogMain.FirstOrDefault(x=> x.BlogID == blogID);
			return await Task.FromResult(View(getBlog));
		}
		#endregion

		#region Blog Create Model
		[Route("blog-update")]
		[HttpPost]
		public async Task<string> BlogUpdate(BlogModel model)
		{
			try
			{
				var mainTbl = _definitionDB.tblBlogMain.FirstOrDefault(x => x.BlogID == model.blogID);

				if (mainTbl != null)
				{
					mainTbl.BlogName = model.blogName;
					mainTbl.BlogCategoryID = model.blogCategoryID;

					_definitionDB.SaveChanges();

					if (model.blogSubName != null)
					{

						var cntTbl = _definitionDB.tblBlogContent.FirstOrDefault(x => x.BlogID == model.blogID);

						if (cntTbl != null)
						{
							string url = GlobalFunction.TextLinkReturning(model.url);

							cntTbl.BlogID = model.blogID;
							cntTbl.BlogSubName = model.blogSubName;
							cntTbl.ShortText = model.shortText;
							cntTbl.BlogContent = model.blogContent;
							cntTbl.Title = model.title;
							cntTbl.Description = model.description;
							cntTbl.Url = url;

							_definitionDB.SaveChanges();
						}
					}
					else return await Task.FromResult("Blog Content Başlık Boş Olamaz.");

					LogSave(model.blogID, "Definition", "BlogUpdate");
					return "___";
				}
				else return await Task.FromResult("Bu Blog Daha Önce Eklenmiştir.");

			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogUpdate");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}

		}
		#endregion

		#endregion


	}
}
