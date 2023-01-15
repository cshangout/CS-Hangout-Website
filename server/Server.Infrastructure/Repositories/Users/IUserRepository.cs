﻿using Server.API.DTOs;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Entities.Users;

namespace Server.Infrastructure.Repositories.Users;

public interface IUserRepository
{
    public Task<User> GetUser(LoginDto loginDto);
    public Task<UserDto> AddUser(RegisterDto registerDto);
}