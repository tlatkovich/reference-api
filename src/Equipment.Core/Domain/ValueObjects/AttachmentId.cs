using Equipment.Core.Common.ValueObjects;

namespace Equipment.Core.Domain.ValueObjects;

public class AttachmentId : ValueObject
{
    public Guid Value { get; init; } = default!;

    private AttachmentId() { } // EF Core requires a parameterless constructor for materialization

    public AttachmentId(Guid value)
    {
        Value = Guard.Against.Default(value, nameof(value));
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