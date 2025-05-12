using Equipment.Core.Common.Entities;
using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Core.Domain.EquipmentAggregate;

public class Attachment : BaseEntity<AttachmentId>
{
    public EquipmentNumber EquipmentNumber { get; private set; } = default!;
    public string Make { get; private set; } = default!;
    public string Model { get; private set; } = default!;

    #region EF Navigation Properties
    public EquipmentId EquipmentId { get; private set; } = default!; // EF Core requires a foreign key property for navigation properties
    private Attachment() { } // EF Core requires a parameterless constructor for materialization
    #endregion

    public Attachment(
        AttachmentId id,
        EquipmentNumber equipmentNumber,
        string make,
        string model)
    {
        Id = Guard.Against.Null(id, nameof(id));
        EquipmentNumber = Guard.Against.Null(equipmentNumber, nameof(equipmentNumber));
        Make = Guard.Against.NullOrWhiteSpace(make, nameof(make));
        Model = Guard.Against.NullOrWhiteSpace(model, nameof(model));
    }
}
