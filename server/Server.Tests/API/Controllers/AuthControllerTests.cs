using System.Net;
using System.Security;
using Common.Models.DTOs;
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


namespace Server.Tests.API.Controllers;

public class AuthControllerTests
{
    private Mock<ILogger> mockLogger;
    private Mock<ISignOnService> mockSignOnService;
    private Mock<IRegistrationService> mockRegistrationService;
    private Mock<IUserMapper> mockUserMapper;

    #region Setup
    public AuthControllerTests()
    {
        mockLogger = new Mock<ILogger>();
        mockSignOnService = new Mock<ISignOnService>();
        mockRegistrationService = new Mock<IRegistrationService>();
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

    private AuthController GetTestController()
    {
        return new AuthController(
            mockLogger.Object, 
            mockSignOnService.Object,
            mockRegistrationService.Object,
            mockUserMapper.Object);
    }
    #endregion

    #region Controller Tests
    [Fact]
    public void AuthController_Constructor_Returns_Instance_Of_AuthController()
    {
        var testController = GetTestController();
        
        testController.Should().BeOfType<AuthController>();
    }
    #endregion
    
    #region Authenticate Endpoint
    [Fact]
    public async void AuthController_Authenticate_User_Endpoint_Returns_Valid_User_With_Email_Login()
    {
        // Arrange
        SetupMockLogger();
        var testLoginData = TestLoginDto.GetLoginDto(username: null);
        var testController = GetTestController();
        var testValidReturnData = TestSignInResponseDto.GetTestSignInResponseDto();

        mockSignOnService.Setup(x => x.SignOnOrchestrator(
                It.IsAny<LoginRequestDto>()))
            .Returns(Task.FromResult(testValidReturnData))
            .Verifiable();
        
        // Act
        var actionResult = await testController.SignOnUser(testLoginData);
        var result = actionResult.Result as OkObjectResult;

        // Assert
        actionResult.Result.Should().BeOfType<OkObjectResult>();
        actionResult.Result.Should().NotBeNull();
        result.Value.Should().BeOfType<SignInResponseDto>();

        var resultData = result.Value as SignInResponseDto;
        resultData.SuccessfulSignOn.Should().Be(true);
        resultData.BearerToken.Should().Be(testValidReturnData.BearerToken);

        mockSignOnService.Verify(x => x.SignOnOrchestrator(
            It.IsAny<LoginRequestDto>()), Times.Once);
    }
    #endregion
    
    #region Register Endpoint
    [Fact]
    public async void AuthController_Register_User_Endpoint_Successfully_Registers_User()
    {
        // Arrange
        SetupMockLogger();
        var testUserData = TestRegisterDto.GetRegisterDto();
        var testLoginUserDto = TestLoginDto.GetLoginDto();
        var testSignInResponseData = TestSignInResponseDto.GetTestSignInResponseDto();
        var testController = GetTestController();

        mockRegistrationService.Setup(x => x.RegistrationOrchestrator(
                It.IsAny<RegisterRequestDto>()))
            .Returns(Task.FromResult(true))
            .Verifiable();

        mockUserMapper.Setup(x => x.MapRegisterDtoToLoginDto(
                It.IsAny<RegisterRequestDto>()))
            .Returns(testLoginUserDto)
            .Verifiable();
        
        mockSignOnService.Setup(x => x.SignOnOrchestrator(
                It.IsAny<LoginRequestDto>()))
            .Returns(Task.FromResult(testSignInResponseData))
            .Verifiable();
        
        // Act
        var actionResult = await testController.RegisterUser(testUserData);
        var result = actionResult.Result as OkObjectResult;
        
        // Assert
        actionResult.Result.Should().BeOfType<OkObjectResult>();
        actionResult.Result.Should().NotBeNull();
        result.Value.Should().BeOfType<SignInResponseDto>();

        var resultData = result.Value as SignInResponseDto;
        resultData.SuccessfulSignOn.Should().Be(true);
        resultData.BearerToken.Should().Be(testSignInResponseData.BearerToken);
        
        mockRegistrationService.Verify(x => x.RegistrationOrchestrator(
            It.IsAny<RegisterRequestDto>()), Times.Once);
        mockUserMapper.Verify(x => x.MapRegisterDtoToLoginDto(
            It.IsAny<RegisterRequestDto>()), Times.Once);
        mockSignOnService.Verify(x => x.SignOnOrchestrator(
            It.IsAny<LoginRequestDto>()), Times.Once);
    }
    #endregion
}
