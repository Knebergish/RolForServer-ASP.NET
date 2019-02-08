using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RolForServer.Models {
	public sealed class RolForContext : DbContext {
		public DbSet<Forum> Forums { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<User> Users { get; set; }

		public RolForContext(DbContextOptions<RolForContext> options) : base(options) {
			Database.EnsureCreated();
		}

//		protected override void OnModelCreating(ModelBuilder modelBuilder) {
//			modelBuilder.Entity<Message>()
//				.HasKey(c => new {c.ForumId, c.UserId});
//		}

		public override int SaveChanges() {
			ChangeTracker.DetectChanges();

			UpdateUpdatedProperty<Forum>();
			UpdateUpdatedProperty<Message>();
			UpdateUpdatedProperty<News>();
			UpdateUpdatedProperty<User>();

			return base.SaveChanges();
		}

		private void UpdateUpdatedProperty<T>() where T : class {
			var modifiedSourceInfo =
				ChangeTracker.Entries<T>()
					.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

			foreach (var entry in modifiedSourceInfo) {
				entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
			}
		}
	}
}