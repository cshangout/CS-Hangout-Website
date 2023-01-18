using Common.Models.DTOs;

namespace Server.Tests.TestData.Dtos;

public static class TestUserDto
{
    public static UserDto GetTestUserDto(string username = "testUser")
    {
        return new UserDto()
        {
            Username = username
        };
    } 
}