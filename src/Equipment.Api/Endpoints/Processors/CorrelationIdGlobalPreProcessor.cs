using Equipment.Api.Common;
using Equipment.Api.Common.Requests;

namespace Equipment.Api.Endpoints.Processors;

public class CorrelationIdGlobalPreProcessor : IGlobalPreProcessor
{
    /// <summary>
    /// Pre-processes the request to set the CorrelationId property.
    /// </summary>
    /// <param name="preProcessorContext">The context for the pre-processor.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public Task PreProcessAsync(IPreProcessorContext preProcessorContext, CancellationToken cancellationToken)
    {
        if (preProcessorContext.Request is not BaseRequest baseRequest)
        {
            return Task.CompletedTask;
        }

        var httpContext = preProcessorContext.HttpContext;
        var correlationId = GetCorrelationIdFromHeader(httpContext) ?? Guid.NewGuid();

        var correlationProp = typeof(BaseRequest).GetProperty(BaseRequest.CORRELATION_ID_PROPERTY_NAME);
        if (correlationProp?.CanWrite == true)
        {
            correlationProp.SetValue(baseRequest, correlationId);
        }

        httpContext.Response.Headers[WebApiConstants.X_CORRELATION_ID] = correlationId.ToString();

        return Task.CompletedTask;
    }

    /// <summary>
    /// Retrieves the CorrelationId from the request header if available.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <returns>The parsed CorrelationId or null if not found.</returns>
    private static Guid? GetCorrelationIdFromHeader(HttpContext httpContext)
    {
        if (httpContext.Request.Headers.TryGetValue(WebApiConstants.X_CORRELATION_ID, out var headerVal))
        {
            var correlationIdHeader = headerVal.ToString();
            if (Guid.TryParse(correlationIdHeader, out var parsedGuid))
            {
                return parsedGuid;
            }
        }

        return null;
    }
}