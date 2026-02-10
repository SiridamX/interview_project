using Microsoft.Extensions.Logging;
using BackEnd.Domain.Events;
using BackEnd.Domain.Interfaces;

namespace BackEnd.Application.EventHandlers;

public class UserCreatedEventHandler
    : IDomainEventHandler<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedEventHandler> _logger;

    public UserCreatedEventHandler(
        ILogger<UserCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(
        UserCreatedEvent domainEvent,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "[DomainEvent] User created: Id={UserId}, Name={UserName}",
            domainEvent.UserId,
            domainEvent.FirstName);

        return Task.CompletedTask;
    }
}
