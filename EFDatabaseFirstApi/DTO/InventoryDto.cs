namespace EFDatabaseFirstApi.DTO
{
    public class InventoryDto
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Location { get; set; }
    }
} 