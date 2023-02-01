using Common.Models.DTOs;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Server.Infrastructure.Repositories.Users;

public interface IUserRepository
{
    public Task<ApplicationUser?> GetUserByUsername(LoginRequestDto loginRequestDto);
    public Task<ApplicationUser?> GetUserByEmail(LoginRequestDto loginRequestDto);
    public Task<IdentityResult> AddUser(RegisterRequestDto registerRequestDto);
}