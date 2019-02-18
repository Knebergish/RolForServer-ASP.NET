using System;
using System.IO;
using System.Web.Mvc;
using RolForServer.Controllers.Auth;
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
		public ActionResult Add(int containerId, string text) {
			if (!IsAuthenticated || AuthenticationService.CurrentUser.Role < UserRoles.User) {
				var error = new {Error = "У вас прав нет."};
				return Json(error, JsonRequestBehavior.AllowGet);
			}

			try {
				ValidateAndGetContainer(containerId);
			}
			catch (Exception e) {
				var error = new {Error = e.Message};
				return Json(error, JsonRequestBehavior.AllowGet);
			}

			Message message = new Message {
				UserId = CurrentUser.Id,
				ContainerId = containerId,
				Date = DateTime.Now,
				Text = text
			};
			message = MessagesRepository.Add(message);
			MessagesRepository.SaveChanges();
			var response = new {Html = ConvertViewToString("Content/_Message", message)};
			return Json(response, JsonRequestBehavior.AllowGet);
		}
		
		private string ConvertViewToString(string viewName, object model)
		{
			ViewData.Model = model;
			using (StringWriter writer = new StringWriter())
			{
				ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
				ViewContext vContext = new ViewContext(ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
				vResult.View.Render(vContext, writer);
				return writer.ToString();
			}
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