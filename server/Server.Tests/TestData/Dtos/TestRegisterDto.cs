using Server.API.DTOs;

namespace Server.Tests.TestData.Dtos;

public static class TestRegisterDto
{
    public static RegisterDto GetRegisterDto(
        string username = "testUser",
        string email = "testemail@gmail.com",
        string password = "123456789")
    {
        return new RegisterDto()
        {
            UserName = username,
            Email = email,
            Password = password
        };
    }
}