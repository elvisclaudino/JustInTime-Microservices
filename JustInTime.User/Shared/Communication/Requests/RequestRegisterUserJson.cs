namespace JustInTime.User.Shared.Communication.Requests;

public class RequestRegisterUserJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Horas_Mensais { get; set; } = 0;
}
