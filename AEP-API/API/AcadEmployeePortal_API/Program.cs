using ISMS_API.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ISMS_API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args)
                           .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
                           .CaptureStartupErrors(true)
                           .ConfigureAppConfiguration((hostingContext, config) =>
                           {
                               config.AddEnvironmentVariables();
                               if (args != null)
                                   config.AddCommandLine(args);
                           })
                           .ConfigureServices((hostContext, services) =>
                           {
                               services.AddOptions();
                               services.Configure<DaemonConfig>(hostContext.Configuration.GetSection("Daemon"));
                               services.AddSingleton<IHostedService, DaemonService>();
                           })
                           .ConfigureLogging((hostingContext, logging) =>
                           {
                               logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                               logging.AddConsole();
                           });

            await builder.Build().RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000");
    }
}