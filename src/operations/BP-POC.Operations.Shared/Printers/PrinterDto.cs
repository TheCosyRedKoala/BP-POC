namespace BP_POC.Operations.Shared.Printers;

public static class PrinterDto
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
        public int ListeningInterface { get; set; }
        public List<PriceTierDto.Index> PriceTiers { get; set; } = new();
    }
}