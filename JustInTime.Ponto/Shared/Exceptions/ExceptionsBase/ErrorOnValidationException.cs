namespace JustInTime.User.Shared.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : JustInTimeException
{
    public IList<string> ErrorMessages { get; set; }
    
    public ErrorOnValidationException(IList<string> errorMessages) : base(string.Empty) => ErrorMessages = errorMessages;
}
