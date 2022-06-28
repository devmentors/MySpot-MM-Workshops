using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySpot.Modules.ParkingSpots.Core.Entities;
using MySpot.Shared.Infrastructure;

namespace MySpot.Modules.ParkingSpots.Core.DAL;

internal sealed class ParkingSpotsInitializer : IInitializer
{
    private readonly ParkingSpotsDbContext _dbContext;
    private readonly ILogger<ParkingSpotsInitializer> _logger;

    public ParkingSpotsInitializer(ParkingSpotsDbContext dbContext, ILogger<ParkingSpotsInitializer> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task InitAsync()
    {
        if (await _dbContext.ParkingSpots.AnyAsync())
        {
            return;
        }

        await AddParkingSpotsAsync();
        await _dbContext.SaveChangesAsync();
    }

    private async Task AddParkingSpotsAsync()
    {
        var parkingSpots = Enumerable.Range(1, 10).Select(i => new ParkingSpot
        {
            Id = Guid.NewGuid(),
            Name = $"P{i}",
            DisplayOrder = i
        });

        await _dbContext.ParkingSpots.AddRangeAsync(parkingSpots);
        _logger.LogInformation("Initialized parking spots.");
    }
}