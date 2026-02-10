using BackEnd.Domain.Entities;

namespace BackEnd.Domain.Events;

public class UserCreatedEvent : IDomainEvent
{
    public int UserId { get; }
    public string FirstName { get; }
     public string LastName { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public UserCreatedEvent(User user)
    {
        UserId = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }
}
