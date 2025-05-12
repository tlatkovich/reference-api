using Equipment.Infrastructure.Databases;

namespace Equipment.Infrastructure.Messaging;

public static partial class InfrastructureServiceCollection
{

    public static IServiceCollection AddInfrastructureMessagingServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DomainEventsInterceptor).Assembly);
        });

        return services;
    }
}
