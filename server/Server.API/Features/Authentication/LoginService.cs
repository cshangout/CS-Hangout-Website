using Common.Models.DTOs;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Server.Infrastructure.Repositories.Users;

namespace Server.API.Features.Authentication;

public class LoginService : ILoginService
{
    private readonly ILogger _logger;
    private readonly IUserRepository _userRepository;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LoginService(
        ILogger logger,
        IUserRepository userRepository,
        SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger.ForContext<LoginService>();
        _userRepository = userRepository;
        _signInManager = signInManager;
    }

    public async Task<SignInResult> SignOnOrchestrator(LoginDto loginDto)
    {
        ApplicationUser user;
        
        if (loginDto.Username == null)
        {
            _logger.Debug("Logging in by username.");
            user = await _userRepository.GetUserByEmail(loginDto);
        }
        else
        {
            _logger.Debug("Logging in by email.");
            user = await _userRepository.GetUserByUsername(loginDto);
        }

        var signOnResult = await SignInUser(user, loginDto.Password);

        return signOnResult;

    }

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