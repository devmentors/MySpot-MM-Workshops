namespace MySpot.Modules.ParkingSpots.Core.Clients;

public interface IAvailabilityClient
{
    Task AddResource(Guid resourceId, int capacity, string[] tags);
}