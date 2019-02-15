using System;

namespace RolForServer.Controllers.Auth {
	public enum UserRoles {
		None = 0,
		User = 1,
		Master = 2,
		Moderator = 3,
		Admin = 4
	}

	public static class RolesHelper {
		public static String GetLocalizedName(this UserRoles role) {
			switch (role) {
				case UserRoles.None:
					return "Никто";
				case UserRoles.User:
					return "Пользователь";
				case UserRoles.Master:
					return "Мастер";
				case UserRoles.Moderator:
					return "Модератор";
				case UserRoles.Admin:
					return "Администратор";
				default:
					return "What?!";
			}
		}
	}
}