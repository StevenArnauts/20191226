using System.Collections.Generic;
using System.Linq;

namespace Server.Domain {

	public class Customer: DomainObject {
		
		private Entities.Customer _entity;

		public Customer(Entities.Customer entity) {
			this._entity = entity;
		}

		public string Name => this._entity.Name;
		public IEnumerable<Order> Orders => this._entity.Orders.Select(o => new Order(o));

	}

}
