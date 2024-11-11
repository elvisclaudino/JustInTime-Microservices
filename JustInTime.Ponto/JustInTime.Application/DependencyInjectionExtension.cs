﻿using JustInTime.Ponto.JustInTime.Application.Services.AutoMapper;
using JustInTime.Ponto.JustInTime.Application.UseCases.Ponto.Register;

namespace JustInTime.Ponto.JustInTime.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    public static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterPontoUseCase, RegisterPontoUseCase>();
    }
}
