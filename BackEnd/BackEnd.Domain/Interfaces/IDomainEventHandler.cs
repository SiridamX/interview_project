using BackEnd.Domain.Events;

namespace BackEnd.Domain.Interfaces;

public interface IDomainEventHandler<in TEvent>
    where TEvent : IDomainEvent
{
    Task HandleAsync(TEvent domainEvent,CancellationToken cancellationToken = default);
}
