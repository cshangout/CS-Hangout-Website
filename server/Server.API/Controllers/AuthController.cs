using Common.Models.DTOs;
using Common.Models.Entities;
using Common.Models.Statuses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Server.API.Controllers.Interfaces;
using Server.API.Features.Authentication;
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
    private readonly ILoginService _loginService;
    private readonly IRegistrationService _registrationService;

    /// <summary>
    /// Authentication Constructor
    /// </summary>
    public AuthController(ILogger logger, 
        ILoginService loginService,
        IRegistrationService registrationService)
    {
        _logger = logger.ForContext<AuthController>();
        _loginService = loginService;
        _registrationService = registrationService;
    }

    /// <summary>
    /// Authenticate User method and return response based on validation
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<UserDto>> AuthenticateUser([FromBody] LoginDto loginDto)
    {
        // Create logic for Authenticating a user
        _logger.Debug("Authentication Started");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _logger.Debug("Sending login data to PersistenceService");
        var result = await _loginService.SignOnOrchestrator(loginDto);

        if (result.Succeeded) return Ok("logged in");

        return BadRequest("Invalid authentication information provided.");
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterDto registerDto)
    {
        _logger.Debug($"Registering user {registerDto.UserName}");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _registrationService.RegistrationOrchestrator(registerDto);
            
        // Return token
        if (result == RegisterUserStatus.Success)
        {
            return Ok("Registration worked");
        }
        else
        {
            return StatusCode(500);
        }
    }
}
