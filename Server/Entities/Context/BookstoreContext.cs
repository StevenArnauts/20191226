using Microsoft.EntityFrameworkCore;

namespace Server.Entities {

	public class BookstoreContext: DbContext {

		public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order>	Orders { get; set; }
		public DbSet<Line> Lines { get; set; }

		protected override void OnModelCreating(ModelBuilder model) {
			model.Entity<Customer>().ToTable("customers");
			model.Entity<Order>().ToTable("orders");
			model.Entity<Line>().ToTable("lines");
		}

	}

}
