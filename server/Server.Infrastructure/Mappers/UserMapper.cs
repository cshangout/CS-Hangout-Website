using Common.Models.DTOs;
using Common.Models.Entities;

namespace Server.Infrastructure.Mappers;

public class UserMapper : IUserMapper
{
    public ApplicationUser MapRegisterDtoToUser(RegisterRequestDto registerRequestDto)
    {
        return new ApplicationUser()
        {
            UserName = registerRequestDto.UserName,
            Email = registerRequestDto.Email,
            UpdatedDate = null
        };
    }

    // TODO: Fix mapper
    public SignInResponseDto MapUserEntityToUserDto(ApplicationUser applicationUser)
    {
        return new SignInResponseDto()
        {
            //Username = applicationUser.UserName
        };
    }

    public LoginRequestDto MapRegisterDtoToLoginDto(RegisterRequestDto registerRequestDto)
    {
        return new LoginRequestDto()
        {
            Username = registerRequestDto.UserName,
            Email = registerRequestDto.Email,
            Password = registerRequestDto.Password
        };
    }
}