using Equipment.Core.Common.ValueObjects;

namespace Equipment.Core.Domain.ValueObjects.Common;

public class PhoneNumber : ValueObject
{
    public string Value { get; init; } = default!;

    private PhoneNumber() { } // EF Core requires a parameterless constructor for materialization

    public PhoneNumber(string phoneNumber)
    {
        Value = Guard.Against.NullOrWhiteSpace(phoneNumber, nameof(phoneNumber));
        Guard.Against.InvalidPhoneNumber(phoneNumber);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
