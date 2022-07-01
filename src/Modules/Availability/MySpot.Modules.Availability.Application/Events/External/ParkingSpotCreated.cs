using System;
using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Availability.Application.Events.External;

public record ParkingSpotCreated(Guid ParkingSpotId) : IEvent;