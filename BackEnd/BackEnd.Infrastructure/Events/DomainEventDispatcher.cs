using Microsoft.Extensions.DependencyInjection;
using BackEnd.Domain.Events;
using BackEnd.Domain.Interfaces;

namespace BackEnd.Infrastructure.Events;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync(IDomainEvent domainEvent)
    {
        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        var handlers = _serviceProvider.GetServices(handlerType);

        foreach (var handler in handlers)
        {
            await ((Task)handlerType
                .GetMethod("HandleAsync")!
                .Invoke(handler, new object[] { domainEvent })!);
        }
    }
}
