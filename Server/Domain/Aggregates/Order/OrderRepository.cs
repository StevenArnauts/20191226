using System;
using System.Linq;
using Server.Entities;
using OrderEntity = Server.Entities.Order;

namespace Server.Domain {

	public class OrderRepository : IOrderRepository {

		private readonly BookstoreContext _context;

		public OrderRepository(BookstoreContext context) {
			this._context = context;
		}

		public Order Get(Guid id) {
			var entity = this._context.Orders.FirstOrDefault(c => c.Id == id);
			return new Order(entity);
		}

		public Order Add(string description, DateTime date, Guid customerId) {
			OrderEntity entity = new OrderEntity {
				Date = date,
				Description = description,
				CustomerId = customerId
			};
			this._context.Orders.Add(entity);
			return new Order(entity);
		}

	}

}
