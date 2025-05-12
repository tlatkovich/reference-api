namespace Equipment.Infrastructure.Authentication;

public static partial class InfrastructureServiceCollection
{
    public static IServiceCollection AddApiAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(jwtBearerScheme: AuthenticationConstants.JWT_BEARER_SCHEME_AAD,
            configureJwtBearerOptions: options =>
            {
                JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
                configuration.Bind(AuthenticationConstants.JWT_BEARER_CONFIGURATION_OPTIONS_AAD, options);
                options.TokenValidationParameters.NameClaimType = "name";
            },
            configureMicrosoftIdentityOptions: options =>
            {
                JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
                configuration.Bind(AuthenticationConstants.JWT_BEARER_CONFIGURATION_OPTIONS_AAD, options);
            });

        return services;
    }
}
