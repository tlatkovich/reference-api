namespace Equipment.Infrastructure.Cache;

public static partial class InfrastructureServiceCollection
{
    public static IServiceCollection AddInfrastructureCacheServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("redis");
        });

        services.AddHybridCache(options =>
        {
            options.MaximumPayloadBytes = CacheConstants.HYBRID_CACHE_MAX_PAYLOAD_BYTES;
            options.MaximumKeyLength = CacheConstants.HYBRID_CACHE_MAX_KEY_LENGTH;
            options.DefaultEntryOptions = new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromSeconds(CacheConstants.HYBRID_CACHE_DEFAULT_EXPIRATION_IN_SECONDS),
                LocalCacheExpiration = TimeSpan.FromSeconds(CacheConstants.HYBRID_CACHE_DEFAULT_LOCAL_EXPIRATION_IN_SECONDS),
            };
        });

        return services;
    }
}
