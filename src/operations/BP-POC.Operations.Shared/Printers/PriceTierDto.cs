namespace BP_POC.Operations.Shared.Printers;

public static class PriceTierDto
{
    public class Index
    {
        public int Floor { get; set; }
        public int Ceiling { get; set; }
        public double Price { get; set; }
    }
}