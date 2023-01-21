using Common.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers.Interfaces;

public interface IAuthController
{
    Task<ActionResult<SignInResponseDto>> SignOnUser(LoginRequestDto loginRequestDto);
    public Task<ActionResult<SignInResponseDto>> RegisterUser(RegisterRequestDto registerRequestDto);
}