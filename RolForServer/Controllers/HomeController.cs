using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RolForServer.Models;

namespace RolForServer.Controllers {
	public class HomeController : Controller {
		private readonly RolForContext _rolForContext;

		public HomeController(RolForContext rolForContext) {
			_rolForContext = rolForContext;
		}

		public IActionResult Index() {
			ViewBag.News = _rolForContext.News;
			return View();
		}

		public IActionResult Forums() {
			ViewBag.Forums = _rolForContext.Forums;
			return View();
		}

		public IActionResult Forum(int id = 0) {
			ViewBag.Forum = _rolForContext.Forums.Find(id);
			ViewBag.Messages = _rolForContext.Messages.Where(message => message.ForumId == id).OrderBy(message => message.Date);
			return View();
		}

		public IActionResult Register() {
			return View();
		}
	}
}