namespace JustInTime.Ponto.JustInTime.Domain.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
}
