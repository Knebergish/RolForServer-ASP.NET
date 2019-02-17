using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using RolForServer.Controllers.Auth;
using RolForServer.Models;
using RolForServer.Models.Entities;

namespace RolForServer.Controllers {
	public class AuthController : ControllerBase {
		private IAuthenticationService _IAuthenticationService;

		public AuthController() {
			_IAuthenticationService = DependencyResolver.Current.GetService<IAuthenticationService>();
		}

		public ActionResult Login(string errorMessage = "") {
			ViewBag.ErrorMessage = errorMessage;
			return View();
		}

		public ActionResult Authenticate(string login, string password, bool rememberMe) {
			if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password)) {
				return RedirectToAction("Login", new {errorMessage = "Что-то пусто."});
			}

			User user = UsersRepository.GetByLogin(login);
			if (user == null || !user.Password.Equals(password)) {
				return RedirectToAction("Login", new {errorMessage = "Что-то не так."});
			}

			_IAuthenticationService.Login(user, rememberMe);

			return RedirectToAction("Index", "Home");
		}

		public string CheckUser(string login, string password) {
			if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password)) {
				return "Что-то пусто.";
			}

			User user = UsersRepository.GetByLogin(login);
			if (user == null || !user.Password.Equals(password)) {
				return "Что-то не так.";
			}

			return "";
		}

		public ActionResult Register() {
			return View();
		}

		public ActionResult Logout() {
			User currentUser = _IAuthenticationService.CurrentUser;
			if (currentUser != null) {
				_IAuthenticationService.Logout();
			}

			return RedirectToAction("Index", "Home");
		}
	}
}