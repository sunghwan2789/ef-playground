using Application;
using Infrastructure.Oracle;
using Infrastructure.PostgreSql;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        switch (configuration.GetValue<DataProvider>("DataProvider"))
        {
        case DataProvider.PostgreSql:
            services.AddPostgreSqlCoreDbFactory(configuration.GetConnectionString("postgresql"));
            break;
        case DataProvider.Oracle:
            services.AddOracleCoreDbFactory(configuration.GetConnectionString("oracle"));
            break;
        default:
            throw new NotSupportedException();
        }

        services.AddHostedService<MainService>();
    })
    .Build();

host.Run();
