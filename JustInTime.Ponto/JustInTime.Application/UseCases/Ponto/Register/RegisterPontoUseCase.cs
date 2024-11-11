using AutoMapper;
using JustInTime.Ponto.JustInTime.Domain.Repositories;
using JustInTime.Ponto.Shared.Communication.Requests;
using JustInTime.Ponto.Shared.Communication.Responses;
using JustInTime.User.Shared.Exceptions.ExceptionsBase;
using System.Security.Claims;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Register;

public class RegisterPontoUseCase : IRegisterPontoUseCase
{
    private readonly IPontoWriteOnlyRepository _writeOnlyRepository;
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RegisterPontoUseCase(
        IPontoWriteOnlyRepository writeOnlyRepository,
        IPontoReadOnlyRepository readOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ResponseRegisteredPontoJson> Execute(RequestRegisterPontoJson request)
    {
        await Validate(request);

        var userId = GetUserIdFromToken();

        if (userId == null)
            throw new ErrorNotFoundException();

        var ponto = _mapper.Map<Domain.Entities.Ponto>(request);

        ponto.Id_Usuario = userId.Value;

        await _writeOnlyRepository.Add(ponto);

        await _unitOfWork.Commit();

        return new ResponseRegisteredPontoJson
        {
            Descricao = request.Descricao
        };
    }

    private async Task Validate(RequestRegisterPontoJson request)
    {
        var validator = new RegisterPontoValidator();

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
