using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Availability.Core.Repositories;
using MySpot.Modules.Availability.Infrastructure.DAL;
using MySpot.Modules.Availability.Infrastructure.DAL.Repositories;
using MySpot.Shared.Infrastructure.Data.MySQL;
using MySpot.Shared.Infrastructure.Data.Postgres;
using MySpot.Shared.Infrastructure.Data.SQLServer;

namespace MySpot.Modules.Availability.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddTransient<IResourcesRepository, ResourcesRepository>()
            .AddMsSqlServer<AvailabilityDbContext>(configuration)
            .AddUnitOfWork<AvailabilityUnitOfWork>();
}