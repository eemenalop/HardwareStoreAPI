using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace billingSystem.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockAvailable { get; set; }
    [JsonIgnore]
    public virtual ICollection<InvoicesDetail> InvoicesDetails { get; set; } = new List<InvoicesDetail>();
}
