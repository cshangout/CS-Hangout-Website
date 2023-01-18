using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Server.API.Controllers.Interfaces;

namespace Server.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ClassesController : BaseController, IClassesController
{
    private readonly ILogger _logger;

    public ClassesController(ILogger logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<string> GetAllClasses()
    {
        return Ok("All classes returned");
    }
}