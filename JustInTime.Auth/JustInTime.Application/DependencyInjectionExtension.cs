using JustInTime.Auth.JustInTime.Application.Services.Auth;
using JustInTime.Auth.JustInTime.Application.Services.Cryptography;
using JustInTime.Auth.JustInTime.Application.UseCases.User.Login;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JustInTime.Auth.JustInTime.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddAuthService(services);
        AddUseCases(services);
        AddPasswordEncripter(services, configuration);
        AddAuthentication(services, configuration);
    }

    private static void AddAuthService(IServiceCollection services)
    {
        services.AddScoped<AuthService>();
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ILoginUseCase, LoginUseCase>();
    }

    private static void AddPasswordEncripter(IServiceCollection services, IConfiguration configuration)
    {
        var addtionalKey = configuration.GetSection("Settings:Password:AdditionalKey").Value;

        services.AddScoped(option => new PasswordEncripter(addtionalKey!));
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "JustInTime",
                ValidAudience = "JustInTimeUsers",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]))
            };
        });
    }
}
