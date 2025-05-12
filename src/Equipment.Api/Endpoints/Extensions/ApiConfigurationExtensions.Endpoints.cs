namespace Equipment.Api.Endpoints.Extensions;

public static partial class ApiConfigurationExtensions
{
    public const string SWAGGER_API_NAME = "Equipment API";

    public static IServiceCollection AddApiEndpointServices(this IServiceCollection services)
    {
        services.AddFastEndpoints(options =>
        {
            options.IncludeAbstractValidators = true;
        })
        .SwaggerDocument(options =>
        {
            options.EnableJWTBearerAuth = false;
            options.FlattenSchema = true;
            options.ShortSchemaNames = true;
            options.DocumentSettings = settings =>
            {
                settings.Title = SWAGGER_API_NAME;
                settings.Version = "v1";
            };
        });

        services.AddOpenApi();

        services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        return services;
    }
}
