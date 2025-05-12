using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.EquipmentAggregate;

public class Attachment_Constructor : BaseUnitTest
{
    public Attachment_Constructor()
    {
    }

    [Fact]
    public void Constructor_ShouldInitalizeProperties()
    {
        // Arrange & Act
        var attachment = AttachmentBuilder.Build();

        // Assert
        attachment.ShouldNotBe(null);
    }
}
