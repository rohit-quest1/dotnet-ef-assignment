﻿using System;
using System.Collections.Generic;

namespace EFDatabaseFirstApi.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactEmail { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
}
