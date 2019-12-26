using System;
using System.Collections.Generic;

namespace Server.Entities {

	public class CustomerRepository : ICustomerRepository {

		private readonly BookstoreContext _context;

		public CustomerRepository(BookstoreContext context) {
			this._context = context;
		}

		public IEnumerable<Customer> Entities {
			get {
				return this._context.Customers;
			}
		}

		public Customer Add(string name) {
			Customer entity = new Customer { Id = Guid.NewGuid(), Name = name };
			this._context.Customers.Add(entity);
			this._context.SaveChanges();
			return entity;
		}

	}

}
