using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using RolForServer.Controllers.Auth;
using RolForServer.Models;

namespace RolForServer.Controllers {
	public class AuthController : ControllerBase {
		private IAuthenticationService _IAuthenticationService;

		public AuthController() {
			_IAuthenticationService = DependencyResolver.Current.GetService<IAuthenticationService>();
		}

//		[HttpGet]
//		public ActionResult Login() {
//			return View();
//		}
//
//		[HttpPost]
		public ActionResult Login(string errorMessage = "") {
			ViewBag.ErrorMessage = errorMessage;
			return View();
		}

		public ActionResult Log(string userName, string password) {
			if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password)) {
				return RedirectToAction("Login", new {errorMessage = "Что-то пусто."});
			}

			User user = _rolForContext.Users.SingleOrDefault(u => u.Login.Equals(userName));
			if (user == null || !user.Password.Equals(password)) {
				return RedirectToAction("Login", new {errorMessage = "Что-то не так."});
			}

			_IAuthenticationService.Login(user, false);

			return RedirectToAction("Index", "Home");
		}

		public ActionResult Logout() {
			User currentUser = _IAuthenticationService.CurrentUser;
			if (currentUser != null) {
				_IAuthenticationService.Logoff();
			}

			return RedirectToAction("Index", "Home");
		}
	}
}