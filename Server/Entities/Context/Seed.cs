using System;
using System.Linq;

namespace Server.Entities {

	/// <summary>
	/// Is run on startup to add sample data to the database.
	/// </summary>
	public class Seed {

		private readonly BookstoreContext _context;

		public Seed(BookstoreContext context) {
			this._context = context;
		}

		public void Run() {
			if (!this._context.Customers.Any()) {

				var customer1 = new Customer { Name = "Banden Janssens" };
				this._context.Add(customer1);

				this._context.Customers.Add(new Customer { Name = "Bakkerij Van Kampen" });

				Order order1 = new Order { Customer = customer1, Date = DateTime.Now, Description = "My first order" };
				order1.Lines.Add(new Line { Amount = 1, Product = "Apple" });
				order1.Lines.Add(new Line { Amount = 4, Product = "Pear" });
				customer1.Orders.Add(order1);

				this._context.SaveChanges();
			}
		}

	}

}
