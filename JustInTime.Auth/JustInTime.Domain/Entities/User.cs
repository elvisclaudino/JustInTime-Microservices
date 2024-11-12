namespace JustInTime.Auth.JustInTime.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Horas_Mensais { get; set; } = 0;
}
