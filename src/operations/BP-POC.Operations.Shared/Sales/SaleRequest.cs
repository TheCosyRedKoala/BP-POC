namespace BP_POC.Operations.Shared.Sales;

public static class SaleRequest
{
    public class Mutate
    {
        public int ShopId { get; set; }
        public SaleDto.Mutate Sale { get; set; } = new();
    }
}
