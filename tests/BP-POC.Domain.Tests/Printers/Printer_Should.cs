using BP_POC.Domain.Printers;

namespace BP_POC.Domain.Tests.Printers;

public class Printer_Should
{
    private Printer _printer;

    public Printer_Should()
    {
        _printer = new("Ricoh Color Printer 5000", 1);

        PriceTier priceTier1 = new(0, 50, 1.00);
        PriceTier priceTier2 = new(51, 100, 0.75);
        PriceTier priceTier3 = new(101, 200, 0.50);
        PriceTier priceTier4 = new(201, 500, 0.25);

        _printer.AddPriceTier(priceTier1);
        _printer.AddPriceTier(priceTier2);
        _printer.AddPriceTier(priceTier3);
        _printer.AddPriceTier(priceTier4);
    }

    [Fact]
    public void Calculate_the_correct_amount_to_be_payed()
    {
        int amountPrinted = 150;

        double amountToBePayed = _printer.CalculateTotalAmount(amountPrinted);

        Assert.Equal((150 * 0.50), amountToBePayed);
    }

    [Fact]
    public void Select_the_correct_tier_when_using_an_edgecase()
    {
        int amountPrinted = 51;

        double amountToBePayed = _printer.CalculateTotalAmount(amountPrinted);

        Assert.Equal((51 * 0.75), amountToBePayed);
    }

    [Fact]
    public void Throw_exception_when_tier_not_found()
    {
        Action action = () =>
        {
            _printer.CalculateTotalAmount(501);
        };

        Assert.Throws<Exception>(() => action());
    }
}
