using Equipment.Api.Common.Requests;

namespace Equipment.Api.Endpoints.Equipment.Create;

/// <summary>
/// Request model for creating a new equipment.
/// </summary>
public record CreateEquipmentRequest : BaseRequest
{
    public const string ROUTE = "/equipment";

    public bool IsAttachment { get; init; } = default!;
    public string Status { get; init; } = default!;
    public string SerialNumber { get; init; } = default!;
    public string Make { get; init; } = default!;
    public string Model { get; init; } = default!;
    public int Year { get; init; } = default!;
}
