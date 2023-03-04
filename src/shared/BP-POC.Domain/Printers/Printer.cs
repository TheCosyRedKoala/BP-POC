namespace BP_POC.Domain.Printers;

public class Printer
{
    private List<PriceTier> _priceTiers = new();

    public string Name { get; private set; }
    public int ListeningInterface { get; private set; }
    
    public IReadOnlyList<PriceTier> PriceTiers => _priceTiers.AsReadOnly();

    public Printer(string name, int listeningInterface)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        ListeningInterface = Guard.Against.Negative(listeningInterface, nameof(listeningInterface));
    }

    public void AddPriceTier(PriceTier priceTier)
    {
        _priceTiers.Add(priceTier);
    }

    public void RemovePriceTier(PriceTier priceTier) 
    { 
        _priceTiers.Remove(priceTier);
    }

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
