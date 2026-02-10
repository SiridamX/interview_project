using BackEnd.Application.EventHandlers;
using BackEnd.Application.Interfaces;
using BackEnd.Application.Interfaces.Repositories;
using BackEnd.Application.Interfaces.Security;
using BackEnd.Domain.Interfaces;
using BackEnd.Infrastructure.Context;
using BackEnd.Infrastructure.Events;
using BackEnd.Infrastructure.Persistence;
using BackEnd.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        // services.AddScoped<ITokenService, JwtTokenService>();
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        services.Scan(scan => scan
            .FromAssemblyOf<UserCreatedEventHandler>()
            .AddClasses(classes =>
                classes.AssignableTo(typeof(IDomainEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}

