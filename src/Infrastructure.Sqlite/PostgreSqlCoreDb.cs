using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Sqlite;

public class SqliteCoreDb : CoreDb
{
    public SqliteCoreDb(DbContextOptions<SqliteCoreDb> options) : base(options) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Permission[]>().HaveJsonConversion();
    }
}
