using System.Collections.Generic;
using System.Linq;

namespace MySpot.Shared.Abstractions.Domain;

public abstract class AggregateRoot
{
    private bool _versionIncremented = false;

    private readonly List<IDomainEvent> _events = new();
    public IEnumerable<IDomainEvent> Events => _events;
    public AggregateId Id { get; protected set; }
    public int Version { get; protected set; }

    public void AddEvent(IDomainEvent @event)
    {
        if (!_events.Any())
        {
            IncrementVersion();
        }

        _events.Add(@event);
    }

    public void ClearEvents() => _events.Clear();
    
    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
    }
}