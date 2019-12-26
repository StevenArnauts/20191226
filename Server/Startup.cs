using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Server.Entities;

namespace Server {

	public class Startup {

		public void ConfigureServices(IServiceCollection services) {

			services.AddMvc();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddDbContext<BookstoreContext>(options => options.UseSqlServer("Server=localhost;Database=bookstore;Trusted_Connection=True;MultipleActiveResultSets=True;"));
			services.AddTransient<Seed>();

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
