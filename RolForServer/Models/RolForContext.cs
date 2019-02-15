using System;
using System.Data.Entity;
using System.Linq;
// ReSharper disable UnusedAutoPropertyAccessor.Global


namespace RolForServer.Models {
	public sealed class RolForContext : DbContext {
		public DbSet<Container> Containers { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<User> Users { get; set; }

		public override int SaveChanges() {
			ChangeTracker.DetectChanges();

			UpdateUpdatedProperty<Container>();
			UpdateUpdatedProperty<Message>();
			UpdateUpdatedProperty<News>();
			UpdateUpdatedProperty<User>();

			return base.SaveChanges();
		}

		protected override void OnModelCreating(DbModelBuilder builder) {
			builder.HasDefaultSchema("public");
		}

		private void UpdateUpdatedProperty<T>() where T : class {
			var modifiedSourceInfo = ChangeTracker.Entries<T>()
					.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

			foreach (var entry in modifiedSourceInfo) {
				entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
			}
		}
	}
}