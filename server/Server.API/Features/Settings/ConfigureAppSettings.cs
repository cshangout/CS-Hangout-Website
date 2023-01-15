namespace Server.API.Features.Settings;

public static class ConfigureAppSettings
{
    public static IHostBuilder ConfigureSettings(this IHostBuilder host)
    {
        host.ConfigureAppConfiguration((context, builder) =>
        {
            builder
                .AddJsonFile("Secrets.json", optional: true)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json");
        });

        return host;
    }
}