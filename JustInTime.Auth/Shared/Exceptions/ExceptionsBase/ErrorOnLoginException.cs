namespace JustInTime.Auth.Shared.Exceptions.ExceptionsBase;

public class ErrorOnLoginException : JustInTimeException
{
    public ErrorOnLoginException() : base(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID)
    {
    }
}
