using Common.Models.DTOs;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Server.Infrastructure.Authentication.Persistence;
using Server.Infrastructure.Repositories.Users;

namespace Server.API.Features.Authentication.SignOn;

public class SignOnService : ISignOnService
{
    private readonly ILogger _logger;
    private readonly IUserRepository _userRepository;
    private readonly IPersistenceService _persistenceService;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public SignOnService(
        ILogger logger,
        IUserRepository userRepository,
        IPersistenceService persistenceService,
        SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger.ForContext<SignOnService>();
        _userRepository = userRepository;
        _persistenceService = persistenceService;
        _signInManager = signInManager;

    }

    public async Task<SignInResponseDto> SignOnOrchestrator(LoginRequestDto loginRequestDto)
    {
        ApplicationUser user;

        if (loginRequestDto.Username != null)
        {
            _logger.Debug("Logging in by username.");
            user = await _userRepository.GetUserByUsername(loginRequestDto);
        }
        else
        {
            _logger.Debug("Logging in by email.");
            user = await _userRepository.GetUserByEmail(loginRequestDto);
        }

        if (user != null)
        {
            var signOnResult = await SignInUser(user, loginRequestDto.Password);

            if (signOnResult.Succeeded)
            {
                //TODO: Review better persistence with user store
                var token = _persistenceService.GenerateUserToken();
                return new SignInResponseDto()
                {
                    SuccessfulSignOn = true,
                    BearerToken = token
                };
            }
        }
        
        return new SignInResponseDto()
        {
            SuccessfulSignOn = false
        };
    }

// TODO: Better utilization of Identity by storing signin
public async Task<SignInResult> SignInUser(ApplicationUser user, string password)
    {
        await _signInManager.SignOutAsync();
        
        // TODO: Review lockout attempts
        var result = await _signInManager.PasswordSignInAsync(
            user, 
            password, 
            false,
            false);

        return result;
    }
}