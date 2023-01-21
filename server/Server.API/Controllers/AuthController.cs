using Common.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server.API.Controllers.Interfaces;
using Server.API.Features.Authentication.Registration;
using Server.API.Features.Authentication.SignOn;
using Server.Infrastructure.Mappers;

namespace Server.API.Controllers;

/// <summary>
/// Authentication Controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController, IAuthController
{
    private readonly ILogger _logger;
    private readonly ISignOnService _signOnService;
    private readonly IRegistrationService _registrationService;
    private readonly IUserMapper _userMapper;

    /// <summary>
    /// Authentication Constructor
    /// </summary>
    public AuthController(ILogger logger, 
        ISignOnService signOnService,
        IRegistrationService registrationService,
        IUserMapper userMapper)
    {
        _logger = logger.ForContext<AuthController>();
        _signOnService = signOnService;
        _registrationService = registrationService;
        _userMapper = userMapper;
    }

    /// <summary>
    /// Authenticate User method and return response based on validation
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<SignInResponseDto>> SignOnUser([FromBody] LoginRequestDto loginRequestDto)
    {
        // Create logic for Authenticating a user
        _logger.Debug("Sign On Started");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _logger.Debug("Sending login data to Sign On Service");
        var result = await _signOnService.SignOnOrchestrator(loginRequestDto);

        if (!result.SuccessfulSignOn)
        {
            return BadRequest(new ErrorResponseDto()
            {
                Status = "Failed Login",
                Message = "Sign on was unsuccessful due to invalid credentials."
            });
        }

        return Ok(result);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<SignInResponseDto>> RegisterUser([FromBody] RegisterRequestDto registerRequestDto)
    {
        _logger.Debug($"Registering user {registerRequestDto.UserName}");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _registrationService.RegistrationOrchestrator(registerRequestDto);
            
        // Registration Failed
        if (!result)
        {
            return StatusCode(500, new ErrorResponseDto()
            {
                Status = "Failed Registration",
                Message = "Registration failed.  This may be due to an internal server error."
            });
        }

        _logger.Debug("User registered. Attempting to login...");
        // Attempt to sign in and return JWT
        var signInRequest =
            await _signOnService.SignOnOrchestrator(_userMapper.MapRegisterDtoToLoginDto(registerRequestDto));

        if (!signInRequest.SuccessfulSignOn)
        {
            return BadRequest(new ErrorResponseDto()
            {
                Status = "Failed Login",
                Message = "Sign on was unsuccessful due to invalid credentials."
            });
        }
        
        return Ok(signInRequest);
    }
}
