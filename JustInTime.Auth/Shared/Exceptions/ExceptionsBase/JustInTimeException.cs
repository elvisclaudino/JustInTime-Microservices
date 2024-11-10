namespace JustInTime.Auth.Shared.Exceptions.ExceptionsBase;

public class JustInTimeException : SystemException
{
    public JustInTimeException(string message) : base(message) { }
}
