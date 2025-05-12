using Equipment.Core.Common.ValueObjects;

namespace Equipment.Core.Domain.ValueObjects.Common;

public class PersonName : ValueObject
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;

    private PersonName() { } // EF Core requires a parameterless constructor for materialization

    public PersonName(string firstName, string lastName)
    {
        FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        LastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
    }

    public string FullName => $"{FirstName.Trim()} {LastName.Trim()}";
    public string ReverseName => $"{LastName.Trim()}, {FirstName.Trim()}";
    public string SingleInitials => $"{FirstName.SingleOrDefault()}{LastName.SingleOrDefault()}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}