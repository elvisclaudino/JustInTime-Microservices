using JustInTime.Ponto.Shared.Communication.Responses;
using JustInTime.User.Shared.Exceptions.ExceptionsBase;
using System.Security.Claims;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Get;

public class GetAllPontosByIdUseCase : IGetAllPontosByIdUseCase
{
    private readonly IPontoReadOnlyRepository _pontoReadOnlyRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetAllPontosByIdUseCase(IPontoReadOnlyRepository pontoReadOnlyRepository, IHttpContextAccessor httpContextAccessor)
    {
        _pontoReadOnlyRepository = pontoReadOnlyRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<ResponsePontoJson>> Execute()
    {
        var userId = GetUserIdFromToken();

        if (userId == null)
            throw new ErrorNotFoundException();

        var pontos = await _pontoReadOnlyRepository.GetAllByUsuarioId(userId.Value);
        return pontos.Select(ponto => new ResponsePontoJson
        {
            Descricao = ponto.Descricao,
            Primeira_Entrada = ponto.Primeira_Entrada,
            Primeira_Saida = ponto.Primeira_Saida,
            Segunda_Entrada = ponto.Segunda_Entrada,
            Segunda_Saida = ponto.Segunda_Saida
        });
    }

    private long? GetUserIdFromToken()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return null;
        }

        return long.Parse(userIdClaim);
    }
}
