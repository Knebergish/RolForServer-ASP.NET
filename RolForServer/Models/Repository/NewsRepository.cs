using RolForServer.Models.Entities;

namespace RolForServer.Models.Repository {
	public class NewsRepository : AbstractRepository<News> {
		public NewsRepository(RolForContext rolForContext) : base(rolForContext) {
		}
	}
}