using Serilog;
using Server.API.Controllers;
using Server.Infrastructure.Data;
using Server.Infrastructure.Mappers;
using Server.Infrastructure.Repositories.Users;
using Server.Tests.TestData.Dtos;

namespace Server.Tests.API.Controllers;

public class AuthControllerTests
{
    private Mock<ILogger> mockLogger;
    private Mock<IUserRepository> mockUserRepository;
    
    public AuthControllerTests()
    {
        mockLogger = new Mock<ILogger>();
        mockUserRepository = new Mock<IUserRepository>();
    }

    private AuthController GetTestController()
    {
        return new AuthController(mockLogger.Object, mockUserRepository.Object);
    }

    [Fact]
    public void AuthController_Constructor_Returns_Instance_Of_AuthController()
    {
        var testController = GetTestController();
        
        testController.Should().BeOfType<AuthController>();
    }

    [Fact]
    public void AuthController_Authenticate_User_Endpoint_Returns_Valid_User()
    {
        // Arrange
        var testController = GetTestController();
        // mockUserRepository.Setup(x => )
        
        // Act
        var result = testController.AuthenticateUser(TestLoginDto.GetLoginDto());
        
        // Assert
        

    }
}