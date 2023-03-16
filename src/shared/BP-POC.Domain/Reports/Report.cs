using BP_POC.Domain.Common;
using FluentDateTime;

namespace BP_POC.Domain.Reports;

public class Report : Entity
{
    public DateTime DayOfSale { get; set; }
    public double TotalRevenue { get; set; }
    public int ShopId { get; set; }

    protected Report() { }

    public Report(DateTime dayOfSale, double totalRevenue, int shopId)
    {
        DayOfSale = Guard.Against.OutOfRange(dayOfSale, nameof(dayOfSale), DateTime.UtcNow.BeginningOfDay(), DateTime.UtcNow.EndOfDay());
        TotalRevenue = Guard.Against.Negative(totalRevenue, nameof(totalRevenue));
        ShopId = Guard.Against.NegativeOrZero(shopId, nameof(shopId));
    }
}
