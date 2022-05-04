using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.PostgreSql;

public class DesignTimeCoreDbFactory : IDesignTimeDbContextFactory<PostgreSqlCoreDb>
{
    public PostgreSqlCoreDb CreateDbContext(string[] args)
    {
        var connectionString = "Host=pgsql;Port=5432;Database=postgres;Username=postgres;Password=postgres";

        var options = new DbContextOptionsBuilder<PostgreSqlCoreDb>()
            .UseNpgsql(connectionString, o => o
                .MigrationsAssembly(typeof(PostgreSqlCoreDb).Assembly.FullName))
            .Options;

        return new PostgreSqlCoreDb(options);
    }
}
