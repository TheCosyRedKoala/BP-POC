namespace BP_POC.Domain.Shops;

public class Address
{
    public string AddressLine1 { get; }
    public string? AddressLine2 { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string Country { get; }

    public Address(string addressLine1, string? addressLine2, string city, string postalCode, string country)
    {
        AddressLine1 = Guard.Against.NullOrWhiteSpace(addressLine1, nameof(addressLine1));
        AddressLine2 = addressLine2;
        City = Guard.Against.NullOrWhiteSpace(city, nameof(city));
        PostalCode = Guard.Against.NullOrWhiteSpace(postalCode, nameof(postalCode));
        Country = Guard.Against.NullOrWhiteSpace(country, nameof(country));
    }
}
