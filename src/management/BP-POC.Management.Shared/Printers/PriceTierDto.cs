namespace BP_POC.Management.Shared.Printers;

public static class PriceTierDto
{
    public class Index
    {
        public int Floor { get; set; }
        public int Ceiling { get; set; }
        public double Price { get; set; }
    }

    public class Mutate
    {
        public int Floor { get; set; }
        public int Ceiling { get; set; }
        public double Price { get; set; }
    }
}