using System;
using System.Collections.Generic;

namespace billingSystem.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockAvailable { get; set; }

    public virtual ICollection<InvoicesDetail> InvoicesDetails { get; set; } = new List<InvoicesDetail>();
}
