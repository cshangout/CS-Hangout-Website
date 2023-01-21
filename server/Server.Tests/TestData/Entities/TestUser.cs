using Common.Models.Entities;

namespace Server.Tests.TestData.Entities;

public static class TestUser
{
    public static ApplicationUser GetTestUser(
        string username = "testUser",
        string email = "test@gmail.com",
        string password = "passwordHash")
    {
        return new ApplicationUser()
        {
            UserName = username,
            Email = email,
            PasswordHash = password,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now.AddDays(1)
        };
    }
}