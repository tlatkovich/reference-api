using Equipment.Api.Common.Requests;

namespace Equipment.Api.Endpoints.Equipment.Delete;

public record DeleteEquipmentRequest : BaseRequest
{
    public const string ROUTE = "/equipment/{id}";

    public Guid Id { get; init; }
}
