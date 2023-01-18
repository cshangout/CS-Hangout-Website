using Common.Models.DTOs;
using Common.Models.Entities;
using Common.Models.Statuses;

namespace Server.Infrastructure.Repositories.Users;

public interface IUserRepository
{
    public Task<ApplicationUser?> GetUserByUsername(LoginDto loginDto);
    public Task<ApplicationUser?> GetUserByEmail(LoginDto loginDto);
    public Task<RegisterUserStatus> AddUser(RegisterDto registerDto);
}