using BP_POC.Management.Shared.Printers;

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
}
