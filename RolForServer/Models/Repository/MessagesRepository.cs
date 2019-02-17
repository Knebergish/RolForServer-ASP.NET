using System.Linq;
using RolForServer.Models.Entities;

namespace RolForServer.Models.Repository {
	public class MessagesRepository : AbstractRepository<Message> {
		public MessagesRepository(RolForContext rolForContext) : base(rolForContext) {
		}

		public IOrderedQueryable<Message> GetOrderedFromContainer(int containerId) {
			return RolForContext.Messages
				.Where(message => message.ContainerId == containerId)
				.OrderBy(message => message.Date);
		}
	}
}