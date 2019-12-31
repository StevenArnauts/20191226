namespace Server.Endpoints {

	public class OrderDetailRepresentation : OrderRepresentation {

		public LineRepresentation[] Lines { get; set; }

	}

}
