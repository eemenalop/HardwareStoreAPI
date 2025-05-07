using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace billingSystem.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal TotalAmount { get; set; }

    public bool IsCanceled { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<InvoicesDetail> InvoicesDetails { get; set; } = new List<InvoicesDetail>();
}
