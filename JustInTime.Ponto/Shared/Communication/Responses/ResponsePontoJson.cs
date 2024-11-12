namespace JustInTime.Ponto.Shared.Communication.Responses;

public class ResponsePontoJson
{
    public string Descricao { get; set; } = string.Empty;
    public DateTime Primeira_Entrada { get; set; }
    public DateTime Primeira_Saida { get; set; }
    public DateTime Segunda_Entrada { get; set; }
    public DateTime Segunda_Saida { get; set; }
}
