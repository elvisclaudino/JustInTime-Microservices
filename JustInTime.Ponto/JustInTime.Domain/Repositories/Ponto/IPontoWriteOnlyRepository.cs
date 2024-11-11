using JustInTime.Ponto.JustInTime.Domain.Entities;

public interface IPontoWriteOnlyRepository
{
    Task Add(JustInTime.Ponto.JustInTime.Domain.Entities.Ponto ponto);
}
