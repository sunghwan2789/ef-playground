using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PostgreSql;

public class PostgreSqlCoreDb : CoreDb
{
    public PostgreSqlCoreDb(DbContextOptions<PostgreSqlCoreDb> options) : base(options) { }
}
