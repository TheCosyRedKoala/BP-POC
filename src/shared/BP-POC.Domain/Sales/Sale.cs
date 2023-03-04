using BP_POC.Domain.Printers;

namespace BP_POC.Domain.Sales;

public class Sale
{
    public DateTime DateOfSale { get; private set; }
    public double TotalAmount { get; }
    public Printer Printer { get; }

    public Sale(double totalAmount, Printer printer)
    {
        TotalAmount = Guard.Against.NegativeOrZero(totalAmount, nameof(totalAmount));
        Printer = Guard.Against.Null(printer, nameof(printer));
        DateOfSale = DateTime.UtcNow;
    }
}
