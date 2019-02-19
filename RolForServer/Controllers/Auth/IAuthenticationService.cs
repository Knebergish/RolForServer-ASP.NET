using RolForServer.Models.Entities;

namespace RolForServer.Controllers.Auth {
	public interface IAuthenticationService {
		void Login(User user, bool rememberMe);

		void Logout();

		User CurrentUser { get; }
	}
}