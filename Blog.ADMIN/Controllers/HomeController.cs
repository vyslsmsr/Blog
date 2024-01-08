using Blog.DATA.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.ADMIN.Controllers
{
    public class HomeController : BaseController
    {
        private readonly Conn _homeDB;

        #region Ctor
        public HomeController(Conn context) : base(context)
        {
            _homeDB = context;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

    }
}
