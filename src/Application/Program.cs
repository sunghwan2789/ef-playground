using Application;
using Infrastructure.PostgreSql;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddPostgreSqlCoreDbFactory(context.Configuration.GetConnectionString("postgres"));
        services.AddHostedService<MainService>();
    })
    .Build();

host.Run();
