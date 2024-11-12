namespace JustInTime.User.JustInTime.Domain.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
}
