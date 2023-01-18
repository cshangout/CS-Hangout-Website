using System.Collections;
using Common.Interfaces;
using Common.Models.DTOs;
using Common.Models.Entities;
using Common.Models.Statuses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Server.Infrastructure.Data;
using Server.Infrastructure.Mappers;

namespace Server.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository
{
    
    private readonly ILogger _logger;
    private readonly IDataContext _dataContext;
    private readonly IUserMapper _userMapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserRepository(
        ILogger logger, 
        IDataContext dataContext, 
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IUserMapper userMapper)
    {
        _logger = logger.ForContext<UserRepository>();
        _dataContext = dataContext;
        _userManager = userManager;
        _signInManager = signInManager;
        _userMapper = userMapper;
    }
    
    /// <summary>
    /// Adds user to the Identity User table
    /// </summary>
    /// <param name="registerDto"></param>
    /// <returns></returns>
    public async Task<RegisterUserStatus> AddUser(RegisterDto registerDto)
    {
        _logger.Debug("AddUser called");
        try
        {
            var user = _userMapper.MapRegisterDtoToUser(registerDto);
            var registeredUserResult = await _userManager.CreateAsync(user, registerDto.Password);

            return registeredUserResult.Succeeded ? RegisterUserStatus.Success : RegisterUserStatus.Failed;
        }
        catch (Exception ex)
        {
            _logger.Debug($"AddUser() error:\n{ex}");
            return RegisterUserStatus.Failed;
        }

    }
    
    /// <summary>
    /// Get User from Identity User table by username
    /// </summary>
    /// <param name="loginDto"></param>
    /// <returns>ApplicationUser</returns>
    public async Task<ApplicationUser> GetUserByUsername(LoginDto loginDto)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
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
    /// <param name="loginDto"></param>
    /// <returns>ApplicationUser</returns>
    public async Task<ApplicationUser?> GetUserByEmail(LoginDto loginDto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            return user;
        }
        catch (Exception ex)
        {
            _logger.Error($"Unable to locate user by email. Error: {ex}");
            return null;
        }
    }

}