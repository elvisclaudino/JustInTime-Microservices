using JustInTime.Auth.JustInTime.Application.Services.Auth;
using JustInTime.Auth.Shared.Communication.Requests;
using JustInTime.Auth.Shared.Communication.Responses;

namespace JustInTime.Auth.JustInTime.Application.UseCases.User.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly AuthService _authService;

    public LoginUseCase(AuthService authService)
    {
        _authService = authService;
    }

    public async Task<ResponseTokenJson> Execute(RequestLoginJson request)
    {
        return await _authService.Authenticate(request);
    }
}
