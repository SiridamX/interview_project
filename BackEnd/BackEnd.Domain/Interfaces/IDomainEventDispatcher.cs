using BackEnd.Domain.Events;
using System.Threading.Tasks;

namespace BackEnd.Domain.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IDomainEvent domainEvent);
}
