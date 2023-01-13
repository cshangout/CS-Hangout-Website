using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server.API.Controllers.Interfaces;
using Server.API.DTOs;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Repositories;

namespace Server.API.Controllers;

/// <summary>
/// Authentication Controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController, IAuthController
{
    private readonly ILogger _logger;
    //private readonly IUserRepository _userRepository;

    /// <summary>
    /// Authentication Constructor
    /// </summary>
    public AuthController(ILogger logger)
    {
        _logger = logger.ForContext<AuthController>();
        //_userRepository = userRepository;
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
        
        return Ok(new UserDto());
    }
}