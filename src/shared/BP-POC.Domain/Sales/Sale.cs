using BP_POC.Domain.Printers;

namespace BP_POC.Domain.Sales;

public class Sale
{
    public DateTime DateOfSale { get; private set; }
    public double TotalAmount { get; }
    public Printer Printer { get; }

    /// <summary>
    /// Domain constructor
    /// </summary>
    /// <param name="totalAmount">The total amount payed for the sale</param>
    /// <param name="printer">The printer responsible for the sale</param>
    public Sale(double totalAmount, Printer printer)
    {
        TotalAmount = Guard.Against.NegativeOrZero(totalAmount, nameof(totalAmount));
        Printer = Guard.Against.Null(printer, nameof(printer));
        DateOfSale = DateTime.UtcNow;
    }
}
