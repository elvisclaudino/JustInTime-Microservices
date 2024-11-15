﻿using AutoMapper;
using JustInTime.Ponto.Shared.Communication.Requests;

namespace JustInTime.Ponto.JustInTime.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterPontoJson, Domain.Entities.Ponto>();
        CreateMap<RequestEditPontoJson, Domain.Entities.Ponto>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); ;
    }
}
