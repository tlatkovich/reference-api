namespace Equipment.Api.Common;

internal static class WebApiConstants
{
    /***************************************************************************/
    // Authentication & Authorization constants
    /***************************************************************************/
    public const string JWT_BEARER_CONFIGURATION_OPTIONS_AAD = "AzureAd";
    public const string JWT_BEARER_SCHEME_AAD = "AAD";
    public const string JWT_BEARER_SCHEME_ANONYMOUS = "Anonymous";

    /***************************************************************************/
    // HTTP Header constants
    /***************************************************************************/
    public const string X_CORRELATION_ID = "X-Correlation-Id";
}
