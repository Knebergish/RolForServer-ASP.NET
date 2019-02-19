using System;
using System.Web;
using System.Web.Mvc;
using RolForServer.Controllers.Auth;
using RolForServer.Models.Entities;

namespace RolForServer.Controllers {
	public class AuthController : ControllerBase {
		private readonly IAuthenticationService _iAuthenticationService;

		public AuthController() {
			_iAuthenticationService = DependencyResolver.Current.GetService<IAuthenticationService>();
		}

		public ActionResult Login(string errorMessage = "") {
			ViewBag.ErrorMessage = errorMessage;
			return View();
		}

		public ActionResult Authenticate(string login, string password, bool rememberMe) {
			if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password)) {
				return ErrorToJson("Все поля должны быть заполнены.");
			}

			User user = UsersRepository.GetByLogin(login);
			if (user == null || !user.Password.Equals(password)) {
				return ErrorToJson("Учётные данные неверны.");
			}

			_iAuthenticationService.Login(user, rememberMe);

			string redirectUrl;
			HttpCookie cookie = HttpContext.Request.Cookies["RedirectURL"];
			if (cookie != null) {
				cookie.Expires = DateTime.Now.AddDays(-1d);
				HttpContext.Response.Cookies.Add(cookie);
				redirectUrl = cookie.Value;
			}
			else {
				redirectUrl = Url.Action("Index", "Home");
			}

			var response = new {RedirectURL = redirectUrl};
			return Json(response, JsonRequestBehavior.AllowGet);

			ActionResult ErrorToJson(string error) {
				var errorResponse = new {Error = error};
				return Json(errorResponse, JsonRequestBehavior.AllowGet);
			}
		}

		public ActionResult Register() {
			return View();
		}

		public ActionResult Logout() {
			User currentUser = _iAuthenticationService.CurrentUser;
			if (currentUser != null) {
				_iAuthenticationService.Logout();
			}

			return RedirectToAction("Index", "Home");
		}
	}
}