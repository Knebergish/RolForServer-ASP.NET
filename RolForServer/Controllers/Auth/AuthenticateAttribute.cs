using System.Web;
using System.Web.Mvc;
using RolForServer.Models;

namespace RolForServer.Controllers.Auth {
	public class AuthenticateAttribute : AuthorizeAttribute {
		private UserRoles AccessRole { get; }

		public AuthenticateAttribute(UserRoles accessRole) {
			AccessRole = accessRole;
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext) {
			if (AccessRole == 0)
				return true;

			User user = DependencyResolver.Current.GetService<IAuthenticationService>().CurrentUser;
			if (user == null)
				return false;

			return user.Role >= AccessRole;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
			filterContext.Result = new RedirectResult("/Auth/Login");
		}
	}
}