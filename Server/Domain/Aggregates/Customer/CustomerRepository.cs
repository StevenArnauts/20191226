using System;
using System.Linq;
using Server.Entities;
using CustomerEntity = Server.Entities.Customer;

namespace Server.Domain {

	public class CustomerRepository : ICustomerRepository {

		private readonly BookstoreContext _context;

		public CustomerRepository(BookstoreContext context) {
			this._context = context;
		}

		public Customer Get(Guid id) {
			var entity = this._context.Customers.FirstOrDefault(c => c.Id == id);
			return new Customer(entity);
		}

		public Customer Add(string name) {
			CustomerEntity entity = new CustomerEntity { Name = name };
			this._context.Customers.Add(entity);
			this._context.SaveChanges();
			return new Customer(entity);
		}

	}

}
