using FluentValidation;
using JustInTime.User.Shared.Communication.Requests;
using JustInTime.User.Shared.Exceptions;

namespace JustInTime.User.JustInTime.Application.UseCases.User.Edit;

public class EditUserValidator : AbstractValidator<RequestEditUserJson>
{
    public EditUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
        RuleFor(user => user.Horas_Mensais).GreaterThan(0).WithMessage(ResourceMessagesException.HOURS_EMPTY);
    }
}
