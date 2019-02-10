using System;
using System.Web.Mvc;
using RolForServer.Models;
using RolForServer.Controllers.Auth;

namespace RolForServer.Controllers {
	public class BaseViewPage : WebViewPage {
		public readonly RolForContext RolForContext = DependencyResolver.Current.GetService<RolForContext>();
		public virtual new User User => DependencyResolver.Current.GetService<IAuthenticationService>().CurrentUser;

		public bool IsAuthenticated => User != null;

		public bool IsInRole(UserRoles roles) {
			if (User == null)
				return false;
			return User.Role == roles;
		}

		public override void Execute() {
			throw new NotImplementedException();
		}
	}

	public class BaseViewPage<TModel> : WebViewPage<TModel> {
		public readonly RolForContext RolForContext = DependencyResolver.Current.GetService<RolForContext>();
		public virtual new User User => DependencyResolver.Current.GetService<IAuthenticationService>().CurrentUser;

		public bool IsAuthenticated => User != null;

		public bool IsInRole(UserRoles roles) {
			if (User == null)
				return false;
			return User.Role == roles;
		}

		public override void Execute() {
			throw new NotImplementedException();
		}
	}
}