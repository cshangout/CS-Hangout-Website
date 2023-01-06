using Microsoft.AspNetCore.Mvc;

namespace Server.API.Controllers;

/// <summary>
/// Authentication Controller
/// </summary>
[ApiController]
[Route("api/auth")]
public class Authentication : ControllerBase
{
    /// <summary>
    /// Authentication Constructor
    /// </summary>
    public Authentication()
    {
        
    }
    
    /// <summary>
    /// Authenticate User method and return response based on validation
    /// </summary>
    /// <returns>ActionResult</returns>
    [HttpPost]
    public ActionResult AuthenticateUser()
    {
        // Create logic for Authenticating a user
        return Ok();
    }
}