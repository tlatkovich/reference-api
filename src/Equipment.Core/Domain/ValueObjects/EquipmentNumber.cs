using Equipment.Core.Common.ValueObjects;

namespace Equipment.Core.Domain.ValueObjects;

public class EquipmentNumber : ValueObject
{
    public int Value { get; init; }

    private EquipmentNumber() { } // EF Core requires a parameterless constructor for materialization

    public EquipmentNumber(int value)
    {
        Value = Guard.Against.NegativeOrZero(value, nameof(value));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}