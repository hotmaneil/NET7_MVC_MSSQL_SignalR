using Microsoft.AspNetCore.Mvc;

namespace MVC_MSSQL_SignalR.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
