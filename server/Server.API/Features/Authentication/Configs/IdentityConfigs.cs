using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Server.Infrastructure.Data;

namespace Server.API.Features.Authentication.Configs;

public static class IdentityConfigs
{
    public static void SetIdentityConfigs(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
        });

        services.AddTransient<IPasswordValidator<ApplicationUser>, PasswordPolicy>();
    }
}

