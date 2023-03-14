using BP_POC.Operations.Shared.Printers;

namespace BP_POC.Operations.Shared.Sales;

public static class SaleDto
{
    public class CalculatedSale
    {
        public int PrinterId { get; set; }
        public string PrinterName { get; set; } = default!;
        public int AmountPrinted { get; set; }
        public double ActivePriceTierPrice { get; set; }
        public double TotalAmount { get; set; }
    }

    public class Index
    {
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public double TotalAmount { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public double TotalAmount { get; set; }
        public PrinterDto.Index Printer { get; set; } = new();
    }

    public class Mutate
    {
        public double TotalAmount { get; set; }
    }
}
