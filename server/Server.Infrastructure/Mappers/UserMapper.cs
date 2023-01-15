using Server.API.DTOs;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Entities.Users;

namespace Server.Infrastructure.Mappers;

public class UserMapper : IUserMapper
{
    public User MapRegisterDtoToUser(RegisterDto registerDto)
    {
        return new User()
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            Password = registerDto.Password,
            UpdatedDate = null
        };
    }

    public UserDto MapUserEntityToUserDto(User user)
    {
        return new UserDto()
        {
            Username = user.UserName
        };
    }
}