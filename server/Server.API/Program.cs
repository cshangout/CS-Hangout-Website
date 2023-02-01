using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;
using Server.API.Controllers;
using Server.API.Controllers.Interfaces;
using Server.API.Features.Authentication;
using Server.API.Features.Authentication.Configs;
using Server.API.Features.Authentication.Registration;
using Server.API.Features.Authentication.SignOn;
using Server.API.Features.Settings;
using Server.Infrastructure.Authentication.Persistence;
using Server.Infrastructure.Data;
using Server.Infrastructure.Mappers;
using Server.Infrastructure.Repositories.Users;

var builder = WebApplication.CreateBuilder(args);

// Add Configurations
builder.Configuration.AddEnvironmentVariables();
builder.Host.ConfigureSettings();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

// Register CORS
string[] origins = builder.Configuration["CORSOrigin"].Split(",");
builder.Services.AddCors(options =>
{ 
    options.AddPolicy("CorsPolicy", policyBuilder =>
    { 
        policyBuilder
            .WithOrigins(origins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// Register Services
builder.Services.AddOptions();

// Setup authentication and Identity management
builder.Services.AddPersistence(builder.Configuration);
builder.Services.SetIdentityConfigs();
builder.Services.RegisterJwtPolicy(builder.Configuration);

// Register Services
builder.Services.AddTransient<IUserMapper, UserMapper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISignOnService, SignOnService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddTransient<IPersistenceService, PersistenceService>();
builder.Services.AddScoped<IAuthController, AuthController>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CS_Hangout_API",
        Version = "v1"
    });
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Auth Header"
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }});
});

// Build Web App
var app = builder.Build();
if (builder.Environment.IsDevelopment() || builder.Configuration["ASPNETCORE_ENVIRONMENT"] == "Local")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
