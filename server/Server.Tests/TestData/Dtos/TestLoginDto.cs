using Server.API.DTOs;

namespace Server.Tests.TestData.Dtos;

public static class TestLoginDto
{
    public static LoginDto GetLoginDto(string username = "testUser", string password = "123456789")
    {
        return new LoginDto()
        {
            Username = username,
            Password = password
        };
    }
}