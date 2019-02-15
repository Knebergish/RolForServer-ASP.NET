using RolForServer.Controllers.Auth;

namespace RolForServer.Models {
	public class User {
		public int Id { get; set; }
		public string Login { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string Description { get; set; }
		public string AvatarImageName { get; set; }
		public UserRoles Role { get; set; }
	}
}