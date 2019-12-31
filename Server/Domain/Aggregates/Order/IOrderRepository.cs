using System;

namespace Server.Domain {

	public interface IOrderRepository {

		Order Get(Guid id);
		Order Add(string description, DateTime date, Guid customerId);

	}

}