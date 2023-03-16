namespace BP_POC.Reporting.Shared.Reports;

public static class ReportDto
{
    public class Index
    {
        public int Id { get; set; }
        public DateTime DayOfSale { get; set; }
        public double TotalRevenue { get; set; }
        public int ShopId { get; set; }
    }

    public class Mutate
    {
        public DateTime DayOfSale { get; set; }
        public double TotalRevenue { get; set; }
        public int ShopId { get; set; }
    }
}
