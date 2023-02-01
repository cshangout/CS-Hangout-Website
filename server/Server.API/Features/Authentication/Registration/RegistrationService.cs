using Common.Models.DTOs;
using Serilog;
using Server.Infrastructure.Mappers;
using Server.Infrastructure.Repositories.Users;

namespace Server.API.Features.Authentication.Registration;

public class RegistrationService : IRegistrationService
{
    private readonly ILogger _logger;
    private readonly IUserRepository _userRepository;
    private readonly IUserMapper _userMapper;

    public RegistrationService(
        ILogger logger,
        IUserRepository userRepository,
        IUserMapper userMapper)
    {
        _logger = logger;
        _userRepository = userRepository;
        _userMapper = userMapper;
    }

    public async Task<bool> RegistrationOrchestrator(RegisterRequestDto registerRequestDto)
    {

        var registerResult = await RegisterUser(registerRequestDto);

        return registerResult;
    }

    public async Task<bool> RegisterUser(RegisterRequestDto registerRequestDto)
    {
        try
        {
            var result = await _userRepository.AddUser(registerRequestDto);
            return result.Succeeded;
        }
        catch (Exception ex)
        {
            //Todo: Add Global Error Handling
            _logger.Error($"Registration Failed. Ex: {ex}");
            return false;
        }
    }
}