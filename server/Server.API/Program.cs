using Autofac.Extensions.DependencyInjection;
using Serilog;

namespace Server.API;

/// <summary>
/// Main method of Program and builds host
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder
                    .UseStartup<Startup>();
                
            })
            .UseSerilog();
}
