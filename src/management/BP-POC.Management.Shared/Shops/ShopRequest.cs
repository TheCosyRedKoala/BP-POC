using BP_POC.Management.Shared.Printers;
using BP_POC.Management.Shared.Sales;

namespace BP_POC.Management.Shared.Shops;

public static class ShopRequest
{
    public class PrinterMutate
    {
        public int ShopId { get; set; }
        public PrinterDto.Mutate Printer { get; set; } = new();
    }

    public class PrinterDelete
    {
        public int ShopId { get; set; }
        public int PrinterId { get; set; }
    }

    public class SaleMutate
    {
        public int ShopId { get; set; }
        public int PrinterId { get; set; }
        public SaleDto.Mutate Sale { get; set; } = new();
    }

    public class SaleDelete
    {
        public int ShopId { get; set; }
        public int SaleId { get; set; }
    }
}
