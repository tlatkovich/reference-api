using Equipment.Core.Domain.ValueObjects.Common;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects.Common;

public class MailingAddress_Create : BaseUnitTest
{
    private readonly string _addressLine1 = "123 Main St";
    private readonly string _addressLine2 = "Apt 4B";
    private readonly string _poBox = "PO Box 123";
    private readonly string _city = "Springfield";
    private readonly string _state = "IL";
    private readonly string _zipCode = "62701";

    public MailingAddress_Create()
    {
    }

    [Fact]
    public void CreateWithStreet_ShouldCreateMailingAddressWithStreet()
    {
        // Arrange
        var mailingAddress = MailingAddress.CreateWithStreet(_addressLine1, _addressLine2, _city, _state, _zipCode);

        // Act
        var result = mailingAddress;

        // Assert
        result.ShouldNotBe(null);
        result.AddressLine1.ShouldBe(_addressLine1);
        result.AddressLine2.ShouldBe(_addressLine2);
        result.POBox.ShouldBe(null);
        result.City.ShouldBe(_city);
        result.State.ShouldBe(_state);
        result.ZipCode.ShouldBe(_zipCode);
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithStreet_ShouldThrowArgumentException_WhenAddressLine1IsNullOrWhitespace(string invalidAddressLine1)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => MailingAddress.CreateWithStreet(invalidAddressLine1, _addressLine2, _city, _state, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithStreet_ShouldNotThrowArgumentException_WhenAddressLine2IsNullOrWhitespace(string invalidAddressLine2)
    {
        // Act & Assert
        Should.NotThrow(() => MailingAddress.CreateWithStreet(_addressLine1, invalidAddressLine2, _city, _state, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithStreet_ShouldThrowArgumentException_WhenCityIsNullOrWhitespace(string invalidCity)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => MailingAddress.CreateWithStreet(_addressLine1, _addressLine2, invalidCity, _state, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithStreet_ShouldThrowArgumentException_WhenStateIsNullOrWhitespace(string invalidState)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => MailingAddress.CreateWithStreet(_addressLine1, _addressLine2, _city, invalidState, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithStreet_ShouldThrowArgumentException_WhenZipCodeIsNullOrWhitespace(string invalidZipCode)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => MailingAddress.CreateWithStreet(_addressLine1, _addressLine2, _city, _state, invalidZipCode));
    }

    [Fact]
    public void CreateWithPOBox_ShouldCreateMailingAddressWithPOBox()
    {
        // Arrange
        var mailingAddress = MailingAddress.CreateWithPOBox(_poBox, _city, _state, _zipCode);

        // Act
        var result = mailingAddress;

        // Assert
        result.ShouldNotBe(null);
        result.AddressLine1.ShouldBe(null);
        result.AddressLine2.ShouldBe(null);
        result.POBox.ShouldBe(_poBox);
        result.City.ShouldBe(_city);
        result.State.ShouldBe(_state);
        result.ZipCode.ShouldBe(_zipCode);
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithPOBox_ShouldThrowArgumentException_WhenPOBoxIsNullOrWhitespace(string invalidPOBox)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => MailingAddress.CreateWithPOBox(invalidPOBox, _city, _state, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithPOBox_ShouldThrowArgumentException_WhenCityIsNullOrWhitespace(string invalidCity)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => MailingAddress.CreateWithPOBox(_poBox, invalidCity, _state, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithPOBox_ShouldThrowArgumentException_WhenStateIsNullOrWhitespace(string invalidState)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => MailingAddress.CreateWithPOBox(_poBox, _city, invalidState, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void CreateWithPOBox_ShouldThrowArgumentException_WhenZipCodeIsNullOrWhitespace(string invalidZipCode)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => MailingAddress.CreateWithPOBox(_poBox, _city, _state, invalidZipCode));
    }
}
