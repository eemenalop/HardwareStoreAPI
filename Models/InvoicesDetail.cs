using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace billingSystem.Models;

public partial class InvoicesDetail
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }
    [JsonIgnore]
    public virtual Invoice Invoice { get; set; } = null!;
    [JsonIgnore]
    public virtual Item Item { get; set; } = null!;
}
