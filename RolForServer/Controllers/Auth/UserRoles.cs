using System;
using System.Collections.Generic;

namespace RolForServer.Controllers.Auth {
	public enum UserRoles {
		None = 0,
		User = 1,
		Master = 2,
		Moderator = 3,
		Admin = 4
	}

	public static class RolesHelper {
		private static UserRoles[] _roles;

		public static UserRoles[] GetRoles() {
			if (_roles == null || _roles.Length == 0) {
				UserRoles[] roles = Enum.GetValues(typeof(UserRoles)) as UserRoles[];
				List<UserRoles> rolesToArr = new List<UserRoles>();
				foreach (UserRoles userRolese in roles) {
					if (userRolese != UserRoles.None) {
						rolesToArr.Add(userRolese);
					}
				}

				_roles = rolesToArr.ToArray();
			}

			return _roles;
		}
	}
}