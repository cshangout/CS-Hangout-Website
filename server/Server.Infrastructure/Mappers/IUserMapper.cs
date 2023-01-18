using Common.Models.DTOs;
using Common.Models.Entities;

namespace Server.Infrastructure.Mappers;

public interface IUserMapper
{
    public ApplicationUser MapRegisterDtoToUser(RegisterDto registerDto);
    public UserDto MapUserEntityToUserDto(ApplicationUser applicationUser);
}