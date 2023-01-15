using Serilog;

namespace Server.API.Features.Logging;

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
    public static LoggerConfiguration ConfigureSerilog(this LoggerConfiguration loggerConfig, IConfiguration configs)
    {
        return loggerConfig
            .ReadFrom.Configuration(configs);
    }
}