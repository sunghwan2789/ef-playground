using Application;
using Infrastructure.Oracle;
using Infrastructure.PostgreSql;
using Infrastructure.Sqlite;

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
        case DataProvider.Sqlite:
            services.AddSqliteCoreDbFactory(configuration.GetConnectionString("sqlite"));
            break;
        default:
            throw new NotSupportedException();
        }

        services.AddHostedService<MainService>();
    })
    .Build();

host.Run();
