using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Server.API.Features.Authentication;

public class PasswordPolicy : PasswordValidator<ApplicationUser>
{
    // TODO: Prevent SQL Injection
    public override async Task<IdentityResult> ValidateAsync(
        UserManager<ApplicationUser> userManager,
        ApplicationUser user,
        string password)
    {
        IdentityResult result = await base.ValidateAsync(userManager, user, password);
        List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

        if (password.ToLower().Contains(user.UserName.ToLower()))
        {
            Log.Logger.ForContext<PasswordPolicy>().Warning("Password contains username");
            errors.Add(new IdentityError()
            {
                Description = "Password cannot contain username"
            });
        }

        return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
    }
}