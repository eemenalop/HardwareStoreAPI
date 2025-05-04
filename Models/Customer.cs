﻿using System;
using System.Collections.Generic;

namespace billingSystem.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
