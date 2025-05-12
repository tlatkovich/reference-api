using Equipment.Core.Domain.ValueObjects;

namespace Equipment.CoreTests.Common;

public static class EquipmentBuilder
{
    public static readonly EquipmentId EquipmentId = new(Guid.NewGuid());
    public static readonly EquipmentNumber EquipmentNumber = new(EquipmentAggregateConstants.EquipmentNumber);
    public static readonly EquipmentId EquipmentIsAttachmentId = new(Guid.NewGuid());
    public static readonly EquipmentNumber EquipmentIsAttachmentNumber = new(EquipmentAggregateConstants.EquipmentToAttachNumber);
    // public static readonly EquipmentNumber EquipmentNumberToAttach = new(EquipmentAggregateConstants.AttachmentEquipmentNumber);
    public static readonly string Status = new(EquipmentAggregateConstants.EquipmentStatus);
    public static readonly SerialNumber SerialNumber = new(EquipmentAggregateConstants.EquipmentSerialNumber);
    public static readonly string Make = new(EquipmentAggregateConstants.EquipmentMake);
    public static readonly string Model = new(EquipmentAggregateConstants.EquipmentModel);
    public static readonly int Year = EquipmentAggregateConstants.EquipmentYear;

    public static Core.Domain.EquipmentAggregate.Equipment Build()
    {
        var equipment = Core.Domain.EquipmentAggregate.Equipment.Create(
            EquipmentId,
            false,
            Status,
            SerialNumber,
            Make,
            Model,
            Year);

        // typeof(Core.Domain.EquipmentAggregate.Equipment)
        //     .GetProperty(nameof(Core.Domain.EquipmentAggregate.Equipment.EquipmentNumber))!
        //     .SetValue(equipment, EquipmentNumber);

        return equipment;
    }

    public static Core.Domain.EquipmentAggregate.Equipment BuildToAttach()
    {
        var equipment = Core.Domain.EquipmentAggregate.Equipment.Create(
            EquipmentIsAttachmentId,
            true,
            Status,
            SerialNumber,
            Make,
            Model,
            Year);

        // typeof(Core.Domain.EquipmentAggregate.Equipment)
        //     .GetProperty(nameof(Core.Domain.EquipmentAggregate.Equipment.EquipmentNumber))!
        //     .SetValue(equipment, EquipmentIsAttachmentNumber);

        return equipment;
    }

    // public static Core.Domain.EquipmentAggregate.Equipment BuildWithAttachment(Core.Domain.EquipmentAggregate.Equipment equipmentToAttach)
    // {
    //     var equipment = Core.Domain.EquipmentAggregate.Equipment.Create(
    //         EquipmentId,
    //         false,
    //         Status,
    //         SerialNumber,
    //         Make,
    //         Model,
    //         Year);

    //     // typeof(Core.Domain.EquipmentAggregate.Equipment)
    //     //     .GetProperty(nameof(Core.Domain.EquipmentAggregate.Equipment.EquipmentNumber))!
    //     //     .SetValue(equipment, EquipmentNumber);

    //     equipment.AddAttachment(equipmentToAttach);

    //     return equipment;
    // }
}
