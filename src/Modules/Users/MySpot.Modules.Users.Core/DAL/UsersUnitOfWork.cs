using MySpot.Shared.Infrastructure.Data;

namespace MySpot.Modules.Users.Core.DAL;

internal class UsersUnitOfWork : UnitOfWork<UsersDbContext>
{
    public UsersUnitOfWork(UsersDbContext dbContext) : base(dbContext)
    {
    }
}