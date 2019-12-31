using System.Linq;
using Server.Utilities.Exceptions;
using OrderEntity = Server.Entities.Order;
using LineEntity = Server.Entities.Line;

namespace Server.Domain {

	public class Order: Aggregate<OrderEntity>  {

		public Order(OrderEntity entity): base(entity) { }

		// don't do queries
		// public string Description => this._entity.Description;
		// public DateTime Date => this._entity.Date;
		// public IEnumerable<Line> Lines => this._entity.Lines.Select(l => new Line(l));

		public void AddLine(int amount, string product)	{
			Throw<BusinessException>.When(this.Root.Lines.Any(l => l.Product == product), "Product " + product + " is already in order " + this.Id);
			LineEntity entity = new LineEntity { Amount = amount, Product = product };
			this.Root.Lines.Add(entity);
			// return new Line(entity);
		}

	}

}
