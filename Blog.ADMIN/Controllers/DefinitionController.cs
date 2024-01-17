using Blog.DATA.Context;
using Blog.DATA.Helper;
using Blog.DATA.Table;
using Microsoft.AspNetCore.Hosting;
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

		#region Blog Status
		[Route("blog-status")]
		public async Task<string> BlogStatus(int blogID)
		{
			try
			{
				var getBlog = _definitionDB.tblBlogMain.FirstOrDefault(x=> x.BlogID == blogID);

				if(getBlog != null)
				{
					getBlog.Status = getBlog.Status == true ? false:true;
					_definitionDB.SaveChanges();

					LogSave(blogID, "Definition", "BlogStatus");
					return "___";
				}
				else return await Task.FromResult("Bu Blog Bulunamadı.");				
			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogStatus");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}
			
		}
		#endregion

		#region Blog Delete
		[Route("blog-delete")]
		public async Task<string> BlogDelete( int blogID)
		{
			try
			{
				var getBlog = _definitionDB.tblBlogMain.FirstOrDefault(x => x.BlogID == blogID);

				if(getBlog != null)
				{
					getBlog.Deleted = true;
					_definitionDB.SaveChanges();

					LogSave(blogID, "Definition", "BlogDelete");
					return "___";
				}
				else return await Task.FromResult("Bu Blog Bulunamadı.");
			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogDelete");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}
		}
		#endregion

		#region Photo Upload
		[Route("blog-file-upload")]
		[HttpPost]
		public async Task<string> BlogFileUpload(IFormFile photoUrl, int blogID, [FromServices] IWebHostEnvironment webHostEnvironment)
		{
			try
			{
				var getBlog = _definitionDB.tblBlogMain.FirstOrDefault(x => x.BlogID == blogID);

				if (getBlog != null)
				{
					if (photoUrl != null && photoUrl.Length > 0)
					{
						var fileNameServer = Path.GetFileName(photoUrl.FileName);
						var fileExtension = Path.GetExtension(fileNameServer);

						// resim tipini kontrol ettik (jpg, jpeg, png)
						if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".png")
						{
							var randomString = Path.GetRandomFileName().Replace(".", "").Substring(0, 5);

							var newFileName = randomString + fileExtension;
							var newFilePath = Path.Combine(webHostEnvironment.WebRootPath, "assets", "Upload", newFileName);

							try
							{
								using (var stream = new FileStream(newFilePath, FileMode.Create))
								{
									await photoUrl.CopyToAsync(stream);
								}

								getBlog.PhotoUrl = "/assets/Upload/" + newFileName;

								_definitionDB.SaveChanges();

								return "___OK";
							}
							catch (Exception)
							{
								return await Task.FromResult("Dosya kaydedilirken bir hata oluştu");
							}
						}
						else return await Task.FromResult("Dosya tipi desteklenmiyor. Lütfen jpg, jpeg veya png dosyası yükleyin.");
					}
					else return await Task.FromResult("Dosya bulunamadı.");
				}
				else return await Task.FromResult("Blog bulunamadı.");
				
			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogFileUpload");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}
		}



        #endregion

        #endregion

        #region Blog Category

        #region Blog Category List
        [Route("blog-category")]
        public async Task<ActionResult> BlogCategory()
        {
            var blogCat = _definitionDB._BlogCategoryList().ToList();
            return await Task.FromResult(View(Tuple.Create(blogCat)));
        }
        #endregion

        #region Blog Category Create Page
        [Route("blog-category-create")]
        public async Task<ActionResult> BlogCategoryCreate()
        {
            
            return await Task.FromResult(View());
        }
		#endregion

		#region Blog Category Create Model
		[Route("blog-category-create")]
		[HttpPost]
		public async Task<string> BlogCategoryCreate(BlogCategoryModel model)
		{
			try
			{
				var mainTbl = _definitionDB.tblBlogCategoryMain.FirstOrDefault(x => x.BlogCategoryName == model.blogCategoryName);

				if (mainTbl == null)
				{
					tblBlogCategoryMain blogMainTbl = new tblBlogCategoryMain();
					blogMainTbl.BlogCategoryName = model.blogCategoryName;
					blogMainTbl.Status = true;
					blogMainTbl.Deleted = false;
					blogMainTbl.RegisterDate = DateTime.Now;

					_definitionDB.tblBlogCategoryMain.Add(blogMainTbl);
					_definitionDB.SaveChanges();

					int blogCategoryID = _definitionDB.tblBlogCategoryMain.Max(x => x.BlogCategoryID);

					if (model.blogCategorySubName != null)
					{
						string url = GlobalFunction.TextLinkReturning(model.url);

						tblBlogCategoryContent cntTbl = new tblBlogCategoryContent();
						cntTbl.BlogCategoryID = blogCategoryID;
						cntTbl.BlogCategorySubName = model.blogCategorySubName;
						cntTbl.Title = model.title;
						cntTbl.Description = model.description;
						cntTbl.Url = url;


						_definitionDB.tblBlogCategoryContent.Add(cntTbl);
						_definitionDB.SaveChanges();

					}
					else return await Task.FromResult("Blog Content Başlık Boş Olamaz.");

					LogSave(blogCategoryID, "Definition", "BlogCategoryCreate");
					return "___";
				}
				else return await Task.FromResult("Bu Blog Daha Önce Eklenmiştir.");

			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogCategoryCreate");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}

		}
		#endregion

		#region Blog Update Page
		[Route("blog-category-update")]
		public async Task<IActionResult> BlogCategoryUpdate(int blogCategoryID)
		{
			var category = _definitionDB.tblBlogCategoryMain.FirstOrDefault(x => x.BlogCategoryID == blogCategoryID);
			return await Task.FromResult(View(Tuple.Create(category)));
		}
		#endregion

		#region Blog Category Create Model
		[Route("blog-category-update")]
		[HttpPost]
		public async Task<string> BlogCategoryUpdate(BlogCategoryModel model)
		{
			try
			{
				var mainTbl = _definitionDB.tblBlogCategoryMain.FirstOrDefault(x => x.BlogCategoryID == model.blogCategoryID);

				if (mainTbl != null)
				{
					mainTbl.BlogCategoryName = model.blogCategoryName;

					_definitionDB.SaveChanges();


					if (model.blogCategorySubName != null)
					{
						var cntTbl = _definitionDB.tblBlogCategoryContent.FirstOrDefault(x => x.BlogCategoryID == model.blogCategoryID);

						if(cntTbl != null)
						{
							string url = GlobalFunction.TextLinkReturning(model.url);

							cntTbl.BlogCategoryID = model.blogCategoryID;
							cntTbl.BlogCategorySubName = model.blogCategorySubName;
							cntTbl.Title = model.title;
							cntTbl.Description = model.description;
							cntTbl.Url = url;

							_definitionDB.SaveChanges();
						}						

					}
					else return await Task.FromResult("Blog Content Başlık Boş Olamaz.");

					LogSave(model.blogCategoryID, "Definition", "BlogCategoryUpdate");
					return "___";
				}
				else return await Task.FromResult("Bu Blog Daha Önce Eklenmiştir.");

			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogCategoryUpdate");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}

		}
		#endregion

		#region Blog Category Status
		[Route("blog-category-status")]
		public async Task<string> BlogCategoryStatus(int blogCategoryID)
		{
			try
			{
				var getBlog = _definitionDB.tblBlogCategoryMain.FirstOrDefault(x => x.BlogCategoryID == blogCategoryID);

				if (getBlog != null)
				{
					getBlog.Status = getBlog.Status == true ? false : true;
					_definitionDB.SaveChanges();

					LogSave(blogCategoryID, "Definition", "BlogCategoryStatus");
					return "___";
				}
				else return await Task.FromResult("Bu Blog Bulunamadı.");
			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogCategoryStatus");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}

		}
		#endregion

		#region Blog Category Delete
		[Route("blog-category-delete")]
		public async Task<string> BlogCategoryDelete(int blogCategoryID)
		{
			try
			{
				var getBlog = _definitionDB.tblBlogCategoryMain.FirstOrDefault(x => x.BlogCategoryID == blogCategoryID);

				if (getBlog != null)
				{
					getBlog.Deleted = true;
					_definitionDB.SaveChanges();

					LogSave(blogCategoryID, "Definition", "BlogCategoryDelete");
					return "___";
				}
				else return await Task.FromResult("Bu Blog Bulunamadı.");
			}
			catch (Exception ex)
			{
				ExceptionSave(ex.Message, "Definition", "BlogCategoryDelete");
				return await Task.FromResult("Beklenmedik bir hata Oluştu. Sistem Yönbeticisine Başvurunuz");
			}
		}
		#endregion

		#endregion
	}
}
