using JustInTime.Ponto.JustInTime.Domain.Repositories;

namespace JustInTime.Ponto.JustInTime.Infrastructure.DataAcess;

public class UnitOfWork : IUnitOfWork
{
    private readonly JustInTimeDbContext _dbContext;

    public UnitOfWork(JustInTimeDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
