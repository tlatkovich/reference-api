namespace Equipment.Api.Endpoints.Equipment.Get;

public record EquipmentAttachmentResponse
{
    public Guid Id { get; init; }
    public int EquipmentNumber { get; init; } = default!;
    public string Make { get; init; } = default!;
    public string Model { get; init; } = default!;
}