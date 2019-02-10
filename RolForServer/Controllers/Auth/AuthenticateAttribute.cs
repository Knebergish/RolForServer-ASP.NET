using System.Web;
using System.Web.Mvc;
using Ninject;
using RolForServer.Models;

namespace RolForServer.Controllers.Auth {
	public class AuthenticateAttribute : AuthorizeAttribute {
		private IAuthenticationService _IAuthenticationService;

		public bool AllowAnonymus { get; set; }

		public UserRoles AccessRole { get; }

//		public AuthenticateAttribute(IAuthenticationService IAuthenticationService) {
//			_IAuthenticationService = IAuthenticationService;
//		}

//		public AuthenticateAttribute(bool allowAnonymus) {
//			AllowAnonymus = allowAnonymus;
//		}

		public AuthenticateAttribute(UserRoles accessRole) {
			_IAuthenticationService = DependencyResolver.Current.GetService<IAuthenticationService>();
			AccessRole = accessRole;
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext) {
			if (AllowAnonymus)
				return true;

			User user = _IAuthenticationService.CurrentUser;
			if (user == null)
				return false;

			if (AccessRole == 0)
				return true;

			return user.Role == AccessRole;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
			filterContext.Result = new RedirectResult("/login", false);
		}
		
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (AuthorizeCore(filterContext.HttpContext))
			{
				base.OnAuthorization(filterContext);
			}
			else
			{
				filterContext.Result = new RedirectResult("/Auth/Login");
			}
		}
	}
}