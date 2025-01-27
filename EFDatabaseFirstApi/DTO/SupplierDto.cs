namespace EFDatabaseFirstApi.DTO
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = null!;
        public string? ContactEmail { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
} 