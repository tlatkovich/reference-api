using Equipment.Core.Domain.ValueObjects.Common;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects.Common;

public class EmailAddress_Constructor : BaseUnitTest
{
    private readonly string _emailAddress = "johndoe@testequipment.com";

    public EmailAddress_Constructor()
    {
    }

    [Fact]
    public void Constructor_ShouldCreateEmailAddress()
    {
        // Arrange
        var emailAddress = new EmailAddress(_emailAddress);

        // Act
        var result = emailAddress;

        // Assert
        result.ShouldNotBe(null);
        result.Value.ShouldBe(_emailAddress);
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Constructor_ShouldThrowArgumentException_WhenEmailAddressIsNullOrWhitespace(string invalidEmailAddress)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => new EmailAddress(invalidEmailAddress));
    }

    [Theory]
    [InlineData("johndoe@testequipment")]
    [InlineData("johndoe@.com")]
    [InlineData("johndoe@com")]
    [InlineData("johndoe.com")]
    [InlineData("@.com")]
    public void Constructor_ShouldThrowValidationException_WhenEmailAddressIsInvalid(string invalidEmailAddress)
    {
        // Act & Assert
        Should.Throw<ValidationException>(() => new EmailAddress(invalidEmailAddress));
    }
}
