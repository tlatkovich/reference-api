using Equipment.Api.Common.Responses;

namespace Equipment.Api.Endpoints.Equipment.Common;

public record BaseEquipmentResponse : BaseResponse
{
    public Guid Id { get; init; }
    public int EquipmentNumber { get; init; } = default!;
    public bool IsAttachment { get; init; }
    public string Status { get; init; } = default!;
    public string SerialNumber { get; init; } = default!;
    public string Make { get; init; } = default!;
    public string Model { get; init; } = default!;
    public int Year { get; init; }
}
