using Equipment.Api.Common.Requests;

namespace Equipment.Api.Endpoints.Equipment.Get;

public record GetEquipmentRequest : BaseRequest
{
    public const string ROUTE = "/equipment/{id}";

    public Guid Id { get; init; }
}
