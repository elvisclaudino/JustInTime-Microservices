namespace JustInTime.Auth.JustInTime.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    Task<Domain.Entities.User> GetUserByEmailAsync(string email);
}
