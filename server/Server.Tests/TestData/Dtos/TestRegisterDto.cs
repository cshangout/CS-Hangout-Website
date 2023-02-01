using Common.Models.DTOs;

namespace Server.Tests.TestData.Dtos;

public static class TestRegisterDto
{
    public static RegisterRequestDto GetRegisterDto(
        string username = "testUser",
        string email = "testemail@gmail.com",
        string password = "123456789")
    {
        return new RegisterRequestDto()
        {
            UserName = username,
            Email = email,
            Password = password
        };
    }
}