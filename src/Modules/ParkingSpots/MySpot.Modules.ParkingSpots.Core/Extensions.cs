using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.ParkingSpots.Core.DAL;
using MySpot.Modules.ParkingSpots.Core.Services;
using MySpot.Shared.Infrastructure;
using MySpot.Shared.Infrastructure.Data.MySQL;
using MySpot.Shared.Infrastructure.Data.Postgres;

[assembly: InternalsVisibleTo("MySpot.Modules.ParkingSpots.Api")]

namespace MySpot.Modules.ParkingSpots.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddScoped<IParkingSpotsService, ParkingSpotsService>()
            .AddMySql<ParkingSpotsDbContext>(configuration)
            .AddUnitOfWork<ParkingSpotsUnitOfWork>();
    }
}