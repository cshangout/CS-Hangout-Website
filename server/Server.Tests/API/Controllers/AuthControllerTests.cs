// using System.Net;
// using System.Security;
// using Common.Models.DTOs;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using Server.API.Controllers;
// using Server.Infrastructure.Data;
// using Server.Infrastructure.Mappers;
// using Server.Infrastructure.Repositories.Users;
// using Server.Tests.TestData.Dtos;
// using Server.Tests.TestData.Entities;
// using ILogger = Serilog.ILogger;
//
//
// namespace Server.Tests.API.Controllers;
//
// public class AuthControllerTests
// {
//     private Mock<ILogger> mockLogger;
//     private Mock<IUserRepository> mockUserRepository;
//
//     #region Setup
//     public AuthControllerTests()
//     {
//         mockLogger = new Mock<ILogger>();
//         mockUserRepository = new Mock<IUserRepository>();
//     }
//
//     private void SetupMockLogger()
//     {
//         mockLogger.Setup(x => x.Debug(
//             It.IsAny<Exception>(), It.IsAny<string>()))
//             .Verifiable();
//         mockLogger.Setup(x => x.Information(
//             It.IsAny<Exception>(), It.IsAny<string>()));
//         mockLogger.Setup(x => x.Information(
//             It.IsAny<string>(), It.IsAny<string>()));
//         mockLogger.Setup(x => x.Error(
//             It.IsAny<Exception>(), It.IsAny<string>()));
//         mockLogger.Setup(x => x.Error(
//             It.IsAny<string>(), It.IsAny<string>()));
//         mockLogger.Setup(x => x.Error(
//             It.IsAny<string>()));
//         mockLogger.Setup(x => x.ForContext<object>())
//             .Returns(mockLogger.Object);
//         mockLogger.Setup(x => x.ForContext(
//             It.IsAny<string>(), It.IsAny<object>(), false))
//             .Returns(mockLogger.Object);
//     }
//
//     private AuthController GetTestController()
//     {
//         return new AuthController(mockLogger.Object, mockUserRepository.Object);
//     }
//     #endregion
//
//     #region Controller Tests
//     [Fact]
//     public void AuthController_Constructor_Returns_Instance_Of_AuthController()
//     {
//         var testController = GetTestController();
//         
//         testController.Should().BeOfType<AuthController>();
//     }
//     #endregion
//     
//     #region Authenticate Endpoint
//     [Fact]
//     public async void AuthController_Authenticate_User_Endpoint_Returns_Valid_User_With_Email_Login()
//     {
//         // Arrange
//         SetupMockLogger();
//         var testLoginData = TestLoginDto.GetLoginDto(username: null);
//         var testController = GetTestController();
//         var testValidReturnData = TestUser.GetTestUser();
//
//         mockUserRepository.Setup(
//                 x => x.GetUserByEmail(It.IsAny<LoginDto>()))
//             .Returns(Task.FromResult(testValidReturnData))
//             .Verifiable();
//         
//         // Act
//         var actionResult = await testController.AuthenticateUser(testLoginData);
//         var result = actionResult.Result as OkObjectResult;
//
//         // Assert
//         actionResult.Result.Should().BeOfType<OkObjectResult>();
//         actionResult.Result.Should().NotBeNull();
//         result.Value.Should().BeOfType<UserDto>();
//
//         var resultData = result.Value as UserDto;
//         resultData.Username.Should().Be(testValidReturnData.UserName);
//     }
//     #endregion
//     
//     #region Register Endpoint
//     [Fact]
//     public async void AuthController_Register_User_Endpoint_Successfully_Registers_User()
//     {
//         // Arrange
//         SetupMockLogger();
//         var testUserData = TestRegisterDto.GetRegisterDto();
//         var testController = GetTestController();
//
//         mockUserRepository.Setup(x => x.AddUser(It.IsAny<RegisterDto>()))
//             .Returns(Task.FromResult(TestUserDto.GetTestUserDto(testUserData.UserName)))
//             .Verifiable();
//         
//         // Act
//         var actionResult = await testController.RegisterUser(testUserData);
//         var result = actionResult.Result as OkObjectResult;
//         
//         // Assert
//         actionResult.Result.Should().BeOfType<OkObjectResult>();
//         actionResult.Result.Should().NotBeNull();
//         result.Value.Should().BeOfType<UserDto>();
//
//         var resultData = result.Value as UserDto;
//         resultData.Username.Should().Be(testUserData.UserName);
//     }
//     #endregion
// }
