using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Common.Logging;

/// <summary>
/// Registration of Serilog instance
/// </summary>
public static class SerilogConfiguration
{
    /// <summary>
    /// Register Serilog Instance
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configs"></param>
    public static void RegisterSerilog(this IServiceCollection services, IConfiguration configs)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configs)
            .CreateLogger();

        services.AddSingleton(Log.Logger);
    }
}