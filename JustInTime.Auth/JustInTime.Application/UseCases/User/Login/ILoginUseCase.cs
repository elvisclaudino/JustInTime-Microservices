using JustInTime.Auth.Shared.Communication.Requests;
using JustInTime.Auth.Shared.Communication.Responses;

namespace JustInTime.Auth.JustInTime.Application.UseCases.User.Login;

public interface ILoginUseCase
{
    Task<ResponseTokenJson> Execute(RequestLoginJson request);
}
