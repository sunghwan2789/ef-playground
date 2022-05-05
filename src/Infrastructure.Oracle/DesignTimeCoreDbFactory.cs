using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oracle.ManagedDataAccess.Client;

namespace Infrastructure.Oracle;

public class DesignTimeCoreDbFactory : IDesignTimeDbContextFactory<OracleCoreDb>
{
    public OracleCoreDb CreateDbContext(string[] args)
    {
        var connectionString = new OracleConnectionStringBuilder(Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__ORACLE"))
            .ConnectionString;

        var options = new DbContextOptionsBuilder<OracleCoreDb>()
            .UseOracle(connectionString, o => o
                .MigrationsAssembly(typeof(OracleCoreDb).Assembly.FullName))
            .Options;

        return new OracleCoreDb(options);
    }
}
