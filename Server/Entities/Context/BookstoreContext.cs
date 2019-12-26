using Microsoft.EntityFrameworkCore;

namespace Server.Entities {

	public class BookstoreContext: DbContext {

		public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

		public DbSet<Customer> Customers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Customer>().ToTable("customers");
		}

	}

}
