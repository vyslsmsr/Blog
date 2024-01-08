using Blog.DATA.Context;
using Blog.DATA.Table;
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

		#region Hata Kaydı
		public void ExceptionSave(string description, string controller, string action)
		{
			try
			{
				tblException exception = new tblException();
				exception.Description = description;
				exception.Controller = controller;
				exception.Action = action;
				exception.RegisterDate = DateTime.Now;
				exception.Username = "Admin";
				exception.UserID = "123456";
				exception.IpNm = IpNm();
				_db.tblException.Add(exception);
				_db.SaveChanges();
			}
			catch (Exception ex)
			{
			}
		}

		#endregion

		#region IP Numarası
		public string IpNm()
		{
			return HttpContext.Connection.RemoteIpAddress?.ToString();
		}
		#endregion

		#region Log Kaydı
		public void LogSave(object recordID, string controller, string action)
		{
			try
			{
				tblLog tblLog = new tblLog();
				tblLog.RecordID = recordID.ToString();
				tblLog.Controller = controller;
				tblLog.Action = action;
				tblLog.Username = "Admin";
				tblLog.UserID = "123456789";
				tblLog.IpNm = IpNm();
				tblLog.ProcessingDate = DateTime.Now;
				tblLog.GroupID = 1;
				_db.tblLog.Add(tblLog);
				_db.SaveChanges();
			}
			catch (Exception)
			{
				ExceptionSave("Log Hatası", controller, action);
			}
		}

		#endregion
	}
}
