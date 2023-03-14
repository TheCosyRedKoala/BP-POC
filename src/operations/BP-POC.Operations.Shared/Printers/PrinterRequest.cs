namespace BP_POC.Operations.Shared.Printers;

public static class PrinterRequest
{
    public class CalculateTotalAmount
    {
        public int PrinterId { get; set; }
        public int AmountPrinted { get; set; }
    }
}
