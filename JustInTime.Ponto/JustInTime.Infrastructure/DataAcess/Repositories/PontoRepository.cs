
namespace JustInTime.Ponto.JustInTime.Infrastructure.DataAcess.Repositories;

public class PontoRepository : IPontoReadOnlyRepository, IPontoWriteOnlyRepository
{
    private readonly JustInTimeDbContext _dbContext;
    public PontoRepository(JustInTimeDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(Domain.Entities.Ponto ponto)
        {
            await _dbContext.Ponto.AddAsync(ponto);
        }

    public Task<IEnumerable<Domain.Entities.Ponto?>> GetAllByUsuarioId(long userId)
    {
        throw new NotImplementedException();
    }
}
