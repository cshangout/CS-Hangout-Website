using Microsoft.AspNetCore.Mvc;
using Server.API.DTOs;

namespace Server.API.Controllers.Interfaces;

public interface IAuthController
{
    Task<ActionResult<UserDto>> AuthenticateUser(LoginDto loginDto);
}