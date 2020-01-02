using System;

namespace Server.Domain {

	/// <summary>
	/// I only wanted to encapsulate the two lines creating the order and adding it to the customer in one re-usable "place"
	/// </summary>
	public class CreateOrderService {

		private readonly IOrderRepository _orders;

		public CreateOrderService(IOrderRepository orders) {
			this._orders = orders;
		}

		public Order Execute(string description, DateTime date, Customer customer) {
			var order = this._orders.Add(description, date, customer.Id);
			customer.AddOrder(order);
			return order;
		}

	}

}
