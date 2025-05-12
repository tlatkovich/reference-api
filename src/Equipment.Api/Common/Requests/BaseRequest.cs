namespace Equipment.Api.Common.Requests;

public abstract record BaseRequest
{
    public const string CORRELATION_ID_PROPERTY_NAME = "CorrelationId";
    public Guid CorrelationId { get; set; }
}