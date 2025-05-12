using Equipment.Core.Interfaces;
using Equipment.Infrastructure.Databases.EquipmentDb;
using Equipment.Infrastructure.Databases.EquipmentDb.Repositories;

namespace Equipment.Infrastructure.Databases;

public static partial class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructureDatabaseServices(this IServiceCollection services, string environmentName)
    {
        // Add the interceptor for auditing entities
        services.AddScoped<AuditedEntityInterceptor>();
        services.AddScoped<DomainEventsInterceptor>();

        if (!environmentName.Equals("Test", StringComparison.OrdinalIgnoreCase))
        {
            // Add the DbContext for Equipment
            services.AddDbContext<EquipmentDbContext>((provider, optionsBuilder) =>
            {
                // Use the provider to get the configuration
                var configuration = provider.GetRequiredService<IConfiguration>();

                // Create a new SqlConnectionBuilder with the configuration
                var sqlConnectionBuilder = new SqlConnectionBuilder(
                    configuration,
                    DatabaseConstants.EQUIPMENT_DB_CONNECTION_STRING_NAME,
                    DatabaseConstants.AZURE_SQL_DB_CONNECTION_TOKEN_SCOPE);

                // Build the SqlConnection
                var sqlConnection = sqlConnectionBuilder.Build();

                // Configure the DbContext to use the SqlConnection
                // and set the command timeout and retry options
                // for transient failures
                optionsBuilder.UseSqlServer(sqlConnection, sqlOptions =>
                {
                    sqlOptions.CommandTimeout(DatabaseConstants.SQL_DB_CONNECTION_COMMAND_TIMEOUT);

                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: DatabaseConstants.SQL_DB_CONNECTION_MAX_RETRY_COUNT,
                        maxRetryDelay: TimeSpan.FromSeconds(DatabaseConstants.SQL_DB_CONNECTION_MAX_RETRY_DELAY),
                        errorNumbersToAdd: null);
                })
                .AddInterceptors(
                    provider.GetRequiredService<AuditedEntityInterceptor>(),
                    provider.GetRequiredService<DomainEventsInterceptor>()
                );
            });
        }

        // add the repository services
        services.AddScoped(typeof(IRepository<>), typeof(EquipmentEfRepository<>));
        services.AddScoped(typeof(EquipmentEfRepository<>));

        return services;
    }
}
