using Equipment.Core.Common.ValueObjects;

namespace Equipment.Core.Domain.ValueObjects.Common;

public class EmailAddress : ValueObject
{
    public string Value { get; init; } = default!;

    private EmailAddress() { } // EF Core requires a parameterless constructor for materialization

    public EmailAddress(string email)
    {
        Value = Guard.Against.NullOrWhiteSpace(email, nameof(email));

        Guard.Against.InvalidEmailAddress(email);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
