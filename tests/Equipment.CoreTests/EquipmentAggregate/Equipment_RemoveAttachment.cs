using Equipment.Core.Domain.EquipmentAggregate.Events;
using Equipment.Core.Domain.ValueObjects;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.EquipmentAggregate;

public class Equipment_RemoveAttachment : BaseUnitTest
{
    public Equipment_RemoveAttachment()
    {
    }

    [Fact]
    public void RemoveAttachment_ShouldRemoveAttachment()
    {
        // Arrange
        var equipment = EquipmentBuilder.Build();

        typeof(Core.Domain.EquipmentAggregate.Equipment)
            .GetProperty(nameof(Core.Domain.EquipmentAggregate.Equipment.EquipmentNumber))!
            .SetValue(equipment, new EquipmentNumber(EquipmentAggregateConstants.EquipmentNumber));

        var equipmentToAttach = EquipmentBuilder.BuildToAttach();

        typeof(Core.Domain.EquipmentAggregate.Equipment)
            .GetProperty(nameof(Core.Domain.EquipmentAggregate.Equipment.EquipmentNumber))!
            .SetValue(equipmentToAttach, new EquipmentNumber(EquipmentAggregateConstants.EquipmentToAttachNumber));

        equipment.AddAttachment(equipmentToAttach);

        equipment.ClearDomainEvents();

        var attachment = equipment.Attachments.First();

        // Act
        equipment.RemoveAttachment(attachment);

        // Assert
        equipment.Attachments.ShouldBeEmpty();

        equipment.DomainEvents.Count.ShouldBe(1);
        equipment.DomainEvents.First().ShouldBeOfType<EquipmentAttachmentRemovedEvent>();
    }
}
