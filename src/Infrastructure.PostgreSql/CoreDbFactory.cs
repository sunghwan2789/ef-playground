using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PostgreSql;

public class CoreDbFactory : IDbContextFactory<CoreDb>
{
    private readonly IDbContextFactory<PostgreSqlCoreDb> _providerDbFactory;

    public CoreDbFactory(IDbContextFactory<PostgreSqlCoreDb> providerDbFactory)
    {
        _providerDbFactory = providerDbFactory;
    }

    public CoreDb CreateDbContext()
    {
        return _providerDbFactory.CreateDbContext();
    }

    public async Task<CoreDb> CreateDbContextAsync(CancellationToken cancellationToken = default)
    {
        return await _providerDbFactory.CreateDbContextAsync(cancellationToken);
    }
}
