using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Server.Domain;
using Server.Entities;
using Server.Entities.UnitOfWork;

namespace Server {

	public class Startup {

		public void ConfigureServices(IServiceCollection services) {

			services.AddMvc(options => {
				options.Filters.Add<UnitOfWorkFilter<BookstoreContext>>();
			});
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			services.AddDbContext<BookstoreContext>(options => options.UseSqlServer("Server=localhost;Database=bookstore;Trusted_Connection=True;MultipleActiveResultSets=True;"));
			services.AddTransient<Seed>();
			services.AddAutoMapper(typeof(Startup));

		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			using (var scope = app.ApplicationServices.CreateScope()){
				var seed = scope.ServiceProvider.GetRequiredService<Seed>();
				seed.Run();
			}

			app.UseMvc();
		}

	}

}
