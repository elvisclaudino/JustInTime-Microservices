using AutoMapper;
using JustInTime.User.JustInTime.Domain.Repositories.User;
using JustInTime.User.JustInTime.Domain.Repositories;
using JustInTime.User.Shared.Communication.Responses;
using JustInTime.User.Shared.Communication.Requests;
using JustInTime.User.Shared.Exceptions.ExceptionsBase;
using JustInTime.User.Shared.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace JustInTime.User.JustInTime.Application.UseCases.User.Edit;

public class EditUserUseCase : IEditUserUseCase
{
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditUserUseCase(
            IUserWriteOnlyRepository writeOnlyRepository,
            IUserReadOnlyRepository readOnlyRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestEditUserJson request)
    {
        await Validate(request);

        var user = await _readOnlyRepository.GetById(request.Id);

        if (user == null)
        {
            throw new ErrorNotFoundException();
        }

        user = _mapper.Map(request, user);

        _writeOnlyRepository.Update(user);
        await _unitOfWork.Commit();

        return new ResponseRegisteredUserJson { Name = user.Name };
    }

    private async Task Validate(RequestEditUserJson request)
    {
        var validator = new EditUserValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
