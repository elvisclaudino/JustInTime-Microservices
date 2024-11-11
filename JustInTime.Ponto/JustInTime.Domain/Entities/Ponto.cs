namespace JustInTime.Ponto.JustInTime.Domain.Entities;

public class Ponto
{
    public long Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime Primeira_Entrada { get; set; }
    public DateTime? Primeira_Saida { get; set; }
    public DateTime? Segunda_Entrada { get; set; }
    public DateTime? Segunda_Saida { get; set; }
    public long Id_Usuario { get; set; }
}
