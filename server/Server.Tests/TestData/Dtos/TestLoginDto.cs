using Common.Models.DTOs;

namespace Server.Tests.TestData.Dtos;

public static class TestLoginDto
{
    public static LoginRequestDto GetLoginDto(
        string? username = "testUser", 
        string? email = "test@gmail.com", 
        string password = "123456789")
    {
        return new LoginRequestDto()
        {
            Username = username,
            Email = email,
            Password = password
        };
    }
}