using JustInTime.Ponto.JustInTime.Domain.Repositories;
using JustInTime.Ponto.JustInTime.Infrastructure.DataAcess;
using JustInTime.Ponto.JustInTime.Infrastructure.DataAcess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.Ponto.JustInTime.Infrastructure;

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

        services.AddScoped<IPontoWriteOnlyRepository, PontoRepository>();
        services.AddScoped<IPontoReadOnlyRepository, PontoRepository>();

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
