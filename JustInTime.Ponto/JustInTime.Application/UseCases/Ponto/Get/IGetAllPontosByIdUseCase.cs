using JustInTime.Ponto.Shared.Communication.Responses;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Get;

public interface IGetAllPontosByIdUseCase
{
    public  Task<IEnumerable<ResponsePontoJson>> Execute();
}
