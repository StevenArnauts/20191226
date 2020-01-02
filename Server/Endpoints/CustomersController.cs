using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Domain;
using Server.Entities;
using Server.Utilities.Extensions;

namespace Server.Endpoints {

	[Route("customers")]
	public class CustomersController: ControllerBase {

		private readonly IMapper _mapper;
		private readonly ICustomerRepository _customers;
		private readonly BookstoreContext _context;

		public CustomersController(IMapper mapper, ICustomerRepository repository, BookstoreContext context) {
			this._mapper = mapper;
			this._customers = repository;
			this._context = context;
		}

		[Route("")]
		[HttpGet]
		public IEnumerable<CustomerRepresentation> All() {
			return this._context.Customers.Select(c => this._mapper.Map<CustomerRepresentation>(c));
		}

		[HttpPost]
		[Route("")]
		public CustomerRepresentation Add([FromBody] CustomerSpecification spec) {
			var customer = this._customers.Add(spec.Name);
			// ok now it's OPTIONAL to return the representation at this point, but if you do it's a query
			return this._mapper.Map<CustomerRepresentation>(this._context.Customers.Local.Get(c => c.Id == customer.Id));	
		}

		[Route("{id:guid}")]
		[HttpGet]
		public CustomerDetailRepresentation Get(Guid id) {
			var entity = this._context.Customers.Include(c => c.Orders).ThenInclude(o => o.Lines).Get(c => c.Id == id);
			return this._mapper.Map<CustomerDetailRepresentation>(entity);
		}

	}

}
