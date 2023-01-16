using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server.API.Controllers.Interfaces;
using Server.API.DTOs;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Repositories;
using Server.Infrastructure.Repositories.Users;

namespace Server.API.Controllers;

/// <summary>
/// Authentication Controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController, IAuthController
{
    private readonly ILogger _logger;
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Authentication Constructor
    /// </summary>
    public AuthController(ILogger logger, IUserRepository userRepository)
    {
        _logger = logger.ForContext<AuthController>();
        _userRepository = userRepository;
    }
    
    /// <summary>
    /// Authenticate User method and return response based on validation
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpPost]
    public async Task<ActionResult<UserDto>> AuthenticateUser([FromBody] LoginDto loginDto)
    {
        // Create logic for Authenticating a user
        _logger.Debug("Authentication Started");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var user = await _userRepository.GetUser(loginDto);
            return Ok(new UserDto()
            {
                Username = user.UserName
            });
        }
        catch (Exception ex)
        {
            _logger.Error("User not able to be authenticated");
            return Unauthorized("User not authorized.");
        }
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<UserDto>> RegisterUser([FromBody] RegisterDto registerDto)
    {
        _logger.Debug($"Registering user {registerDto.UserName}");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var user = await _userRepository.AddUser(registerDto);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                _logger.Debug("RegisterUser request failed");
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            _logger.Error($"Error occurred during RegisterUser:\n{ex}");
            return BadRequest();
        }
    }
}