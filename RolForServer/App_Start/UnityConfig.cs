using System.Web.Mvc;
using RolForServer.Controllers.Auth;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace RolForServer {
	public class UnityConfig {
		public static void RegisterComponents() {
			var container = new UnityContainer();

			container.RegisterType<IAuthenticationService, FormsAuthenticationService>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}