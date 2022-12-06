using Autofac.Extensions.DependencyInjection;

namespace Server.API;

/// <summary>
/// Main method of Program and builds host
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>();
            })
            .Build();

        host.Run();
    }
}
