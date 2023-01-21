using Common.Interfaces;
using Common.Models.DTOs;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Server.Infrastructure.Mappers;

namespace Server.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository
{
    
    private readonly ILogger _logger;
    private readonly IDataContext _dataContext;
    private readonly IUserMapper _userMapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(
        ILogger logger,
        UserManager<ApplicationUser> userManager,
        IUserMapper userMapper)
    {
        _logger = logger.ForContext<UserRepository>();
        _userManager = userManager;
        _userMapper = userMapper;
    }
    
    /// <summary>
    /// Adds user to the Identity User table
    /// </summary>
    /// <param name="registerRequestDto"></param>
    /// <returns></returns>
    public async Task<IdentityResult> AddUser(RegisterRequestDto registerRequestDto)
    {
        _logger.Debug("AddUser called");
        try
        {
            var user = _userMapper.MapRegisterDtoToUser(registerRequestDto);
            var registeredUserResult = await _userManager.CreateAsync(user, registerRequestDto.Password);

            return registeredUserResult;
        }
        catch (Exception ex)
        {
            _logger.Debug($"AddUser() error:\n{ex}");
            return IdentityResult.Failed();
        }

    }
    
    /// <summary>
    /// Get User from Identity User table by username
    /// </summary>
    /// <param name="loginRequestDto"></param>
    /// <returns>ApplicationUser</returns>
    public async Task<ApplicationUser> GetUserByUsername(LoginRequestDto loginRequestDto)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(loginRequestDto.Username);
            return user;
        }
        catch (Exception ex)
        {
            _logger.Error($"Unable to locate user by username. Error: {ex}");
            return null;
        }
    }
    
    /// <summary>
    /// Get User from Identity User table by email
    /// </summary>
    /// <param name="loginRequestDto"></param>
    /// <returns>ApplicationUser</returns>
    public async Task<ApplicationUser?> GetUserByEmail(LoginRequestDto loginRequestDto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            return user;
        }
        catch (Exception ex)
        {
            _logger.Error($"Unable to locate user by email. Error: {ex}");
            return null;
        }
    }

}