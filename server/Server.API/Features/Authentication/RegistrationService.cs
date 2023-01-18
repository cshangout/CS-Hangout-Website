using Common.Models.DTOs;
using Common.Models.Entities;
using Common.Models.Statuses;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Server.Infrastructure.Repositories.Users;

namespace Server.API.Features.Authentication;

public class RegistrationService : IRegistrationService
{
    private readonly ILogger _logger;
    private readonly IUserRepository _userRepository;

    public RegistrationService(
        ILogger logger,
        IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task<RegisterUserStatus> RegistrationOrchestrator(RegisterDto registerDto)
    {
        try
        {
            var result = await _userRepository.AddUser(registerDto);
            return result;
        }
        catch (Exception ex)
        {
            //Todo: Add Global Error Handling
            _logger.Error($"Registration Failed. Ex: {ex}");
            return RegisterUserStatus.Failed;
        }
    }
}