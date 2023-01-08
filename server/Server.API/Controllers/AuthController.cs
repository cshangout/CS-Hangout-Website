using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server.API.Controllers.Interfaces;
using Server.API.DTOs;

namespace Server.API.Controllers;

/// <summary>
/// Authentication Controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController, IAuthController
{
    private readonly ILogger _logger;

    /// <summary>
    /// Authentication Constructor
    /// </summary>
    public AuthController(ILogger logger)
    {
        _logger = logger.ForContext<AuthController>();
    }
    
    /// <summary>
    /// Authenticate User method and return response based on validation
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpPost]
    public async Task<ActionResult<UserDto>> AuthenticateUser(LoginDto loginDto)
    {
        // Create logic for Authenticating a user
        _logger.Debug("Authentication Started");
        return Ok();
    }
}