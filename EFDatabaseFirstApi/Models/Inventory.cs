﻿using System;
using System.Collections.Generic;

namespace EFDatabaseFirstApi.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public string? Location { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual Product Product { get; set; } = null!;
}
