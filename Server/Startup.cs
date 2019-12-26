﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Server {

	public class Startup {

		public void ConfigureServices(IServiceCollection services) {

			services.AddMvc();
			services.AddSingleton<ICustomerRepository, CustomerRepository>();

		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}

	}

}