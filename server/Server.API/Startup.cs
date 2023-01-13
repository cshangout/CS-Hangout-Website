using System.Timers;
using Common.Logging;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Serilog;
using Serilog.Events;
using Server.API.Controllers;
using Server.API.Controllers.Interfaces;
using Server.Infrastructure.Data;
using Server.Infrastructure.Repositories;

namespace Server.API;

/// <summary>
/// Startup class for the dependency injection and settings
/// </summary>
public class Startup
{
    private readonly IConfiguration Configuration;
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Configure Services for Microsoft's Dependency Injection
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        
        RegisterEnvironmentSettings(services);
        RegisterDIServices(services);

        //Setup CORS Policy
        string[] origins = Configuration["CORSOrigin"].Split(",");
        var corsBuilder = new CorsPolicyBuilder()
             .AllowAnyHeader()
             .AllowAnyMethod()
             .WithOrigins(origins)
             .AllowCredentials();
                 services.AddCors(options => { options.AddPolicy("SiteCorsPolicy", corsBuilder.Build()); });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment() || env.EnvironmentName.Equals("Local"))
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // FIXME: Redesign logging middleware for custom logging
        app.UseSerilogRequestLogging();
        app.UseHttpsRedirection();

        app.UseCors();
        app.UseRouting();
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    public void RegisterDIServices(IServiceCollection services)
    {
        //var _connString = $"Data Source={server};Initial Catalog={db};User ID={user};Password={pass};";
        //Register DB Context
        // services.AddEntityFrameworkMySQL().AddDbContext<DataContext>(options =>
        // {
        //     options.UseMySQL(_connString);
        // });
        //
        services.AddScoped<IAuthController, AuthController>();
        
        //TODO: Review Singleton requirements for context
        //services.AddSingleton<IDataContext, DataContext>();
        //services.AddSingleton<IUserRepository, UserRepository>();
    }

    /// <summary>
    /// Register Services that use environment specific settings
    /// </summary>
    /// <param name="services">An IServiceCollection</param>
    private void RegisterEnvironmentSettings(IServiceCollection services)
    {
        var configs = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
            .AddEnvironmentVariables()
            .Build();
        
        services.RegisterSerilog(configs);
    }
}