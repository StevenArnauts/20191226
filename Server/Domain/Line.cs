using LineEntity = Server.Entities.Line;

namespace Server.Domain {

	public class Line: DomainObject {

		private readonly LineEntity _entity;

		public Line(LineEntity entity)
		{
			this._entity = entity;
		}

		public string Product => this._entity.Product;
		public int Amount => this._entity.Amount;

	}

}
