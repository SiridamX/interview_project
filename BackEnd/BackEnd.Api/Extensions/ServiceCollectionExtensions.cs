using BackEnd.API.Mappings;
using BackEnd.Application.Features.Users.Commands.Create;
using BackEnd.Infrastructure.DependencyInjection;

namespace BackEnd.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(
                typeof(CreateUserCommandHandler).Assembly
            );
        });

        services.AddAutoMapper(
            typeof(UserProfile).Assembly
        );

        return services;
    }
}
