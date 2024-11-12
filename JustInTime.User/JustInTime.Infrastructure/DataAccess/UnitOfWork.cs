using JustInTime.User.JustInTime.Domain.Repositories;

namespace JustInTime.User.JustInTime.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly JustInTimeDbContext _dbContext;

    public UnitOfWork(JustInTimeDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
