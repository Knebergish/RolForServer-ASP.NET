using System.Web.Mvc;
using RolForServer.Controllers.Auth;

namespace RolForServer.Controllers {
	public class ContainersController : ControllerBase {
		[Authenticate(UserRoles.User)]
		public ActionResult Show(int containerId) {
			var container = ContainersRepository.Get(containerId);
			if (ContainersRepository.IsLeaf(containerId)) {
				return RedirectToAction("Show", "Messages", new {containerId});
			}

			ViewBag.Parent = container;
			ViewBag.Children = ContainersRepository.GetChildren(containerId);
			return View("Containers");
		}
	}
}