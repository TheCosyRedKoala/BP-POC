﻿using BP_POC.Domain.Common;
using BP_POC.Domain.Printers;

namespace BP_POC.Domain.Sales;

public class Sale : Entity
{
    public DateTime DateOfSale { get; private set; }
    public double TotalAmount { get; private set; }

    /// <summary>
    /// EF constructor
    /// </summary>
    protected Sale()
    {

    }
    /// <summary>
    /// Domain constructor
    /// </summary>
    /// <param name="totalAmount">The total amount payed for the sale</param>
    public Sale(double totalAmount)
    {
        TotalAmount = Guard.Against.NegativeOrZero(totalAmount, nameof(totalAmount));
        DateOfSale = DateTime.UtcNow;
    }
}
