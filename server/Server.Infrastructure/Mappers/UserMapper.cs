using Common.Models.DTOs;
using Common.Models.Entities;

namespace Server.Infrastructure.Mappers;

public class UserMapper : IUserMapper
{
    public ApplicationUser MapRegisterDtoToUser(RegisterDto registerDto)
    {
        return new ApplicationUser()
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            UpdatedDate = null
        };
    }

    public UserDto MapUserEntityToUserDto(ApplicationUser applicationUser)
    {
        return new UserDto()
        {
            Username = applicationUser.UserName
        };
    }
}