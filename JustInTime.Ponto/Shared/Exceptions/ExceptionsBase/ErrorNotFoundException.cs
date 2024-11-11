using JustInTime.Ponto.Shared.Exceptions;

namespace JustInTime.User.Shared.Exceptions.ExceptionsBase;

public class ErrorNotFoundException : JustInTimeException
{
    public ErrorNotFoundException() : base(ResourceMessagesException.NOT_FOUND)
    {
    }
}
