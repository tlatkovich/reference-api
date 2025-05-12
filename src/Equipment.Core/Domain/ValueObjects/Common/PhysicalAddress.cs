using Equipment.Core.Common.ValueObjects;

namespace Equipment.Core.Domain.ValueObjects.Common;

public class PhysicalAddress : ValueObject
{
    public string AddressLine1 { get; init; } = default!;
    public string? AddressLine2 { get; init; }
    public string City { get; init; } = default!;
    public string State { get; init; } = default!;
    public string ZipCode { get; init; } = default!;

    private PhysicalAddress() { } // EF Core requires a parameterless constructor for materialization

    private PhysicalAddress(
        string addressLine1,
        string? addressLine2,
        string city,
        string state,
        string zipCode)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public static PhysicalAddress Create(
        string addressLine1,
        string? addressLine2,
        string city,
        string state,
        string zipCode)
    {
        Guard.Against.NullOrWhiteSpace(addressLine1, nameof(addressLine1));
        Guard.Against.NullOrWhiteSpace(city, nameof(city));
        Guard.Against.NullOrWhiteSpace(state, nameof(state));
        Guard.Against.NullOrWhiteSpace(zipCode, nameof(zipCode));

        return new PhysicalAddress(addressLine1, addressLine2, city, state, zipCode);
    }

    public string FullAddress
    {
        get
        {
            var address = new List<string>();

            if (!string.IsNullOrWhiteSpace(AddressLine1))
                address.Add(AddressLine1.Trim());

            if (!string.IsNullOrWhiteSpace(AddressLine2))
                address.Add(AddressLine2.Trim());

            address.Add($"{City.Trim()}, {State.Trim()} {ZipCode.Trim()}");

            return string.Join(Environment.NewLine, address);
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AddressLine1;
        yield return AddressLine2 ?? string.Empty;
        yield return City;
        yield return State;
        yield return ZipCode;
    }
}