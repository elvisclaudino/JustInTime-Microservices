namespace JustInTime.User.JustInTime.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    public Task Add(Entities.User user);
    void Update(Domain.Entities.User user);
}
