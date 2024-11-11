using JustInTime.Ponto.JustInTime.Domain.Entities;

public interface IPontoWriteOnlyRepository
{
    Task Add(JustInTime.Ponto.JustInTime.Domain.Entities.Ponto ponto);

    void Update(JustInTime.Ponto.JustInTime.Domain.Entities.Ponto ponto);

    void Delete(JustInTime.Ponto.JustInTime.Domain.Entities.Ponto ponto);
}
