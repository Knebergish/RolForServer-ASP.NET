using System.Web.Mvc;

namespace RolForServer.Controllers {
	public class HomeController : ControllerBase {
		public ActionResult Index() {
			ViewBag.News = NewsRepository.GetAll();
			return View();
		}
	}
}