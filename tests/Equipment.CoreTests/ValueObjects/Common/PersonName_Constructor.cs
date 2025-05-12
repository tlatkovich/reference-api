using Equipment.Core.Domain.ValueObjects.Common;
using Equipment.CoreTests.Common;

namespace Equipment.CoreTests.ValueObjects.Common;

public class PersonName_Constructor : BaseUnitTest
{
    private readonly string _firstName = "John";
    private readonly string _lastName = "Doe";

    public PersonName_Constructor()
    {
    }

    [Fact]
    public void Constructor_ShouldCreatePersonName()
    {
        // Arrange
        var personName = new PersonName(_firstName, _lastName);

        // Act
        var result = personName;

        // Assert
        result.ShouldNotBe(null);
        result.FirstName.ShouldBe(_firstName);
        result.LastName.ShouldBe(_lastName);
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Constructor_ShouldThrowArgumentException_WhenFirstNameIsInvalid(string invalidFirstName)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => new PersonName(invalidFirstName, _lastName));
    }

    [Theory]
    [MemberData(nameof(NullOrWhitespaceStrings))]
    public void Constructor_ShouldThrowArgumentException_WhenLastNameIsInvalid(string invalidLastName)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => new PersonName(_firstName, invalidLastName));
    }
}
