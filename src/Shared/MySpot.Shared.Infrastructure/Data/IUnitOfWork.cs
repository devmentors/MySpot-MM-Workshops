using System;
using System.Threading.Tasks;

namespace MySpot.Shared.Infrastructure.Data;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}