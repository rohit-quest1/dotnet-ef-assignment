using Microsoft.EntityFrameworkCore;
using EFCodeFirstApi.Models;

namespace EFCodeFirstApi.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Clothing" },
                new Category { CategoryId = 3, Name = "Home & Kitchen" },
                new Category { CategoryId = 4, Name = "Books" },
                new Category { CategoryId = 5, Name = "Toys" }
            );

            // Seeding Suppliers
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, Name = "Supplier A", ContactEmail = "supplierA@example.com", Phone = 1234567890 },
                new Supplier { SupplierId = 2, Name = "Supplier B", ContactEmail = "supplierB@example.com", Phone = 1234567891 },
                new Supplier { SupplierId = 3, Name = "Supplier C", ContactEmail = "supplierC@example.com", Phone = 1234567892 },
                new Supplier { SupplierId = 4, Name = "Supplier D", ContactEmail = "supplierD@example.com", Phone = 1234567893 },
                new Supplier { SupplierId = 5, Name = "Supplier E", ContactEmail = "supplierE@example.com", Phone = 1234567894 },
                new Supplier { SupplierId = 6, Name = "Supplier F", ContactEmail = "supplierF@example.com", Phone = 1234567895 },
                new Supplier { SupplierId = 7, Name = "Supplier G", ContactEmail = "supplierG@example.com", Phone = 1234567896 },
                new Supplier { SupplierId = 8, Name = "Supplier H", ContactEmail = "supplierH@example.com", Phone = 1234567897 },
                new Supplier { SupplierId = 9, Name = "Supplier I", ContactEmail = "supplierI@example.com", Phone = 1234567898 },
                new Supplier { SupplierId = 10, Name = "Supplier J", ContactEmail = "supplierJ@example.com", Phone = 1234567899 }
            );

            // Seeding Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, CategoryId = 1, Stock = 50 },
                new Product { ProductId = 2, Name = "Laptop", Description = "High performance laptop", Price = 999.99m, CategoryId = 1, Stock = 30 },
                new Product { ProductId = 3, Name = "T-Shirt", Description = "Cotton T-Shirt", Price = 19.99m, CategoryId = 2, Stock = 100 },
                new Product { ProductId = 4, Name = "Jeans", Description = "Denim jeans", Price = 49.99m, CategoryId = 2, Stock = 80 },
                new Product { ProductId = 5, Name = "Blender", Description = "High-speed blender", Price = 89.99m, CategoryId = 3, Stock = 40 },
                new Product { ProductId = 6, Name = "Cookbook", Description = "Delicious recipes", Price = 24.99m, CategoryId = 4, Stock = 60 },
                new Product { ProductId = 7, Name = "Action Figure", Description = "Collectible action figure", Price = 14.99m, CategoryId = 5, Stock = 200 },
                new Product { ProductId = 8, Name = "Wireless Headphones", Description = "Noise-cancelling headphones", Price = 199.99m, CategoryId = 1, Stock = 25 },
                new Product { ProductId = 9, Name = "Gaming Console", Description = "Next-gen gaming console", Price = 499.99m, CategoryId = 1, Stock = 15 },
                new Product { ProductId = 10, Name = "Sweater", Description = "Warm sweater", Price = 39.99m, CategoryId = 2, Stock = 70 },
                new Product { ProductId = 11, Name = "Microwave", Description = "Compact microwave", Price = 129.99m, CategoryId = 3, Stock = 35 },
                new Product { ProductId = 12, Name = "Novel", Description = "Bestselling novel", Price = 15.99m, CategoryId = 4, Stock = 90 },
                new Product { ProductId = 13, Name = "Puzzle", Description = "1000-piece puzzle", Price = 19.99m, CategoryId = 5, Stock = 150 },
                new Product { ProductId = 14, Name = "Smartwatch", Description = "Fitness smartwatch", Price = 249.99m, CategoryId = 1, Stock = 20 },
                new Product { ProductId = 15, Name = "Jacket", Description = "Winter jacket", Price = 89.99m, CategoryId = 2, Stock = 40 },
                new Product { ProductId = 16, Name = "Coffee Maker", Description = "Automatic coffee maker", Price = 79.99m, CategoryId = 3, Stock = 30 },
                new Product { ProductId = 17, Name = "Biography", Description = "Inspirational biography", Price = 22.99m, CategoryId = 4, Stock = 50 },
                new Product { ProductId = 18, Name = "Board Game", Description = "Fun board game", Price = 29.99m, CategoryId = 5, Stock = 60 },
                new Product { ProductId = 19, Name = "Tablet", Description = "Portable tablet", Price = 299.99m, CategoryId = 1, Stock = 25 },
                new Product { ProductId = 20, Name = "Shorts", Description = "Comfortable shorts", Price = 24.99m, CategoryId = 2, Stock = 80 }
            );

            // Seeding ProductSupplier relationships
            modelBuilder.Entity<ProductSupplier>().HasData(
                new ProductSupplier { Id = 1, ProductId = 1, SupplierId = 1 },
                new ProductSupplier { Id = 2, ProductId = 2, SupplierId = 2 },
                new ProductSupplier { Id = 3, ProductId = 3, SupplierId = 3 },
                new ProductSupplier { Id = 4, ProductId = 4, SupplierId = 4 },
                new ProductSupplier { Id = 5, ProductId = 5, SupplierId = 5 },
                new ProductSupplier { Id = 6, ProductId = 6, SupplierId = 6 },
                new ProductSupplier { Id = 7, ProductId = 7, SupplierId = 7 },
                new ProductSupplier { Id = 8, ProductId = 8, SupplierId = 8 },
                new ProductSupplier { Id = 9, ProductId = 9, SupplierId = 9 },
                new ProductSupplier { Id = 10, ProductId = 10, SupplierId = 10 }
            );
        }
    }
}