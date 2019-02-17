using System;
using System.Data.Entity;

namespace RolForServer.Models.Repository {
	public class AbstractRepository<T> where T : class {
		protected readonly RolForContext RolForContext;

		public AbstractRepository(RolForContext rolForContext) {
			RolForContext = rolForContext;
		}

		public T Get(int id) {
			T item = RolForContext.Set<T>().Find(id);
			if (item == null) {
				throw new Exception($"{typeof(T).Name} с id = {id} не существует!");
			}

			return item;
		}

		public DbSet<T> GetAll() {
			return RolForContext.Set<T>();
		}

		public T Add(T item) {
			T newItem = RolForContext.Set<T>().Add(item);
			return newItem;
		}

		public void Remove(int id) {
			RolForContext.Set<T>().Remove(Get(id));
		}

		public void SaveChanges() {
			RolForContext.SaveChanges();
		}
	}
}