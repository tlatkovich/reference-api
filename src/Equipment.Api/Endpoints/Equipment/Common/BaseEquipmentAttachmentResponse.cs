namespace Equipment.Api.Endpoints.Equipment.Common;

public record BaseEquipmentAttachmentResponse
{
    public Guid Id { get; init; }
    public int EquipmentNumber { get; init; } = default!;
    public string Make { get; init; } = default!;
    public string Model { get; init; } = default!;
}
