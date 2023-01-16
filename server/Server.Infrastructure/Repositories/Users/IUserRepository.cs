using Server.API.DTOs;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Entities.Users;

namespace Server.Infrastructure.Repositories.Users;

public interface IUserRepository
{
    public Task<User?> GetUserByUsername(LoginDto loginDto);
    public Task<User?> GetUserByEmail(LoginDto loginDto);
    public Task<UserDto> AddUser(RegisterDto registerDto);
}