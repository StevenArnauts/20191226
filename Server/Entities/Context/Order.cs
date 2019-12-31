using System;
using System.Collections.Generic;

namespace Server.Entities {

	public class Order: Entity  {

		public Order() {
			this.Lines = new List<Line>();
		}

		public DateTime Date { get; set; }
		public string Description { get; set; }
		public DateTime? Paid { get; set; }
		public DateTime? Sent { get; set; }

		public Guid CustomerId { get; set; }
		public Customer Customer { get; set; }

		public ICollection<Line> Lines { get; set; }

	}

}
