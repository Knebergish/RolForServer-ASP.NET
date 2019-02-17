using System.Linq;
using RolForServer.Models.Entities;

namespace RolForServer.Models.Repository {
	public class UsersRepository : AbstractRepository<User> {
		public UsersRepository(RolForContext rolForContext) : base(rolForContext) {
		}

		public User GetByLogin(string login) {
			return RolForContext.Users.SingleOrDefault(u => u.Login.Equals(login));
		}
	}
}