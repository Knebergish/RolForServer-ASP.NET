using System;
using System.Web.Mvc;
using RolForServer.Controllers.Auth;
using RolForServer.Models;
using RolForServer.Models.Entities;
using RolForServer.Models.Repository;

namespace RolForServer.Views {
	public class BaseViewPage : WebViewPage {
		public readonly ContainersRepository ContainersRepository;
		public readonly MessagesRepository MessagesRepository;
		public readonly NewsRepository NewsRepository;
		public readonly UsersRepository UsersRepository;

		//public readonly RolForContext RolForContext = DependencyResolver.Current.GetService<RolForContext>();
		public new User User => DependencyResolver.Current.GetService<IAuthenticationService>().CurrentUser;

		public BaseViewPage() {
			var rolForContext = DependencyResolver.Current.GetService<RolForContext>();

			ContainersRepository = new ContainersRepository(rolForContext);
			MessagesRepository = new MessagesRepository(rolForContext);
			NewsRepository = new NewsRepository(rolForContext);
			UsersRepository = new UsersRepository(rolForContext);
		}

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
		public readonly ContainersRepository ContainersRepository;
		public readonly MessagesRepository MessagesRepository;
		public readonly NewsRepository NewsRepository;
		public readonly UsersRepository UsersRepository;

		//public readonly RolForContext RolForContext = DependencyResolver.Current.GetService<RolForContext>();
		public new User User => DependencyResolver.Current.GetService<IAuthenticationService>().CurrentUser;

		public BaseViewPage() {
			var rolForContext = DependencyResolver.Current.GetService<RolForContext>();

			ContainersRepository = new ContainersRepository(rolForContext);
			MessagesRepository = new MessagesRepository(rolForContext);
			NewsRepository = new NewsRepository(rolForContext);
			UsersRepository = new UsersRepository(rolForContext);
		}

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