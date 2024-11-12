using AutoMapper;
using JustInTime.Ponto.JustInTime.Domain.Repositories;
using JustInTime.Ponto.Shared.Communication.Requests;
using JustInTime.Ponto.Shared.Communication.Responses;
using JustInTime.User;
using JustInTime.User.Shared.Exceptions.ExceptionsBase;
using System.Security.Claims;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Edit;

public class EditPontoUseCase : IEditPontoUseCase
{
    private readonly IPontoWriteOnlyRepository _writeOnlyRepository;
    private readonly IPontoReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EditPontoUseCase(
            IPontoWriteOnlyRepository writeOnlyRepository,
            IPontoReadOnlyRepository readOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ResponseRegisteredPontoJson> Execute(RequestEditPontoJson request)
    {
        await Validate(request);

        var userId = GetUserIdFromToken();

        if (userId == null)
            throw new ErrorNotFoundException();

        var ponto = await _readOnlyRepository.GetById(request.Id);

        if (ponto == null)
        {
            throw new ErrorNotFoundException();
        }

        if (ponto.Id_Usuario != userId)
        {
            throw new ErrorNotFoundException();
        }

        ponto = _mapper.Map(request, ponto);

        _writeOnlyRepository.Update(ponto);
        await _unitOfWork.Commit();

        var sender = new RabbitMqSender();
        sender.SendMessage($"Ponto edited: {ponto.Descricao}");
        sender.Close();

        return new ResponseRegisteredPontoJson { Descricao = ponto.Descricao };
    }

    private async Task Validate(RequestEditPontoJson request)
    {
        var validator = new EditPontoValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
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
