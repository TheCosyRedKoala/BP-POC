using BP_POC.Domain.Common;

namespace BP_POC.Domain.Printers;

public class PriceTier : ValueObject
{
    public int Floor { get; private set; }
    public int Ceiling { get; private set; }
    public double Price { get; private set; }

    /// <summary>
    /// Domain constructor
    /// </summary>
    /// <param name="floor">The inclusive floor of the price tier</param>
    /// <param name="ceiling">The inclusive ceiling of the price tier</param>
    /// <param name="price">The price of the price tier</param>
    public PriceTier(int floor, int ceiling, double price)
    {
        Floor = Guard.Against.Negative(floor, nameof(floor));
        Ceiling = Guard.Against.NegativeOrZero(ceiling, nameof(ceiling));
        Price = Guard.Against.NegativeOrZero(price, nameof(price));
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Floor;
        yield return Ceiling;
        yield return Price;
    }
}
