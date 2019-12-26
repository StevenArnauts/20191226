using System.Collections.Generic;

namespace Server {

	public interface ICustomerRepository {

		IEnumerable<Customer> Entities { get; }
		Customer Add(string name);

	}

}