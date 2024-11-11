using JustInTime.Ponto.Shared.Communication.Requests;
using JustInTime.Ponto.Shared.Communication.Responses;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Edit;

public interface IEditPontoUseCase
{
    Task<ResponseRegisteredPontoJson> Execute(RequestEditPontoJson request);
}
