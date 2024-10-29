using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.User.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private static readonly string[] Users = new[]
    {
        "Netcode", "Hub", "Fred"
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Users);
    }
}
