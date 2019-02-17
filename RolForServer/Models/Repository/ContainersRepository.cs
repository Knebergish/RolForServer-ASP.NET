using System;
using System.Linq;
using RolForServer.Models.Entities;

namespace RolForServer.Models.Repository {
	public class ContainersRepository : AbstractRepository<Container> {
		public ContainersRepository(RolForContext rolForContext) : base(rolForContext) {
		}

		public bool IsLeaf(int id) {
			return !RolForContext.Containers.Any(con => con.ParentId == id);
		}

		public IOrderedQueryable<Container> GetChildren(int parentId) {
			return RolForContext.Containers
				.Where(con => con.ParentId == parentId)
				.OrderBy(con => con.Id);
		}

		public DateTime? GetFreshness(int id) {
			return RolForContext.Database.SqlQuery<DateTime?>(
				"with recursive leaves (Id, ParentId) as (" +
				"	select c1.\"Id\", c1.\"ParentId\"" +
				"	from \"Containers\" c1 where c1.\"Id\" = @p0" +
				"	union" +
				"	select c2.\"Id\", c2.\"ParentId\"" +
				"	from \"Containers\" c2 inner join leaves on (leaves.Id = c2.\"ParentId\"))" +
				"select max(\"Date\") from \"Messages\"" +
				"where \"ContainerId\" in (select Id from leaves)",
				id).Single();
		}
	}
}