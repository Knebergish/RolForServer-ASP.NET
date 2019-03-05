using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using RolForServer.Controllers.Auth;
using RolForServer.Models.Entities;

namespace RolForServer.Controllers {
	public class AuthController : ControllerBase {
		private readonly IAuthenticationService _iAuthenticationService;

		public AuthController() {
			_iAuthenticationService = DependencyResolver.Current.GetService<IAuthenticationService>();
		}

		public ActionResult Login() {
			return View();
		}

		public ActionResult Register() {
			return View(new User());
		}

		[HttpPost]
		public ActionResult Register(User newUser) {
			User existUser = UsersRepository.GetByLogin(newUser.Login);
			if (existUser != null) {
				return ErrorToJson("Пользователь с таким логином уже существует.");
			}

			string error = "";
			if (newUser.Login == null
				|| !new Regex(@"^[a-zA-Z][A-Za-z0-9]{1,16}$").IsMatch(newUser.Login)) {
				error = "Логин не отвечает требованиям";
			}
			else if (newUser.Name == null
					|| !new Regex(@"^.{2,20}$").IsMatch(newUser.Name)) {
				error = "Имя пользователя не отвечает требованиям";
			}
			else if (newUser.Password == null
					|| !new Regex(@"^[A-Za-z0-9.,!?(){}<>;:'""\\|/*\-+=_@#№$^]{5,20}$").IsMatch(newUser.Password)) {
				error = "Пароль не отвечает требованиям";
			}
			// До введения системы персонажей description будет тут выполнять роль почты
			else if (newUser.Description == null
					|| !new Regex(@"^[a-zA-Z0-9\-_.]+@.+\.[a-z]{1,4}$").IsMatch(newUser.Description)) {
				error = "Неподдерживаемый формат почтового адреса";
			}

			if (!error.IsEmpty()) {
				return ErrorToJson(error);
			}

			newUser.AvatarImageName = "default_avatar.png";
			newUser.Role = UserRoles.User;
			var user = UsersRepository.Add(newUser);
			UsersRepository.SaveChanges();
			AuthenticationService.Login(user, false);

			var response = new {RedirectURL = Url.Action("Index", "Home")};
			return Json(response, JsonRequestBehavior.AllowGet);
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
		}

		public ActionResult Logout() {
			User currentUser = _iAuthenticationService.CurrentUser;
			if (currentUser != null) {
				_iAuthenticationService.Logout();
			}

			return Redirect(Request.UrlReferrer.ToString());
		}

		private ActionResult ErrorToJson(string error) {
			var errorResponse = new {Error = error};
			return Json(errorResponse, JsonRequestBehavior.AllowGet);
		}
	}
}