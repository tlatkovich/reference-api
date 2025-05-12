using Equipment.Core.Domain.ValueObjects;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects;

public class EquipmentId_Constructor : BaseUnitTest
{
    private readonly Guid _id = Guid.NewGuid();

    public EquipmentId_Constructor()
    {
    }

    [Fact]
    public void Constructor_ShouldCreateEquipmentId()
    {
        // Arrange
        var id = new EquipmentId(_id);

        // Act
        var result = id;

        // Assert
        result.ShouldNotBe(null);
        result.Value.ShouldBe(_id);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenEquipmentIdIsDefault()
    {
        // Arrange
        var id = Guid.Empty;

        // Act & Assert
        Should.Throw<ArgumentException>(() => new EquipmentId(id));
    }
}
