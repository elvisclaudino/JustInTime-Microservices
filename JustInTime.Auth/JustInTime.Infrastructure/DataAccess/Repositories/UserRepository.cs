using JustInTime.Auth.JustInTime.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.Auth.JustInTime.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository
{
    private readonly JustInTimeDbContext _dbContext;

    public UserRepository(JustInTimeDbContext dbContext) => _dbContext = dbContext;

    public async Task<Domain.Entities.User> GetUserByEmailAsync(string email) => await _dbContext.Users.AsNoTracking()
        .FirstOrDefaultAsync(u => u.Email == email && u.Active);
}
