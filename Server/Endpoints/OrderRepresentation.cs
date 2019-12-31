using System;

namespace Server.Endpoints {

	public class OrderRepresentation : EntityRepresentation {

		public DateTime Date { get; set; }
		public string Description { get; set; }

	}

}
