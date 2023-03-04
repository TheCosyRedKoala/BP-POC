namespace BP_POC.Domain.Printers;

public class Printer
{
    private List<PriceTier> _priceTiers = new();

    public string Name { get; private set; }
    public int ListeningInterface { get; private set; }
    
    /// <summary>
    /// Returns the list of price tiers as an IReadOnlyList
    /// </summary>
    public IReadOnlyList<PriceTier> PriceTiers => _priceTiers.AsReadOnly();

    /// <summary>
    /// Domain constructor
    /// </summary>
    /// <param name="name"></param>
    /// <param name="listeningInterface"></param>
    public Printer(string name, int listeningInterface)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        ListeningInterface = Guard.Against.Negative(listeningInterface, nameof(listeningInterface));
    }

    /// <summary>
    /// Adds a price tier to the list of price tiers
    /// </summary>
    /// <param name="priceTier">The price tier that should be added</param>
    public void AddPriceTier(PriceTier priceTier)
    {
        _priceTiers.Add(priceTier);
    }

    /// <summary>
    /// Removes a price tier from the list of price tiers
    /// </summary>
    /// <param name="priceTier">The price tier that should be removed</param>
    public void RemovePriceTier(PriceTier priceTier) 
    { 
        _priceTiers.Remove(priceTier);
    }

    /// <summary>
    /// Calculates the amount to be payed based on the printed amount
    /// </summary>
    /// <param name="amountPrinted">The amount printed by the customer</param>
    /// <returns>The amount to be payed</returns>
    /// <exception cref="Exception"></exception>
    public double CalculateTotalAmount(int amountPrinted)
    {
        PriceTier? activePriceTier = _priceTiers.FirstOrDefault(pt => amountPrinted >= pt.Floor && amountPrinted <= pt.Ceiling);

        if (activePriceTier is null)
        {
            // TODO: Implement custom exception
            throw new Exception();
        }

        return amountPrinted * activePriceTier.Price;
    }
}
