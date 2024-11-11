using JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Get;
using JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Register;
using JustInTime.Ponto.Shared.Communication.Requests;
using JustInTime.Ponto.Shared.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.Ponto.Controllers;
[Authorize]
public class PontoController : JustInTimeController
{
    [HttpPost("register")]
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
}
