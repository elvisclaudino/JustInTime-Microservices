using JustInTime.User.JustInTime.Domain.Repositories;
using JustInTime.User.Shared.Communication.Responses;

namespace JustInTime.User.JustInTime.Application.UseCases.User.GetUsers;

public class GetAllActiveUsersUseCase : IGetAllActiveUsersUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;

    public GetAllActiveUsersUseCase(IUserReadOnlyRepository userReadOnlyRepository)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<IEnumerable<ResponseUserJson>> Execute()
    {
        var users = await _userReadOnlyRepository.GetActiveUsers();
        return users.Select(user => new ResponseUserJson
        {
            Name = user.Name,
            Email = user.Email,
            Horas_Mensais = user.Horas_Mensais
        });
    }
}
