using Common.Models.DTOs;
using Common.Models.Statuses;

namespace Server.API.Features.Authentication;

public interface IRegistrationService
{
    public Task<RegisterUserStatus> RegistrationOrchestrator(RegisterDto registerDto);
}