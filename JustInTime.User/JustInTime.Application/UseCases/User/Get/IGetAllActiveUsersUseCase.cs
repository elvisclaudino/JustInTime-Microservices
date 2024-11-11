using JustInTime.User.Shared.Communication.Responses;

namespace JustInTime.User.JustInTime.Application.UseCases.User.GetUsers;

public interface IGetAllActiveUsersUseCase
{
    public Task<IEnumerable<ResponseUserJson>> Execute();
}
