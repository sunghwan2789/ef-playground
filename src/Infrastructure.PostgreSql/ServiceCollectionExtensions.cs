using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.PostgreSql;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgreSqlCoreDbFactory(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<PostgreSqlCoreDb>(options => options
            .UseNpgsql(connectionString, o => o
                .MigrationsAssembly(typeof(PostgreSqlCoreDb).Assembly.FullName)));

        services.AddSingleton<IDbContextFactory<CoreDb>, CoreDbFactory>();

        return services;
    }
}