using Common.Models.DTOs;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Server.API.Features.Authentication.SignOn;

public interface ISignOnService
{
    public Task<SignInResponseDto> SignOnOrchestrator(LoginRequestDto loginRequestDto);
    public Task<SignInResult> SignInUser(ApplicationUser user, string password);
}