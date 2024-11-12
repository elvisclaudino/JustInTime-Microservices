using JustInTime.User.JustInTime.Domain.Repositories;
using JustInTime.User.JustInTime.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.User.JustInTime.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly JustInTimeDbContext _dbContext;

    public UserRepository(JustInTimeDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(Domain.Entities.User user) => await _dbContext.Users.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);

    public async Task<IEnumerable<Domain.Entities.User>> GetActiveUsers() => await _dbContext.Users.Where(user => user.Active).ToListAsync();

    public async Task<Domain.Entities.User?> GetById(long id) => await _dbContext.Users.Where(u => u.Id == id && u.Active).FirstOrDefaultAsync();

    public void Update(Domain.Entities.User user) => _dbContext.Users.Update(user);

    public void Delete(Domain.Entities.User user) => _dbContext.Users.Remove(user);
}
