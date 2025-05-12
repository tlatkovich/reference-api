using Equipment.Core.Domain.ValueObjects;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects;

public class SerialNumber_Constructor : BaseUnitTest
{
    private readonly string _serialNumber = "1234567890";

    public SerialNumber_Constructor()
    {
    }

    [Fact]
    public void Constructor_ShouldCreateSerialNumber()
    {
        // Arrange
        var serialNumber = new SerialNumber(_serialNumber);

        // Act
        var result = serialNumber;

        // Assert
        result.ShouldNotBe(null);
        result.Value.ShouldBe(_serialNumber);
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Constructor_ShouldThrowArgumentException_WhenSerialNumberIsNullOrWhitespace(string invalidEquipmentNumber)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => new SerialNumber(invalidEquipmentNumber));
    }
}
