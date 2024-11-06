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
    public IActionResult Register(RequestRegisterUserJson request)
    {
        var useCase = new RegisterUserUseCase();

        var result = useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
