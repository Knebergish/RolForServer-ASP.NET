using RolForServer.Models;

namespace RolForServer.Controllers.Auth {
	public interface IAuthenticationService {
		void Login(User user, bool rememberMe);

		void Logoff();

		string GeneratePassword(string pass, string salt);

		User CurrentUser { get; }
	}
}