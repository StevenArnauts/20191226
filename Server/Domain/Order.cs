using System;
using System.Collections.Generic;
using System.Linq;

using OrderEntity = Server.Entities.Order;
using LineEntity = Server.Entities.Line;

namespace Server.Domain {

	public class Order: DomainObject  {

		private readonly OrderEntity _entity;

		public Order(OrderEntity entity) {
			this._entity = entity;
		}

		public DateTime Date => this._entity.Date;
		public string Description => this._entity.Description;

		public Line AddLine(int amount, string product)
		{

			if(this._entity.Lines.Any(l => l.Product == product))
			{
				throw new BusinessException("Product " + product + " is already in order " + this.Id);
			}

			LineEntity entity = new LineEntity { Amount = amount, Product = product };
			this._entity.Lines.Add(entity);
			return new Line(entity);
		}

		public IEnumerable<Line> Lines => this._entity.Lines.Select(l => new Line(l));

	}

}
