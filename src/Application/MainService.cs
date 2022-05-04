using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class MainService : BackgroundService
{
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly IDbContextFactory<CoreDb> _dbFactory;

    public MainService(IHostApplicationLifetime applicationLifetime, IDbContextFactory<CoreDb> dbFactory)
    {
        _applicationLifetime = applicationLifetime;
        _dbFactory = dbFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var db = _dbFactory.CreateDbContext();
        db.Database.Migrate();

        foreach (var role in db.Roles)
        {
            Console.WriteLine($"{role.Name} / {string.Join(",", role.Permissions)}");
        }

        _applicationLifetime.StopApplication();
    }
}
