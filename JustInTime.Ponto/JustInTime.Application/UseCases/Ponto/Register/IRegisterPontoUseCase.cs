using JustInTime.Ponto.Shared.Communication.Requests;
using JustInTime.Ponto.Shared.Communication.Responses;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Register;

public interface IRegisterPontoUseCase
{
    public Task<ResponseRegisteredPontoJson> Execute(RequestRegisterPontoJson request);
}
