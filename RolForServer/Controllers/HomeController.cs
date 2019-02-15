using System;
using System.Linq;
using System.Web.Mvc;
using RolForServer.Controllers.Auth;
using RolForServer.Models;

namespace RolForServer.Controllers {
	public class HomeController : ControllerBase {
		public ActionResult Index() {
			ViewBag.News = _rolForContext.News;
			return View();
		}

		[AuthenticateAttribute(UserRoles.User)]
		public ActionResult Container(int containerId = 0) {
			var container = GetContainer(containerId);
			int childrenCount = _rolForContext.Containers.Count(con => con.ParentId == containerId);
			if (childrenCount == 0) {
				return Messages(containerId);
			}

			ViewBag.Parent = container;
			ViewBag.Children = _rolForContext.Containers
				.Where(con => con.ParentId == containerId)
				.OrderBy(con => con.Id);
			return View();
		}

		[AuthenticateAttribute(UserRoles.User)]
		public ActionResult Messages(int containerId = 0) {
			var container = GetContainer(containerId);
			int childrenCount = _rolForContext.Containers.Count(con => con.ParentId == containerId);
			if (childrenCount != 0) {
				throw new Exception($"Контейнер с id = {containerId} не может содержать сообщений," +
									" т.к. является родителем для других контейнеров.");
			}

			ViewBag.Container = container;
			ViewBag.Messages = _rolForContext.Messages
				.Where(message => message.ContainerId == containerId)
				.OrderBy(message => message.Date);
			return View("Messages");
		}

		private Container GetContainer(int containerId) {
			Container container = _rolForContext.Containers.Find(containerId);
			if (container == null) {
				throw new Exception($"Контейнера с id = {containerId} не существует!");
			}

			return container;
		}
	}
}