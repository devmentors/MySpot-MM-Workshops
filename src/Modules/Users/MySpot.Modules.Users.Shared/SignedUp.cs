using MySpot.Shared.Abstractions.Events;

namespace MySpot.Modules.Users.Shared;

public record SignedUp(Guid UserId, string Email, string Role, string JobTitle) : IEvent;