using Equipment.Api.Common.Validation;
using Equipment.Api.Endpoints.Extensions;
using Equipment.Api.Endpoints.Processors;
using Equipment.Api.Middleware;
using Equipment.Core.Interfaces;
using Equipment.Infrastructure.Apis;
using Equipment.Infrastructure.Authentication;
using Equipment.Infrastructure.Cache;
using Equipment.Infrastructure.Databases;
using Equipment.Infrastructure.Messaging;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var environment = builder.Environment;

        configuration.AddUserSecrets<Program>(true, true);

        // ================================================
        // Aspire Services Configuration
        // ================================================

        // Add default service discovery, resilience, health checks, and OpenTelemetry services.
        builder.AddServiceDefaults();

        // Add support for Problem Details to provide standardized error responses.
        builder.Services.AddProblemDetails();

        // ================================================
        // Infrastructure Services Configuration
        // ================================================

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<ICurrentUserService, CurrentHttpUserService>();

        // Add infrastructure services for APIs.
        builder.Services.AddInfrastructureApiServices();

        // Add infrastructure services for caching.
        builder.Services.AddInfrastructureCacheServices(configuration);

        // Add infrastructure services for databases.
        builder.Services.AddInfrastructureDatabaseServices(environment.EnvironmentName);

        // Add infrastructure services for messaging.
        builder.Services.AddInfrastructureMessagingServices();

        // ================================================
        // Web API Services Configuration
        // ================================================

        // Add support for endpoints and OpenApi.
        builder.Services.AddApiEndpointServices();

        // Add support for authentication and authorization.
        builder.Services.AddApiAuthenticationServices(configuration);

        var app = builder.Build();

        app.UseExceptionHandler();

        app.UseMiddleware<ValidationExceptionMiddleware>();

        app.MapOpenApi();

        app.UseFastEndpoints(config =>
        {
            config.Endpoints.Configurator = endPointDefinition =>
           {
               endPointDefinition.PreProcessor<CorrelationIdGlobalPreProcessor>(Order.Before);
           };

            config.Errors.ResponseBuilder = (failures, ctx, statusCode) =>
            {
                return new ValidationFailureResponse
                {
                    Errors = [.. failures.Select(y => y.ErrorMessage)]
                };
            };
        }).UseSwaggerGen();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapDefaultEndpoints();

        app.Run();
    }
}

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
