using JustInTime.User.JustInTime.Domain.Repositories;
using JustInTime.User.JustInTime.Domain.Repositories.User;
using JustInTime.User.JustInTime.Infrastructure.DataAccess;
using JustInTime.User.JustInTime.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.User.JustInTime.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();

    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

        services.AddDbContext<JustInTimeDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseMySql(connectionString, serverVersion);
        });
    }
}
