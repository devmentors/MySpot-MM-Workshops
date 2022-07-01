using MySpot.Shared.Abstractions.Modules;

namespace MySpot.Modules.ParkingSpots.Core.Clients;

public sealed class AvailabilityClient : IAvailabilityClient
{
    private readonly IModuleClient _moduleClient;

    public AvailabilityClient(IModuleClient moduleClient)
        => _moduleClient = moduleClient;

    public Task AddResource(Guid resourceId, int capacity, string[] tags)
        => _moduleClient.SendAsync("modules/availability/add_resource", new {resourceId, capacity, tags});
}