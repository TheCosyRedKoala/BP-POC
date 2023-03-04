using BP_POC.Domain.Printers;
using BP_POC.Domain.Sales;

namespace BP_POC.Domain.Shops;

public class Shop
{
    private List<Sale> _sales = new();
    private List<Printer> _printers = new();

    public string Name { get; private set; }
    public Address Address { get; private set; }

    public IReadOnlyList<Sale> Sales => _sales.AsReadOnly();
    public IReadOnlyList<Printer> Printers => _printers.AsReadOnly();

    public Shop(string name, Address address)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Address = address;
    }

    public void AddPrinter(Printer printer)
    {
        _printers.Add(printer);
    }

    public void RemovePrinter(Printer printer)
    {
        _printers.Remove(printer);
    }

    public void AddSale(Sale sale) 
    { 
        _sales.Add(sale);
    }

    public void RemoveSale(Sale sale)
    {
        _sales.Remove(sale);
    }
}
