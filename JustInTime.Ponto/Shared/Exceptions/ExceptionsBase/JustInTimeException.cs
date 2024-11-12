namespace JustInTime.User.Shared.Exceptions.ExceptionsBase;

public class JustInTimeException : SystemException
{
    public JustInTimeException(string message) : base(message) { }
}
