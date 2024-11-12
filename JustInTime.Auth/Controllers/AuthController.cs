using JustInTime.Auth.JustInTime.Application.UseCases.User.Login;
using JustInTime.Auth.Shared.Communication.Requests;
using JustInTime.Auth.Shared.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.Auth.Controllers;
[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTokenJson), 200)]
    public async Task<IActionResult> Login([FromBody] RequestLoginJson request, [FromServices] ILoginUseCase useCase)
    {
        var result = await useCase.Execute(request);
        return Ok(result);
    }
}
