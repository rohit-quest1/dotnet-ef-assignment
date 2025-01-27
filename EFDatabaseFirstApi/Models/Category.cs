using System;
using System.Collections.Generic;

namespace EFDatabaseFirstApi.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastModified { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
