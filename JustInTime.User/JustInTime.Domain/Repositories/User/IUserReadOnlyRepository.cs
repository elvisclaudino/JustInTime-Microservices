namespace JustInTime.User.JustInTime.Domain.Repositories;

public interface IUserReadOnlyRepository
{
    public Task<bool> ExistActiveUserWithEmail(string email);
    Task<IEnumerable<Domain.Entities.User>> GetActiveUsers();
    Task<Domain.Entities.User?> GetById(long id);
}
