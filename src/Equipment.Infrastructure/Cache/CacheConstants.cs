namespace Equipment.Infrastructure.Cache;

internal static class CacheConstants
{
    public const int HYBRID_CACHE_MAX_PAYLOAD_BYTES = 1024 * 1024; // 1MB
    public const int HYBRID_CACHE_MAX_KEY_LENGTH = 1024;
    public const int HYBRID_CACHE_DEFAULT_EXPIRATION_IN_SECONDS = 30;
    public const int HYBRID_CACHE_DEFAULT_LOCAL_EXPIRATION_IN_SECONDS = 10;
}
