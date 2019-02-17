using System;
using System.Web.Mvc;
using RolForServer.Controllers.Auth;
using RolForServer.Models;
using RolForServer.Models.Entities;

namespace RolForServer.Controllers {
	public class MessagesController : ControllerBase {
		[Authenticate(UserRoles.User)]
		public ActionResult Show(int containerId) {
			var container = ValidateAndGetContainer(containerId);

			ViewBag.Container = container;
			ViewBag.Messages = MessagesRepository.GetOrderedFromContainer(containerId);
			return View("Messages");
		}

		[ValidateInput(false)]
		[AuthenticateAttribute(UserRoles.User)]
		public ActionResult Add(int containerId, string text) {
			ValidateAndGetContainer(containerId);

			Message message = new Message {
				UserId = CurrentUser.Id,
				ContainerId = containerId,
				Date = DateTime.Now,
				Text = text
			};
			message = MessagesRepository.Add(message);
			MessagesRepository.SaveChanges();
			return PartialView("Content/_Message", message);
		}

		private Container ValidateAndGetContainer(int containerId) {
			var container = ContainersRepository.Get(containerId);
			if (!ContainersRepository.IsLeaf(containerId)) {
				throw new Exception($"Контейнер с id = {containerId} не может содержать сообщений," +
									" т.к. является родителем для других контейнеров.");
			}

			return container;
		}
	}
}