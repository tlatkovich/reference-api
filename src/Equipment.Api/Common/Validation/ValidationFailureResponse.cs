namespace Equipment.Api.Common.Validation;

public class ValidationFailureResponse
{
    public string CorrelationId { get; init; } = default!;

    public List<string> Errors { get; init; } = [];
}
