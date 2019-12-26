using System.Collections.Generic;

namespace Server.Domain {

	public interface ICustomerRepository {

		IEnumerable<Customer> Entities { get; }

		/// <summary>
		/// Adds a new customer with the specified <paramref name="name"/> to the persistent store and saves changes.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		Customer Add(string name);

	}

}