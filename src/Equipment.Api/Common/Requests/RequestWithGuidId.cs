namespace Equipment.Api.Common.Requests;

public abstract record RequestWithGuidId : BaseRequest
{
    public Guid Id { get; init; }
}
