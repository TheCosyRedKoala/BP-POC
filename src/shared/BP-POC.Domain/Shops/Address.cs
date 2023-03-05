using BP_POC.Domain.Common;

namespace BP_POC.Domain.Shops;

public class Address : ValueObject
{
    public string AddressLine1 { get; }
    public string? AddressLine2 { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string Country { get; }

    /// <summary>
    /// Domain constructor
    /// </summary>
    /// <param name="addressLine1">The first address line of the address</param>
    /// <param name="addressLine2">The second address line of the address</param>
    /// <param name="city">The city of the address</param>
    /// <param name="postalCode">The postcode of a city of the address</param>
    /// <param name="country">The country of the address</param>
    public Address(string addressLine1, string? addressLine2, string city, string postalCode, string country)
    {
        AddressLine1 = Guard.Against.NullOrWhiteSpace(addressLine1, nameof(addressLine1));
        AddressLine2 = addressLine2;
        City = Guard.Against.NullOrWhiteSpace(city, nameof(city));
        PostalCode = Guard.Against.NullOrWhiteSpace(postalCode, nameof(postalCode));
        Country = Guard.Against.NullOrWhiteSpace(country, nameof(country));
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return AddressLine1;
        yield return AddressLine2;
        yield return City;
        yield return PostalCode;
        yield return Country;
    }
}
