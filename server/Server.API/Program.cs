using Microsoft.EntityFrameworkCore;
using Serilog;
using Server.API.Controllers;
using Server.API.Controllers.Interfaces;
using Server.API.Features.Authentication;
using Server.API.Features.Settings;
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
builder.Services.RegisterJwtPolicy(builder.Configuration);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration["MySqlConnectionString"]);
});

// Register Services
builder.Services.AddTransient<IUserMapper, UserMapper>();
builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthController, AuthController>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
