using System;
using System.Collections.Generic;

namespace EFDatabaseFirstApi.Models;

public partial class ProductSupplier
{
    public int ProductId { get; set; }

    public int SupplierId { get; set; }

    public decimal? SupplyPrice { get; set; }

    public DateTime? LastSupplyDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
