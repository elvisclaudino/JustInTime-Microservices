﻿using JustInTime.Ponto.JustInTime.Domain.Entities;

public interface IPontoReadOnlyRepository
{
    Task<IEnumerable<JustInTime.Ponto.JustInTime.Domain.Entities.Ponto?>> GetAllByUsuarioId(long userId);
}
