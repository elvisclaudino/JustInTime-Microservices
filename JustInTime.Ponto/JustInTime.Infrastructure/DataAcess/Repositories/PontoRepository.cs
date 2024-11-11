
using Microsoft.EntityFrameworkCore;

namespace JustInTime.Ponto.JustInTime.Infrastructure.DataAcess.Repositories;

public class PontoRepository : IPontoReadOnlyRepository, IPontoWriteOnlyRepository
{
    private readonly JustInTimeDbContext _dbContext;
    public PontoRepository(JustInTimeDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(Domain.Entities.Ponto ponto) => await _dbContext.Ponto.AddAsync(ponto);

    public async Task<IEnumerable<Domain.Entities.Ponto?>> GetAllByUsuarioId(long userId) => await _dbContext.Ponto
        .Where(ponto => ponto.Id_Usuario.Equals(userId)).ToListAsync();

    public async Task<Domain.Entities.Ponto?> GetById(long id) => await _dbContext.Ponto.Where(u => u.Id == id).FirstOrDefaultAsync();

    public void Update(Domain.Entities.Ponto ponto) => _dbContext.Ponto.Update(ponto);

    public void Delete(Domain.Entities.Ponto ponto) => _dbContext.Ponto.Remove(ponto);
}
