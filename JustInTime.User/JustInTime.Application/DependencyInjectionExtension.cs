using JustInTime.User.JustInTime.Application.Services.AutoMapper;
using JustInTime.User.JustInTime.Application.Services.Cryptography;
using JustInTime.User.JustInTime.Application.UseCases.User.Delete;
using JustInTime.User.JustInTime.Application.UseCases.User.Edit;
using JustInTime.User.JustInTime.Application.UseCases.User.GetUsers;
using JustInTime.User.JustInTime.Application.UseCases.User.Register;

namespace JustInTime.User.JustInTime.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddAutoMapper(services);
        AddUseCases(services);
        AddPasswordEncripter(services, configuration);
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
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IGetAllActiveUsersUseCase, GetAllActiveUsersUseCase>();
        services.AddScoped<IEditUserUseCase, EditUserUseCase>();
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
    }
    
    private static void AddPasswordEncripter(IServiceCollection services, IConfiguration configuration)
    {
        var addtionalKey = configuration.GetSection("Settings:Password:AdditionalKey").Value;

        services.AddScoped(option => new PasswordEncripter(addtionalKey!));
    }
}
