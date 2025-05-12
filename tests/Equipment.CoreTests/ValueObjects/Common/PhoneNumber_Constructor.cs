using Equipment.Core.Domain.ValueObjects.Common;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects.Common;

public class PhoneNumber_Constructor : BaseUnitTest
{
    private readonly string _phoneNumber = "2258025200";

    public PhoneNumber_Constructor()
    {
    }

    [Fact]
    public void Constructor_ShouldCreatePhoneNumber()
    {
        // Arrange
        var phoneNumber = new PhoneNumber(_phoneNumber);

        // Act
        var result = phoneNumber;

        // Assert
        result.ShouldNotBe(null);
        result.Value.ShouldBe(_phoneNumber);
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Constructor_ShouldThrowArgumentException_WhenPhoneNumberIsNullOrWhitespace(string invalidphoneNumber)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => new PhoneNumber(invalidphoneNumber));
    }

    [Theory]
    [InlineData("12252985200")]
    [InlineData("1225298")]
    [InlineData("12985200")]
    [InlineData("225298")]
    [InlineData("2985200")]
    public void Constructor_ShouldThrowValidationException_WhenPhoneNumberIsInvalid(string invalidphoneNumber)
    {
        // Act & Assert
        Should.Throw<ValidationException>(() => new EmailAddress(invalidphoneNumber));
    }
}
