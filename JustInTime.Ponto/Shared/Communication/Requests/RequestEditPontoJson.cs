namespace JustInTime.Ponto.Shared.Communication.Requests;

public class RequestEditPontoJson
{
    public long Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime Primeira_Entrada { get; set; }
    public DateTime Primeira_Saida { get; set; }
    public DateTime Segunda_Entrada { get; set; }
    public DateTime Segunda_Saida { get; set; }
}
