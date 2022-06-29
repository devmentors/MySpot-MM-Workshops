using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Shared.Infrastructure.Data.MySQL;
using MySpot.Shared.Infrastructure.Data.Postgres;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MySpot.Shared.Infrastructure.Data.SQLServer;

public static class Extensions
{
    private const string SectionName = "sqlserver";
    
    public static IServiceCollection AddMsSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(SectionName);
        services.Configure<SqlServerOptions>(section);
        services.AddSingleton(new UnitOfWorkTypeRegistry());

        return services;
    }
    
    public static IServiceCollection AddMsSqlServer<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        var section = configuration.GetSection(SectionName);
        var options = section.BindOptions<SqlServerOptions>();
        
        services.AddDbContext<T>(x => x.UseSqlServer(options.ConnectionString));

        return services;
    }
}