using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Server.Infrastructure.Data;

public static class Persistence
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configs)
    {
        var connectionString = configs["MySqlConnectionString"];
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        
        services.AddDbContext<DataContext>(options => 
            options.UseMySql(connectionString, serverVersion));

        services.AddScoped<IDataContext, DataContext>();
    }
}