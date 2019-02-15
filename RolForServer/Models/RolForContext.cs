using System.Data.Entity;

// ReSharper disable UnusedAutoPropertyAccessor.Global


namespace RolForServer.Models {
	public sealed class RolForContext : DbContext {
		public DbSet<Container> Containers { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<User> Users { get; set; }

		public override int SaveChanges() {
			ChangeTracker.DetectChanges();
			return base.SaveChanges();
		}

		protected override void OnModelCreating(DbModelBuilder builder) {
			builder.HasDefaultSchema("public");
		}
	}
}