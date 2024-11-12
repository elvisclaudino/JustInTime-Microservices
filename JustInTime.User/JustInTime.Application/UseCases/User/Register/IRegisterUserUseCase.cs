using JustInTime.User.Shared.Communication.Requests;
using JustInTime.User.Shared.Communication.Responses;

namespace JustInTime.User.JustInTime.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
