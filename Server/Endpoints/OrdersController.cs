using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Domain;
using Server.Entities;
using Server.Utilities.Extensions;
using Customer = Server.Domain.Customer;
using Order = Server.Domain.Order;

namespace Server.Endpoints {

	[Route("customers/{customerId}/orders")]
	public class OrdersController: ControllerBase {

		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customers;
		private readonly IOrderRepository _orders;
		private readonly BookstoreContext _context;

		public OrdersController(IMapper mapper, ICustomerRepository customers, IOrderRepository orders, BookstoreContext context) {
			this._mapper = mapper;
			this._customers = customers;
			this._orders = orders;
			this._context = context;
		}

		[Route("")]
		[HttpGet]
		public IEnumerable<OrderRepresentation> All() {
			return this._context.Orders.Select(c => this._mapper.Map<OrderRepresentation>(c));
		}

		[HttpPost]
		[Route("")]
		public OrderDetailRepresentation AddOrder(Guid customerId, [FromBody] OrderSpecification spec) {

			Guid orderId;

			using (var scope = new TransactionScope()) {

				// do shit
				Customer customer = this._customers.Get(customerId);
				CreateOrderService command = new CreateOrderService(this._orders);
				Order order = command.Execute(spec.Description, spec.Date, customer);
				foreach (var line in spec.Lines) {
					order.AddLine(line.Amount, line.Product);
				}
				orderId = order.Id;

				// commit
				scope.Complete();
			}

			return this._mapper.Map<OrderDetailRepresentation>(this._context.Orders.Local.Get(o => o.Id == orderId));

		}

	}

}
