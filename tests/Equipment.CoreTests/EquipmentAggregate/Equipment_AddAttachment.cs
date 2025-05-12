using Equipment.Core.Domain.EquipmentAggregate.Events;
using Equipment.Core.Domain.ValueObjects;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.EquipmentAggregate;

public class Equipment_AddAttachment : BaseUnitTest
{
    public Equipment_AddAttachment()
    {
    }

    [Fact]
    public void AddAttachment_ShouldAddAttachment()
    {
        // Arrange
        var equipment = EquipmentBuilder.Build();

        typeof(Core.Domain.EquipmentAggregate.Equipment)
            .GetProperty(nameof(Core.Domain.EquipmentAggregate.Equipment.EquipmentNumber))!
            .SetValue(equipment, new EquipmentNumber(EquipmentAggregateConstants.EquipmentNumber));

        equipment.ClearDomainEvents();

        var equipmentToAttach = EquipmentBuilder.BuildToAttach();

        typeof(Core.Domain.EquipmentAggregate.Equipment)
            .GetProperty(nameof(Core.Domain.EquipmentAggregate.Equipment.EquipmentNumber))!
            .SetValue(equipmentToAttach, new EquipmentNumber(EquipmentAggregateConstants.EquipmentToAttachNumber));

        // Act
        equipment.AddAttachment(equipmentToAttach);

        // Assert
        equipment.Attachments.ShouldNotBeEmpty();
        equipment.Attachments.Count.ShouldBe(1);
        equipment.Attachments.First().EquipmentNumber.ShouldBe(equipmentToAttach.EquipmentNumber);

        equipment.DomainEvents.Count.ShouldBe(1);
        equipment.DomainEvents.First().ShouldBeOfType<EquipmentAttachmentAddedEvent>();
    }
}
