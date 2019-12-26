using System;
using System.Collections.Generic;

namespace Server {

	public class CustomerRepository : ICustomerRepository {

		private readonly List<Customer> _customers = new List<Customer> {
			new Customer {Id = Guid.NewGuid(), Name = "Banden Janssens" },
			new Customer {Id = Guid.NewGuid(), Name = "Bakkerij Van Kampen" }
		};

		public IEnumerable<Customer> Entities {
			get {
				return _customers.AsReadOnly();
			}
		}

		public Customer Add(string name) {
			Customer entity = new Customer { Id = Guid.NewGuid(), Name = name };
			_customers.Add(entity);
			return entity;
		}

	}

}
