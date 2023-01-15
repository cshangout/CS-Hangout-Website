using Server.API.DTOs;
using Server.Infrastructure.Entities;
using Server.Infrastructure.Entities.Users;

namespace Server.Infrastructure.Mappers;

public interface IUserMapper
{
    public User MapRegisterDtoToUser(RegisterDto registerDto);
    public UserDto MapUserEntityToUserDto(User user);
}