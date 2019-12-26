using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Server.Entities;
using CustomerEntity = Server.Entities.Customer;

namespace Server.Domain {

	public class Spec<T> {

		public Predicate<T> OtherCondition { get; }
		public Expression<Func<T, bool>> Condition { get; }

	}

	public class CustomerRepository : ICustomerRepository {

		private readonly BookstoreContext _context;

		public CustomerRepository(BookstoreContext context) {
			this._context = context;
		}

		public IEnumerable<Customer> Entities {
			get {
				return this._context.Customers.Select(c => new Customer(c));
			}
		}

		public Customer Get(Guid id)
		{
			var s = new Spec<CustomerEntity>();
			var test = this._context.Customers.Where(s.Condition);
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
