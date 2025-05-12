using Equipment.Core.Common.ValueObjects;

namespace Equipment.Core.Domain.ValueObjects;

public class SerialNumber : ValueObject
{
    public string Value { get; init; } = default!;

    private SerialNumber() { } // EF Core requires a parameterless constructor for materialization

    public SerialNumber(string value)
    {
        Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}