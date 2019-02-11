using System.Linq;
using System.Web.Mvc;
using RolForServer.Controllers.Auth;

namespace RolForServer.Controllers {
	public class HomeController : ControllerBase {
		public ActionResult Index() {
			ViewBag.News = _rolForContext.News;
			return View();
		}

		[AuthenticateAttribute(UserRoles.User)]
		public ActionResult Forums() {
			ViewBag.Forums = _rolForContext.Forums;
			return View();
		}
		[AuthenticateAttribute(UserRoles.User)]
		public ActionResult Forum(int id = 0) {
			ViewBag.Forum = _rolForContext.Forums.Find(id);
			ViewBag.Messages = _rolForContext.Messages.Where(message => message.ForumId == id)
				.OrderBy(message => message.Date);
			return View();
		}
	}
}