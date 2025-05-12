using Equipment.Core.Domain.ValueObjects;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects;

public class EquipmentNumber_Constructor : BaseUnitTest
{
    private readonly int _equipmentNumber = 10000000;

    public EquipmentNumber_Constructor()
    {
    }

    [Fact]
    public void Constructor_ShouldCreateEquipmentNumber()
    {
        // Arrange
        var equipmentNumber = new EquipmentNumber(_equipmentNumber);

        // Act
        var result = equipmentNumber;

        // Assert
        result.ShouldNotBe(null);
        result.Value.ShouldBe(_equipmentNumber);
    }

    [Theory]
    [MemberData(nameof(NegativeOrZeroIntegers))]
    public void Constructor_ShouldThrowArgumentException_WhenEquipmentNumberIsNegativeOrZero(int invalidEquipmentNumber)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => new EquipmentNumber(invalidEquipmentNumber));
    }
}
