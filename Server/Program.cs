using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using NLog.Web;
using Microsoft.Extensions.Logging;

namespace Server {

	public class Program {

		public static void Main(string[] args) {
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
			var host = WebHost.CreateDefaultBuilder(args);
			host.UseStartup<Startup>();
			host.ConfigureLogging(logging => {
				 logging.ClearProviders();
				 logging.SetMinimumLevel(LogLevel.Trace);
			 });
			host.UseNLog();
			return host;
		}
		
	}

}
