using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Oracle;

public class CoreDbFactory : IDbContextFactory<CoreDb>
{
    private readonly IDbContextFactory<OracleCoreDb> _providerDbFactory;

    public CoreDbFactory(IDbContextFactory<OracleCoreDb> providerDbFactory)
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
