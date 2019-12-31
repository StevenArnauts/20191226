using System.Linq;
using Server.Utilities.Exceptions;
using CustomerEntity = Server.Entities.Customer;

namespace Server.Domain {

	public class Customer: Aggregate<CustomerEntity> {
				
		public Customer(CustomerEntity entity) : base (entity) { }

		// don't do queries
		// public string Name => this._entity.Name;
		// public IEnumerable<Order> Orders => this._entity.Orders.Select(o => new Order(o));

		public void AddOrder(Order order) {
			Throw<BusinessException>.When(this.Root.Orders.Any(o => o.Paid != null), "Customer " + this.Id + " already has an outstanding order");
			this.Root.Orders.Add(order.Root);
		}

	}

}
