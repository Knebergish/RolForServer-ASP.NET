using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RolForServer.Models;

namespace RolForServer.Controllers.Auth {
	public class FormsAuthenticationService : IAuthenticationService {
		private const string AuthCookieName = "AuthCookie";

		private readonly RolForContext _rolForContext;

		public FormsAuthenticationService() {
			_rolForContext = DependencyResolver.Current.GetService<RolForContext>();
		}

		public void Login(User user, bool rememberMe) {
			if (_currentUser != null) {
				Logout();
			}

			SaveAuthCookie(user, rememberMe);

			_currentUser = user;
		}

		private static void SaveAuthCookie(User user, bool rememberMe) {
			DateTime expiresDate = DateTime.Now.AddMinutes(30);
			if (rememberMe)
				expiresDate = expiresDate.AddDays(10);

			FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
				1,
				user.Id.ToString(),
				DateTime.Now,
				expiresDate, rememberMe, user.Id.ToString());
			string encryptedTicket = FormsAuthentication.Encrypt(ticket);

			SetValue(AuthCookieName, encryptedTicket, expiresDate);
		}

		public void Logout() {
			SetValue(AuthCookieName, null, DateTime.Now.AddYears(-1));
			_currentUser = null;
		}

		private User _currentUser;

		public User CurrentUser {
			get {
				if (_currentUser != null) 
					return _currentUser;

				object cookie = HttpContext.Current.Request.Cookies[AuthCookieName]?.Value;
				if (cookie == null || string.IsNullOrEmpty(cookie.ToString())) 
					return null;

				try {
					var ticket = FormsAuthentication.Decrypt(cookie.ToString());
					// ReSharper disable once PossibleNullReferenceException
					var id = int.Parse(ticket.Name);
					_currentUser = _rolForContext.Users.First(user => user.Id == id);
					SaveAuthCookie(_currentUser, ticket.IsPersistent);
				}
				catch (Exception) {
					HttpContext.Current.Request.Cookies.Remove(AuthCookieName);
				}

				return _currentUser;
			}
		}

		public static void SetValue(string cookieName, string cookieObject, DateTime dateStoreTo) {
			HttpCookie cookie = HttpContext.Current.Response.Cookies[cookieName];
			if (cookie == null) {
				cookie = new HttpCookie(cookieName);
				cookie.Path = "/";
			}

			cookie.Value = cookieObject;
			cookie.Expires = dateStoreTo;

			HttpContext.Current.Response.SetCookie(cookie);
		}
	}
}