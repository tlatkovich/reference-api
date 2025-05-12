using Equipment.Core.Domain.ValueObjects;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects;

public class AttachmentId_Constructor : BaseUnitTest
{
    private readonly Guid _id = Guid.NewGuid();

    public AttachmentId_Constructor()
    {
    }

    [Fact]
    public void Constructor_ShouldCreateAttachmentId()
    {
        // Arrange
        var id = new AttachmentId(_id);

        // Act
        var result = id;

        // Assert
        result.ShouldNotBe(null);
        result.Value.ShouldBe(_id);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenAttachmentIdIsDefault()
    {
        // Arrange
        var id = Guid.Empty;

        // Act & Assert
        Should.Throw<ArgumentException>(() => new AttachmentId(id));
    }
}
