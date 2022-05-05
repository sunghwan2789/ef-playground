using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Oracle;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOracleCoreDbFactory(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<OracleCoreDb>(options => options
            .UseOracle(connectionString, o => o
                .MigrationsAssembly(typeof(OracleCoreDb).Assembly.FullName)));

        services.AddSingleton<IDbContextFactory<CoreDb>, CoreDbFactory>();

        return services;
    }
}