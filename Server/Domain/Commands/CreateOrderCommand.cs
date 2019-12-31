using System;

namespace Server.Domain {

	/// <summary>
	/// Or "service"? (in order not to have to create an explicit command for everything
	/// I only wanted to encapsulate the two lines creating the order and adding it to the customer in one re-usable "place"
	/// </summary>
	public class CreateOrderCommand {

		private readonly IOrderRepository _orders;

		public CreateOrderCommand(IOrderRepository orders) {
			this._orders = orders;
		}

		public Order Execute(string description, DateTime date, Customer customer) {
			var order = this._orders.Add(description, date, customer.Id);
			customer.AddOrder(order);
			return order;
		}

	}

}
