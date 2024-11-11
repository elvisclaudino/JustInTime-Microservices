using AutoMapper;
using JustInTime.Ponto.JustInTime.Domain.Repositories;
using JustInTime.Ponto.Shared.Communication.Requests;
using JustInTime.Ponto.Shared.Communication.Responses;
using JustInTime.User.Shared.Exceptions.ExceptionsBase;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Register;

public class RegisterPontoUseCase : IRegisterPontoUseCase
{
    private readonly IPontoWriteOnlyRepository _writeOnlyRepository;
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterPontoUseCase(
        IPontoWriteOnlyRepository writeOnlyRepository,
        IPontoReadOnlyRepository readOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredPontoJson> Execute(RequestRegisterPontoJson request)
    {
        await Validate(request);

        var user = _mapper.Map<Domain.Entities.Ponto>(request);

        await _writeOnlyRepository.Add(user);

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
}
