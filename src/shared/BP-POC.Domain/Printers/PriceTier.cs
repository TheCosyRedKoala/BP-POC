namespace BP_POC.Domain.Printers;

public class PriceTier
{
    public int Floor { get; private set; }
    public int Ceiling { get; private set; }
    public double Price { get; private set; }

    public PriceTier(int floor, int ceiling, double price)
    {
        Floor = Guard.Against.Negative(floor, nameof(floor));
        Ceiling = Guard.Against.NegativeOrZero(ceiling, nameof(ceiling));
        Price = Guard.Against.NegativeOrZero(price, nameof(price));
    }
}
