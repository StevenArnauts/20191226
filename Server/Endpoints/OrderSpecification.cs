using System;

namespace Server.Endpoints {

	public class OrderSpecification {

		public OrderSpecification() {
			this.Lines = new LineSpecification[] { };
		}

		public DateTime Date { get; set; }
		public string Description { get; set; }
		public LineSpecification[] Lines { get; set; }

	}

}
