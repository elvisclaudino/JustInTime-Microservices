using JustInTime.User.Shared.Communication.Requests;
using JustInTime.User.Shared.Communication.Responses;

namespace JustInTime.User.JustInTime.Application.UseCases.User.Edit;

public interface IEditUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestEditUserJson request);
}
