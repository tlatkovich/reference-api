using Equipment.Core.Domain.ValueObjects.Common;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects.Common;

public class PhysicalAddress_Create : BaseUnitTest
{
    private readonly string _addressLine1 = "123 Main St";
    private readonly string _addressLine2 = "Apt 4B";
    private readonly string _city = "Springfield";
    private readonly string _state = "IL";
    private readonly string _zipCode = "62701";

    public PhysicalAddress_Create()
    {
    }

    [Fact]
    public void Create_ShouldCreatePhysicalAddress()
    {
        // Arrange
        var physicalAddress = PhysicalAddress.Create(_addressLine1, _addressLine2, _city, _state, _zipCode);

        // Act
        var result = physicalAddress;

        // Assert
        result.ShouldNotBe(null);
        result.AddressLine1.ShouldBe(_addressLine1);
        result.AddressLine2.ShouldBe(_addressLine2);
        result.City.ShouldBe(_city);
        result.State.ShouldBe(_state);
        result.ZipCode.ShouldBe(_zipCode);
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Create_ShouldThrowArgumentException_WhenAddressLine1IsNullOrWhitespace(string invalidAddressLine1)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => PhysicalAddress.Create(invalidAddressLine1, _addressLine2, _city, _state, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Create_ShouldNotThrowArgumentException_WhenAddressLine2IsNullOrWhitespace(string invalidAddressLine2)
    {
        // Act & Assert
        Should.NotThrow(() => PhysicalAddress.Create(_addressLine1, invalidAddressLine2, _city, _state, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Create_ShouldThrowArgumentException_WhenCityIsNullOrWhitespace(string invalidCity)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => PhysicalAddress.Create(_addressLine1, _addressLine2, invalidCity, _state, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Create_ShouldThrowArgumentException_WhenStateIsNullOrWhitespace(string invalidState)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => PhysicalAddress.Create(_addressLine1, _addressLine2, _city, invalidState, _zipCode));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Create_ShouldThrowArgumentException_WhenZipCodeIsNullOrWhitespace(string invalidZipCode)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => PhysicalAddress.Create(_addressLine1, _addressLine2, _city, _state, invalidZipCode));
    }
}
