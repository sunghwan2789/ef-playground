using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Oracle;

public class OracleCoreDb : CoreDb
{
    public OracleCoreDb(DbContextOptions<OracleCoreDb> options) : base(options) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Permission[]>().HaveJsonConversion();
    }
}
