using System;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Availability.Application.Events.External;

public record ParkingSpotDeleted(Guid ParkingSpotId) : IEvent;
