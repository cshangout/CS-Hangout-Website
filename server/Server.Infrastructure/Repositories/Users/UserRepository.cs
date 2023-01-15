using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Server.API.DTOs;
using Server.Infrastructure.Data;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Entities.Users;
using Server.Infrastructure.Mappers;

namespace Server.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository
{
    
    private readonly ILogger _logger;
    private readonly IDataContext _dataContext;
    private readonly IUserMapper _userMapper;

    public UserRepository(ILogger logger, IDataContext dataContext, IUserMapper userMapper)
    {
        _logger = logger.ForContext<UserRepository>();
        _dataContext = dataContext;
        _userMapper = userMapper;
    }
    
    public async Task<UserDto> AddUser(RegisterDto registerDto)
    {
        _logger.Debug("AddUser called");
        try
        {
            var user = _userMapper.MapRegisterDtoToUser(registerDto);
            var registeredUserEntity = await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChanges();
            return _userMapper.MapUserEntityToUserDto(registeredUserEntity.Entity);
        }
        catch (Exception ex)
        {
            _logger.Debug($"AddUser() error:\n{ex}");
            return null;
        }

    }
    
    public async Task<User?> GetUser(LoginDto loginDto)
    {
        try
        {
            return await _dataContext.Users.FirstOrDefaultAsync(user =>
                user.UserName == loginDto.Username && user.Password == loginDto.Password);
        }
        catch (Exception ex)
        {
            _logger.Error("User not found");
            return null;
        }
    }

}