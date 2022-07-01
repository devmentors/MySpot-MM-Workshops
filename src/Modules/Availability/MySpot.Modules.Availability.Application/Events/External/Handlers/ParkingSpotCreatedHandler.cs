using System.Threading;
using MySpot.Modules.Availability.Application.Exceptions;
using MySpot.Modules.Availability.Core.Entities;
using MySpot.Modules.Availability.Core.Repositories;
using MySpot.Modules.Availability.Core.ValueObjects;
using MySpot.Shared.Abstractions.Domain;

namespace MySpot.Modules.Availability.Application.Events.External.Handlers;
using System;
using System.Threading.Tasks;
 
using MySpot.Shared.Abstractions.Messaging;
using MySpot.Shared.Abstractions.Events;
internal sealed class ParkingSpotCreatedHandler:IEventHandler<ParkingSpotCreated>

{
    private IMessageBroker _messageBroker;
    private readonly IResourcesRepository _repository;
    public ParkingSpotCreatedHandler(IMessageBroker messageBroker, IResourcesRepository repository)
    {
        _messageBroker = messageBroker;
        _repository = repository;
    }
 

    public async Task HandleAsync(ParkingSpotCreated @event, CancellationToken cancellationToken = default)
    {
        var exists = await _repository.ExistsAsync(@event.ParkingSpotId);
        if (exists)
        {
            throw new ResourceAlreadyExistsException(@event.ParkingSpotId);
        }
        var resource = Resource.Create(@event.ParkingSpotId, 2, new[]{new Tag("parking_spot")});
        await _repository.AddAsync(resource);
    }
}