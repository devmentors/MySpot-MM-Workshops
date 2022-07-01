using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.ParkingSpots.Core.Events;

public record ParkingSpotDeleted(Guid ParkingSpotId) : IEvent;
