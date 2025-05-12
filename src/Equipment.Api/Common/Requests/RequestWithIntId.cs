namespace Equipment.Api.Common.Requests;

public abstract record RequestWithIntId : BaseRequest
{
    public int Id { get; init; }
}
