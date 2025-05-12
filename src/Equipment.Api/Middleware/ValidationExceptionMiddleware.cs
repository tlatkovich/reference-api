using Equipment.Api.Common;
using Equipment.Api.Common.Validation;
using Ardalis.GuardClauses;

namespace Equipment.Api.Middleware;

public class ValidationExceptionMiddleware(RequestDelegate request)
{
    private readonly RequestDelegate _request = Guard.Against.Null(request, nameof(request));

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (ValidationException exception)
        {
            var correlationId = context.Request.Headers[WebApiConstants.X_CORRELATION_ID].FirstOrDefault() ?? Guid.NewGuid().ToString();
            var messages = exception.Errors.Select(x => x.ErrorMessage).ToList();

            var validationFailureResponse = new ValidationFailureResponse
            {
                CorrelationId = correlationId,
                Errors = messages
            };

            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
    }
}
