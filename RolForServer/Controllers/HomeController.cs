using Microsoft.AspNetCore.Mvc;
using RolForServer.Views.Home;

namespace RolForServer.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Forums() {
            ViewBag.Forums = Repo.Forums;
            return View();
        }

        public IActionResult Forum(int id = 0) {
            ViewBag.Forum = Repo.Forums[id];
            ViewBag.Messages = Repo.Messages.FindAll(message => message.ForumId == id);
            return View();
        }
    }
}