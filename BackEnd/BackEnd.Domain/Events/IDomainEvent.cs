namespace BackEnd.Domain.Events;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
