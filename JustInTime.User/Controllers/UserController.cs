using JustInTime.User.JustInTime.Application.UseCases.User.Delete;
using JustInTime.User.JustInTime.Application.UseCases.User.Edit;
using JustInTime.User.JustInTime.Application.UseCases.User.GetUsers;
using JustInTime.User.JustInTime.Application.UseCases.User.Register;
using JustInTime.User.Shared.Communication.Requests;
using JustInTime.User.Shared.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.User.Controllers;
public class UserController : JustInTimeController
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }

    [HttpGet("users")]
    [Authorize]
    [ProducesResponseType(typeof(IEnumerable<ResponseUserJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllActiveUsers(
            [FromServices] IGetAllActiveUsersUseCase useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }

    [HttpPut("edit/{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Edit(
    long id,
    [FromServices] IEditUserUseCase useCase,
    [FromBody] RequestEditUserJson request)
    {
        request.Id = id;

        var result = await useCase.Execute(request);

        return Ok(result);
    }

    [HttpPut("delete/{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(
    long id,
    [FromServices] IDeleteUserUseCase useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
