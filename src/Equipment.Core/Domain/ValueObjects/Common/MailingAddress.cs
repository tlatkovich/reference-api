using Equipment.Core.Common.ValueObjects;

namespace Equipment.Core.Domain.ValueObjects.Common;

public class MailingAddress : ValueObject
{
    public string? AddressLine1 { get; init; }
    public string? AddressLine2 { get; init; }
    public string? POBox { get; init; }
    public string City { get; init; } = default!;
    public string State { get; init; } = default!;
    public string ZipCode { get; init; } = default!;

    private MailingAddress() { } // EF Core requires a parameterless constructor for materialization

    private MailingAddress(
        string? addressLine1,
        string? addressLine2,
        string? poBox,
        string city,
        string state,
        string zipCode)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        POBox = poBox;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public static MailingAddress CreateWithStreet(
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

        return new MailingAddress(addressLine1, addressLine2, null, city, state, zipCode);
    }

    public static MailingAddress CreateWithPOBox(
        string poBox,
        string city,
        string state,
        string zipCode)
    {
        Guard.Against.NullOrWhiteSpace(poBox, nameof(poBox));
        Guard.Against.NullOrWhiteSpace(city, nameof(city));
        Guard.Against.NullOrWhiteSpace(state, nameof(state));
        Guard.Against.NullOrWhiteSpace(zipCode, nameof(zipCode));

        return new MailingAddress(null, null, poBox, city, state, zipCode);
    }

    public string FullAddressWithStreet
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
    public string FullAddressWithPOBox
    {
        get
        {
            var address = new List<string>();

            if (!string.IsNullOrWhiteSpace(POBox))
                address.Add($"P.O. Box {POBox.Trim()}");

            address.Add($"{City.Trim()}, {State.Trim()} {ZipCode.Trim()}");

            return string.Join(Environment.NewLine, address);
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AddressLine1 ?? string.Empty;
        yield return AddressLine2 ?? string.Empty;
        yield return POBox ?? string.Empty;
        yield return City;
        yield return State;
        yield return ZipCode;
    }
}