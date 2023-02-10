using System.Net;
using System.Security;
using Common.Interfaces;
using Common.Models.DTOs;
using Common.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.API.Controllers;
using Server.API.Features.Authentication.Registration;
using Server.API.Features.Authentication.SignOn;
using Server.Infrastructure.Data;
using Server.Infrastructure.Mappers;
using Server.Infrastructure.Repositories.Users;
using Server.Tests.TestData.Dtos;
using Server.Tests.TestData.Entities;
using ILogger = Serilog.ILogger;

namespace Server.Tests.Infrastructure.Repositories;

public class UserRepositoryTests
{
    private Mock<ILogger> mockLogger;
    private Mock<IDataContext> mockDataContext;
    private Mock<UserManager<ApplicationUser>> mockUserManager;
    private Mock<IUserMapper> mockUserMapper;

    #region Setup
    public UserRepositoryTests()
    {
        mockLogger = new Mock<ILogger>();
        mockDataContext = new Mock<IDataContext>();
        mockUserManager = new Mock<UserManager<ApplicationUser>>();
        mockUserMapper = new Mock<IUserMapper>();
    }

    private void SetupMockLogger()
    {
        mockLogger.Setup(x => x.Debug(
            It.IsAny<Exception>(), It.IsAny<string>()))
            .Verifiable();
        mockLogger.Setup(x => x.Information(
            It.IsAny<Exception>(), It.IsAny<string>()));
        mockLogger.Setup(x => x.Information(
            It.IsAny<string>(), It.IsAny<string>()));
        mockLogger.Setup(x => x.Error(
            It.IsAny<Exception>(), It.IsAny<string>()));
        mockLogger.Setup(x => x.Error(
            It.IsAny<string>(), It.IsAny<string>()));
        mockLogger.Setup(x => x.Error(
            It.IsAny<string>()));
        mockLogger.Setup(x => x.ForContext<object>())
            .Returns(mockLogger.Object);
        mockLogger.Setup(x => x.ForContext(
            It.IsAny<string>(), It.IsAny<object>(), false))
            .Returns(mockLogger.Object);
    }

    private UserRepository GetTestUserRepository()
    {
        return new UserRepository(
            mockLogger.Object,
            mockUserManager.Object,
            mockUserMapper.Object);
    }
    #endregion

    #region UserRepository Tests
    [Fact]
    public void UserRepository_Constructor_Returns_Instance_Of_UserRepository()
    {
        var testUserRepository = GetTestUserRepository();

        testUserRepository.Should().BeOfType<UserRepository>();
    }
    #endregion
}
