using Common.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers.Interfaces;

public interface IAuthController
{
    Task<ActionResult<UserDto>> AuthenticateUser(LoginDto loginDto);
    public Task<ActionResult> RegisterUser(RegisterDto registerDto);
}