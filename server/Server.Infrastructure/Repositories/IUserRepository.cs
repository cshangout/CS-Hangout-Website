using Server.API.DTOs;
using Server.Infrastructure.Entities;

namespace Server.Infrastructure.Repositories;

public interface IUserRepository
{
    public Task<User> GetUser(LoginDto loginDto);
}