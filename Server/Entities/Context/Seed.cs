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
				this._context.Add(new Customer { Id = Guid.NewGuid(), Name = "Banden Janssens" });
				this._context.Add(new Customer { Id = Guid.NewGuid(), Name = "Bakkerij Van Kampen" });
				this._context.SaveChanges();
			}
		}

	}

}
