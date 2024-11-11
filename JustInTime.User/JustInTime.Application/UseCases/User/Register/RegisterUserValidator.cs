using FluentValidation;
using JustInTime.User.Shared.Communication.Requests;
using JustInTime.User.Shared.Exceptions;

namespace JustInTime.User.JustInTime.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.PASSWORD_INVALID);
        RuleFor(user => user.Horas_Mensais).GreaterThan(0).WithMessage(ResourceMessagesException.HOURS_EMPTY);
    }
}
