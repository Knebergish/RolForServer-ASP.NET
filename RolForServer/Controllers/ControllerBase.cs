using System.Web.Mvc;
using RolForServer.Controllers.Auth;
using RolForServer.Models;

namespace RolForServer.Controllers {
	public class ControllerBase : Controller {
		protected readonly RolForContext _rolForContext;
		protected readonly IAuthenticationService _AuthenticationService;

		public ControllerBase() {
			_rolForContext = DependencyResolver.Current.GetService<RolForContext>();
			_AuthenticationService = DependencyResolver.Current.GetService<IAuthenticationService>();
		}

		public User CurrentUser => _AuthenticationService.CurrentUser;

		protected bool IsAuthenticated => CurrentUser != null;
	}
}