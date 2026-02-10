using BackEnd.Domain.Events;
using System.Collections.Generic;

namespace BackEnd.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();

    public void SetUpdated() => UpdatedAt = DateTime.UtcNow;
    public void SetCreated() => CreatedAt = DateTime.UtcNow;
}
