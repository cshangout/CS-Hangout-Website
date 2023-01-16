using Server.Infrastructure.Entities.Users;

namespace Server.Tests.TestData.Entities;

public static class TestUser
{
    public static User GetTestUser(
        int id = 1,
        string username = "testUser",
        string email = "test@gmail.com",
        string password = "password")
    {
        return new User()
        {
            Id = id,
            UserName = username,
            Email = email,
            Password = password,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now.AddDays(1)
        };
    }
}