using JustInTime.User.JustInTime.Application.UseCases.User.Register;
using JustInTime.User.Shared.Communication.Requests;
using JustInTime.User.Shared.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.User.Controllers;
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
