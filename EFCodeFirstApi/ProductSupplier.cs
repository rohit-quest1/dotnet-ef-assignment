namespace EFCodeFirstApi
{
    public class ProductSupplier
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!; 

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!; 
    }

    public class ProductSupplierDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
    }
} 