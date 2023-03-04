using BP_POC.Domain.Printers;
using BP_POC.Domain.Sales;

namespace BP_POC.Domain.Shops;

public class Shop
{
    private List<Sale> _sales = new();
    private List<Printer> _printers = new();

    public string Name { get; private set; }
    public Address Address { get; private set; }

    /// <summary>
    /// Returns the list of sales as an IReadOnlyList
    /// </summary>
    public IReadOnlyList<Sale> Sales => _sales.AsReadOnly();
    /// <summary>
    /// Returns a list of sales that were made today
    /// </summary>
    public IReadOnlyList<Sale> TodaySales => _sales.Where(s => s.DateOfSale.Date == DateTime.UtcNow.Date).ToList().AsReadOnly();
    /// <summary>
    /// Returns the list of printers as an IReadOnlyList
    /// </summary>
    public IReadOnlyList<Printer> Printers => _printers.AsReadOnly();

    /// <summary>
    /// Domain constructor
    /// </summary>
    /// <param name="name">The name of the shop</param>
    /// <param name="address">The address of the shop</param>
    public Shop(string name, Address address)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Address = address;
    }

    /// <summary>
    /// Adds a printer to the list of printers
    /// </summary>
    /// <param name="printer">The printer that should be added</param>
    public void AddPrinter(Printer printer)
    {
        _printers.Add(printer);
    }

    /// <summary>
    /// Removes a printer from the list of printers
    /// </summary>
    /// <param name="printer">The printer that should be removed</param>
    public void RemovePrinter(Printer printer)
    {
        _printers.Remove(printer);
    }

    /// <summary>
    /// Adds a sale to the list of sales
    /// </summary>
    /// <param name="sale">The sale that should be added</param>
    public void AddSale(Sale sale) 
    { 
        _sales.Add(sale);
    }

    /// <summary>
    /// Removes a sale from the list of sales
    /// </summary>
    /// <param name="sale">The sale that should be removed</param>
    public void RemoveSale(Sale sale)
    {
        _sales.Remove(sale);
    }
}
