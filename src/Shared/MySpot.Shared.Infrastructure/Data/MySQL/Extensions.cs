using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Shared.Infrastructure.Data.Postgres;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MySpot.Shared.Infrastructure.Data.MySQL;

public static class Extensions
{
    private const string SectionName = "mysql";
    
    public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(SectionName);
        services.Configure<MySqlOptions>(section);
        services.AddSingleton(new UnitOfWorkTypeRegistry());

        return services;
    }
    
    public static IServiceCollection AddMySql<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        var section = configuration.GetSection(SectionName);
        var options = section.BindOptions<PostgresOptions>();
        
        var serverVersion = new MySqlServerVersion(new Version(8, 0));
        services.AddDbContext<T>(x => x.UseMySql(options.ConnectionString, serverVersion,
            o => o.SchemaBehavior(MySqlSchemaBehavior.Translate, (schema, table) => $"{schema}_{table}")));

        return services;
    }
}