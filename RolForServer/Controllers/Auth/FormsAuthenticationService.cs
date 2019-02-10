using System;
using System.Configuration;
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
				Logoff();
			}

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

			_currentUser = user;
		}

		public void Logoff() {
			SetValue(AuthCookieName, null, DateTime.Now.AddYears(-1));
			_currentUser = null;
		}

		/// &lt;summary&gt;
		/// Generate password
		/// &lt;/summary&gt;
		/// &lt;param name="pass"&gt;Original password&lt;/param&gt;
		/// &lt;param name="salt"&gt;User ID + " " + User.ID&lt;/param&gt;
		/// &lt;returns&gt;&lt;/returns&gt;
		public string GeneratePassword(string pass, string salt) {
			return ""; //OxoCrypt.MD5(pass + OxoCrypt.MD5(pass + salt + " " + salt));
		}

		private User _currentUser;

		public User CurrentUser {
			get {
				if (_currentUser == null) {
					object cookie = HttpContext.Current.Request.Cookies[AuthCookieName]?.Value;
					if (cookie == null || string.IsNullOrEmpty(cookie.ToString())) return _currentUser;
					var ticket = FormsAuthentication.Decrypt(cookie.ToString());
					int id = int.Parse(ticket.Name);
					_currentUser = _rolForContext.Users.First(user => user.Id == id);
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