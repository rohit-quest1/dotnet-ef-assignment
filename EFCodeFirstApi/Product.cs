using EFCodeFirstApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstApi
{
    [Index(nameof(Name))]
    public class Product
    {
        public int ProductId { get; set; }
       
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public DateTime? LastRestocked { get; set; }

        public Category? Category { get; set; }
        public ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
   
    }
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
