using AutoMapper;

namespace Server.Endpoints {

	public class EndpointsProfile : Profile {

		public EndpointsProfile() {

			this.CreateMap<Entities.Customer, CustomerRepresentation>();
			this.CreateMap<Entities.Customer, CustomerRepresentation>();
			this.CreateMap<Entities.Customer, CustomerDetailRepresentation>();
			this.CreateMap<Entities.Order, OrderRepresentation>();
			this.CreateMap<Entities.Order, OrderDetailRepresentation>();
			this.CreateMap<Entities.Line, LineRepresentation>();

		}

	}

}
