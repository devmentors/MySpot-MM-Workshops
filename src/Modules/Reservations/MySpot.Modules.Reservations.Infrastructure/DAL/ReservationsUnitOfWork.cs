using MySpot.Shared.Infrastructure.Data;

namespace MySpot.Modules.Reservations.Infrastructure.DAL;

internal class ReservationsUnitOfWork : UnitOfWork<ReservationsDbContext>
{
    public ReservationsUnitOfWork(ReservationsDbContext dbContext) : base(dbContext)
    {
    }
}