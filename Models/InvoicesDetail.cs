using System;
using System.Collections.Generic;

namespace billingSystem.Models;

public partial class InvoicesDetail
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
