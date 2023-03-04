using BP_POC.Management.Shared.Printers;
using BP_POC.Management.Shared.Sales;

namespace BP_POC.Management.Shared.Shops;

public static class ShopDto
{
    public class Index
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }

    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public AddressDto.Index Address { get; set; } = new();
        public List<SaleDto.Index> Sales { get; set; } = new();
        public List<PrinterDto.Index> Printers { get; set; } = new();
    }

    public class Mutate
    {
        public string Name { get; set; }
        public AddressDto.Mutate Address { get; set; } = new();
    }
}
