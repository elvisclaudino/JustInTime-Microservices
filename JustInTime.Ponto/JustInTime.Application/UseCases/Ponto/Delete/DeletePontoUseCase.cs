using JustInTime.Ponto.JustInTime.Domain.Repositories;
using JustInTime.User.Shared.Exceptions.ExceptionsBase;
using System.Security.Claims;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Delete;

public class DeletePontoUseCase : IDeletePontoUseCase
{
    private readonly IPontoReadOnlyRepository _readOnlyRepository;
    private readonly IPontoWriteOnlyRepository _writeOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DeletePontoUseCase(
            IPontoReadOnlyRepository readOnlyRepository,
            IPontoWriteOnlyRepository writeOnlyRepository,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Execute(long id)
    {
        var userId = GetUserIdFromToken();

        if (userId == null)
            throw new ErrorNotFoundException();

        var ponto = await _readOnlyRepository.GetById(id);

        if (ponto == null)
        {
            throw new ErrorNotFoundException();
        }

        if (ponto.Id_Usuario != userId)
        {
            throw new ErrorNotFoundException();
        }

        _writeOnlyRepository.Delete(ponto);

        await _unitOfWork.Commit();
    }

    private long? GetUserIdFromToken()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return null;
        }

        return long.Parse(userIdClaim);
    }
}
