using System;

namespace Server.Domain {

	public abstract class DomainObject {

		public DomainObject() {
			this.Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }

	}

}
