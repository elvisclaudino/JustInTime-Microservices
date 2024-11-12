namespace JustInTime.User.Shared.Communication.Requests;

public class RequestEditUserJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Horas_Mensais { get; set; }
}
