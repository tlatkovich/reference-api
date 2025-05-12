using Equipment.Core.Domain.EquipmentAggregate.Events;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.EquipmentAggregate;

public class Equipment_Create : BaseUnitTest
{
    public Equipment_Create()
    {
    }

    [Fact]
    public void Create_ShouldReturnEquipment()
    {
        // Arrange & Act
        var equipment = EquipmentBuilder.Build();

        // Assert
        equipment.ShouldNotBe(null);
        equipment.Attachments.ShouldBeEmpty();
        equipment.DomainEvents.Count.ShouldBe(1);
        equipment.DomainEvents.First().ShouldBeOfType<EquipmentCreatedEvent>();
    }
}
