namespace BP_POC.Management.Shared.Printers;

public static class PrinterRequest
{
    public class PriceTierMutate
    {
        public int PrinterId { get; set; }
        public PriceTierDto.Mutate PriceTier { get; set; } = new();
    }
}
