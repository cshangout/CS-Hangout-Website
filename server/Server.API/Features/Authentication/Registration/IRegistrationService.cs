using Common.Models.DTOs;

namespace Server.API.Features.Authentication.Registration;

public interface IRegistrationService
{
    public Task<bool> RegistrationOrchestrator(RegisterRequestDto registerRequestDto);
    public Task<bool> RegisterUser(RegisterRequestDto registerRequestDto);
}