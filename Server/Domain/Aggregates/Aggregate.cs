using System;
using Server.Entities;

namespace Server.Domain {

	public abstract class Aggregate<TRootEntity> where TRootEntity : Entity {

		private readonly TRootEntity _root;

		public Aggregate(TRootEntity root) {
			this._root = root;
		}

		internal TRootEntity Root => this._root;
		public Guid Id => this._root.Id;

	}

}
