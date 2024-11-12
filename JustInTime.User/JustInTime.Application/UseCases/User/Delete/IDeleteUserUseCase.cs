namespace JustInTime.User.JustInTime.Application.UseCases.User.Delete;

public interface IDeleteUserUseCase
{
    public Task Execute(long id);
}
