using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Modules.Reservations.Core.Repositories;
using MySpot.Modules.Reservations.Infrastructure.DAL;
using MySpot.Modules.Reservations.Infrastructure.DAL.Repositories;
using MySpot.Shared.Infrastructure.Data.MySQL;
using MySpot.Shared.Infrastructure.Data.Postgres;

namespace MySpot.Modules.Reservations.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
        .AddTransient<IWeeklyReservationsRepository, WeeklyReservationsRepository>()
        .AddTransient<IUserRepository, UserRepository>()
        .AddMySql<ReservationsDbContext>(configuration)
        .AddUnitOfWork<ReservationsUnitOfWork>();
}