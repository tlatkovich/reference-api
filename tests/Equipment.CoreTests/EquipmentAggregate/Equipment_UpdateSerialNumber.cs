using Equipment.Core.Domain.EquipmentAggregate.Events;
using Equipment.Core.Domain.ValueObjects;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.EquipmentAggregate;

public class Equipment_UpdateSerialNumber : BaseUnitTest
{
    public Equipment_UpdateSerialNumber()
    {
    }

    [Fact]
    public void UpdateSerialNumber_ShouldUpdateSerialNumber()
    {
        // Arrange
        var equipment = EquipmentBuilder.Build();

        var newSerialNumber = new SerialNumber("Serial Number");

        // Act
        equipment.UpdateSerialNumber(newSerialNumber);

        // Assert
        equipment.SerialNumber.ShouldBe(newSerialNumber);

        equipment.DomainEvents.Count().ShouldBe(2);
        equipment.DomainEvents.ElementAt(0).ShouldBeOfType<EquipmentCreatedEvent>();
        equipment.DomainEvents.ElementAt(1).ShouldBeOfType<EquipmenterialNumberChangedEvent>();
    }
}
