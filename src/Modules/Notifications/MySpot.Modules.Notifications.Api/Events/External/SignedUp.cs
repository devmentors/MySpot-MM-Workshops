using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Notifications.Api.Events.External;

public record SignedUp(Guid UserId, string Email, string Role, string JobTitle) : IEvent;