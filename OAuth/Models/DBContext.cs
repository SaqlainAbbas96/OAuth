using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OAuth.Models
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options) { }
		public DBContext() { }

		public virtual DbSet<User> User { get; set; }
		public virtual DbSet<Role> Role { get; set; }
		public virtual DbSet<UserRoles> UserRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserRoles>()
				.HasKey(sc => new { sc.userId, sc.roleId });

			base.OnModelCreating(modelBuilder);
		}
	}
}
