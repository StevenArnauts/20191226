using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Customer = Server.Entities.Customer;

namespace Server.Endpoints {

	[Route("customers")]
	public class CustomersController: ControllerBase {

		private readonly ICustomerRepository _customers;

		public CustomersController(ICustomerRepository customers) {
			this._customers = customers;
		}

		[Route("")]
		[HttpGet]
		public IEnumerable<Customer> List() {
			return this._customers.Entities;
		}

		[HttpPost]
		[Route("")]
		public Customer Add([FromBody] CustomerSpecification spec) {
			return this._customers.Add(spec.Name);	
		}

	}

}
