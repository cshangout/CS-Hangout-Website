using Common.Models.DTOs;
using Common.Models.Entities;

namespace Server.Infrastructure.Mappers;

public interface IUserMapper
{
    public ApplicationUser MapRegisterDtoToUser(RegisterRequestDto registerRequestDto);
    public SignInResponseDto MapUserEntityToUserDto(ApplicationUser applicationUser);
    public LoginRequestDto MapRegisterDtoToLoginDto(RegisterRequestDto registerRequestDto);
}