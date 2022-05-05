using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Sqlite;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqliteCoreDbFactory(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<SqliteCoreDb>(options => options
            .UseSqlite(connectionString, o => o
                .MigrationsAssembly(typeof(SqliteCoreDb).Assembly.FullName)));

        services.AddSingleton<IDbContextFactory<CoreDb>, CoreDbFactory>();

        return services;
    }
}