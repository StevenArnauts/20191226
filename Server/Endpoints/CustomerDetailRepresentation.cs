namespace Server.Endpoints {

	public class CustomerDetailRepresentation : CustomerRepresentation {

		public OrderRepresentation[] Orders { get; set; }

	}

}
