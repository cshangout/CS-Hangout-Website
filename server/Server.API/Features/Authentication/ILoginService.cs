using Common.Models.DTOs;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Server.API.Features.Authentication;

public interface ILoginService
{
    public Task<SignInResult> SignOnOrchestrator(LoginDto loginDto);
    public Task<SignInResult> SignInUser(ApplicationUser user, string password);
}