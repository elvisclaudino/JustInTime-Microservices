using JustInTime.User.JustInTime.Domain.Repositories.User;
using JustInTime.User.JustInTime.Domain.Repositories;
using JustInTime.User.Shared.Exceptions.ExceptionsBase;

namespace JustInTime.User.JustInTime.Application.UseCases.User.Delete;

public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserUseCase(
            IUserReadOnlyRepository readOnlyRepository,
            IUserWriteOnlyRepository writeOnlyRepository,
            IUnitOfWork unitOfWork)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var user = await _readOnlyRepository.GetById(id);

        if (user == null)
        {
            throw new ErrorNotFoundException();
        }

        user.Active = false;
        _writeOnlyRepository.Update(user);

        await _unitOfWork.Commit();

        var sender = new RabbitMqSender();
        sender.SendMessage($"User deleted: {user.Name}");
        sender.Close();
    }
}
