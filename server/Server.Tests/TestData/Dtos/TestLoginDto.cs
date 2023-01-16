using Server.API.DTOs;

namespace Server.Tests.TestData.Dtos;

public static class TestLoginDto
{
    public static LoginDto GetLoginDto(
        string? username = "testUser", 
        string? email = "test@gmail.com", 
        string password = "123456789")
    {
        return new LoginDto()
        {
            Username = username,
            Email = email,
            Password = password
        };
    }
}