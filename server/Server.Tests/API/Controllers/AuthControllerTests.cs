using Serilog;
using Server.API.Controllers;

namespace Server.Tests.API.Controllers;

public class AuthControllerTests
{
    private Mock<ILogger> mockLogger;
    
    public AuthControllerTests()
    {
        mockLogger = new Mock<ILogger>();
    }

    [Fact]
    public void AuthController_Constructor_Returns_Instance_Of_AuthController()
    {
        var testController = new AuthController(mockLogger.Object);

        testController.Should().BeOfType<AuthController>();
    } 
}