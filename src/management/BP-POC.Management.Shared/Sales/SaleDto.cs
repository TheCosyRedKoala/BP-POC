using BP_POC.Management.Shared.Printers;

namespace BP_POC.Management.Shared.Sales;

public static class SaleDto
{
    public class Index
    {
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public double TotalAmound { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public double TotalAmound { get; set; }
        public PrinterDto.Index Printer { get; set; } = new();
    }

    public class Mutate
    {
        public DateTime DateOfSale { get; set; }
        public double TotalAmound { get; set; }
    }
}
