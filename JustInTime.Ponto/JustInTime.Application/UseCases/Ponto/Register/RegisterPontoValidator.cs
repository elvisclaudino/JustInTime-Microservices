using FluentValidation;
using JustInTime.Ponto.Shared.Communication.Requests;
using JustInTime.Ponto.Shared.Exceptions;

namespace JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Register;

public class RegisterPontoValidator : AbstractValidator<RequestRegisterPontoJson>
{
    public RegisterPontoValidator()
    {
        RuleFor(ponto => ponto.Descricao).NotEmpty().WithMessage(ResourceMessagesException.DESCRICAO_EMPTY);
        RuleFor(ponto => ponto.Primeira_Entrada).NotEmpty().WithMessage(ResourceMessagesException.DATE_EMPTY);
        RuleFor(ponto => ponto.Primeira_Saida).NotEmpty().WithMessage(ResourceMessagesException.DATE_EMPTY);
        RuleFor(ponto => ponto.Segunda_Entrada).NotEmpty().WithMessage(ResourceMessagesException.DATE_EMPTY);
        RuleFor(ponto => ponto.Segunda_Saida).NotEmpty().WithMessage(ResourceMessagesException.DATE_EMPTY);
    }
}
