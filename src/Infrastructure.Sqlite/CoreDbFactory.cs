using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Sqlite;

public class CoreDbFactory : IDbContextFactory<CoreDb>
{
    private readonly IDbContextFactory<SqliteCoreDb> _providerDbFactory;

    public CoreDbFactory(IDbContextFactory<SqliteCoreDb> providerDbFactory)
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
