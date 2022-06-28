using MySpot.Shared.Infrastructure.Data;

namespace MySpot.Modules.Availability.Infrastructure.DAL;

internal class AvailabilityUnitOfWork : UnitOfWork<AvailabilityDbContext>
{
    public AvailabilityUnitOfWork(AvailabilityDbContext dbContext) : base(dbContext)
    {
    }
}