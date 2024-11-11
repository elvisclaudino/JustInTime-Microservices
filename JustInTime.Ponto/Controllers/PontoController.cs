using JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Delete;
using JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Edit;
using JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Get;
using JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Register;
using JustInTime.Ponto.Shared.Communication.Requests;
using JustInTime.Ponto.Shared.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.Ponto.Controllers;
public class PontoController : JustInTimeController
{
    [HttpPost("register")]
    [Authorize]
    [ProducesResponseType(typeof(ResponseRegisteredPontoJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterPontoUseCase useCase,
        [FromBody] RequestRegisterPontoJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }

    [HttpGet("pontos")]
    [Authorize]
    [ProducesResponseType(typeof(IEnumerable<ResponsePontoJson>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPontosById(
        [FromServices] IGetAllPontosByIdUseCase useCase)
    {
        var result = await useCase.Execute();
        return Ok(result);
    }

    [HttpPut("edit/{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ResponseRegisteredPontoJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Edit(
    long id,
    [FromServices] IEditPontoUseCase useCase,
    [FromBody] RequestEditPontoJson request)
    {
        request.Id = id;

        var result = await useCase.Execute(request);

        return Ok(result);
    }

    [HttpPut("delete/{id}")]
    [Authorize]
    [ProducesResponseType(typeof(ResponseRegisteredPontoJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(
    long id,
    [FromServices] IDeletePontoUseCase useCase)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
