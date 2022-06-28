using MySpot.Shared.Infrastructure.Data;

namespace MySpot.Modules.ParkingSpots.Core.DAL;

internal class ParkingSpotsUnitOfWork : UnitOfWork<ParkingSpotsDbContext>
{
    public ParkingSpotsUnitOfWork(ParkingSpotsDbContext dbContext) : base(dbContext)
    {
    }
}