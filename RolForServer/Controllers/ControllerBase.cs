using System.Web.Mvc;
using RolForServer.Controllers.Auth;
using RolForServer.Models;
using RolForServer.Models.Entities;
using RolForServer.Models.Repository;

namespace RolForServer.Controllers {
	public class ControllerBase : Controller {
		private readonly RolForContext RolForContext;
		protected readonly IAuthenticationService AuthenticationService;

		protected readonly ContainersRepository ContainersRepository;
		protected readonly MessagesRepository MessagesRepository;
		protected readonly NewsRepository NewsRepository;
		protected readonly UsersRepository UsersRepository;


		public ControllerBase() {
			RolForContext = DependencyResolver.Current.GetService<RolForContext>();
			AuthenticationService = DependencyResolver.Current.GetService<IAuthenticationService>();
			ContainersRepository = new ContainersRepository(RolForContext);
			MessagesRepository = new MessagesRepository(RolForContext);
			NewsRepository = new NewsRepository(RolForContext);
			UsersRepository = new UsersRepository(RolForContext);
		}

		public User CurrentUser => AuthenticationService.CurrentUser;

		protected bool IsAuthenticated => CurrentUser != null;
	}
}