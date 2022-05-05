using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Sqlite;

public class DesignTimeCoreDbFactory : IDesignTimeDbContextFactory<SqliteCoreDb>
{
    public SqliteCoreDb CreateDbContext(string[] args)
    {
        var connectionString = "Data Source=:memory:";

        var options = new DbContextOptionsBuilder<SqliteCoreDb>()
            .UseSqlite(connectionString, o => o
                .MigrationsAssembly(typeof(SqliteCoreDb).Assembly.FullName))
            .Options;

        return new SqliteCoreDb(options);
    }
}
