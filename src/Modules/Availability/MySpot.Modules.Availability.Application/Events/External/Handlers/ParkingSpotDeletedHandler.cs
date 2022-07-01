using System;
using System.Threading.Tasks;

namespace MySpot.Modules.Availability.Application.Events.External.Handlers;

using MySpot.Shared.Abstractions.Messaging;
using MySpot.Shared.Abstractions.Events;
internal sealed class ParkingSpotDeletedHandler 
{
    private readonly IMessageBroker _messageBroker;

    public ParkingSpotDeletedHandler(IMessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
    }

    public async Task Delete(Guid parkingSpotId)
    {
        await _messageBroker.PublishAsync(new ParkingSpotDeleted(parkingSpotId));
    }
}