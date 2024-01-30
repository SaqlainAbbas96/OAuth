using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OAuth.Models
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options) { }
		public DBContext() { }

		public virtual DbSet<User> User { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
