using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCodeFirstApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Home & Kitchen" },
                    { 4, "Books" },
                    { 5, "Toys" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "ContactEmail", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "supplierA@example.com", "Supplier A", 1234567890 },
                    { 2, "supplierB@example.com", "Supplier B", 1234567891 },
                    { 3, "supplierC@example.com", "Supplier C", 1234567892 },
                    { 4, "supplierD@example.com", "Supplier D", 1234567893 },
                    { 5, "supplierE@example.com", "Supplier E", 1234567894 },
                    { 6, "supplierF@example.com", "Supplier F", 1234567895 },
                    { 7, "supplierG@example.com", "Supplier G", 1234567896 },
                    { 8, "supplierH@example.com", "Supplier H", 1234567897 },
                    { 9, "supplierI@example.com", "Supplier I", 1234567898 },
                    { 10, "supplierJ@example.com", "Supplier J", 1234567899 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "LastRestocked", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Latest model smartphone", null, "Smartphone", 699.99m, 50 },
                    { 2, 1, "High performance laptop", null, "Laptop", 999.99m, 30 },
                    { 3, 2, "Cotton T-Shirt", null, "T-Shirt", 19.99m, 100 },
                    { 4, 2, "Denim jeans", null, "Jeans", 49.99m, 80 },
                    { 5, 3, "High-speed blender", null, "Blender", 89.99m, 40 },
                    { 6, 4, "Delicious recipes", null, "Cookbook", 24.99m, 60 },
                    { 7, 5, "Collectible action figure", null, "Action Figure", 14.99m, 200 },
                    { 8, 1, "Noise-cancelling headphones", null, "Wireless Headphones", 199.99m, 25 },
                    { 9, 1, "Next-gen gaming console", null, "Gaming Console", 499.99m, 15 },
                    { 10, 2, "Warm sweater", null, "Sweater", 39.99m, 70 },
                    { 11, 3, "Compact microwave", null, "Microwave", 129.99m, 35 },
                    { 12, 4, "Bestselling novel", null, "Novel", 15.99m, 90 },
                    { 13, 5, "1000-piece puzzle", null, "Puzzle", 19.99m, 150 },
                    { 14, 1, "Fitness smartwatch", null, "Smartwatch", 249.99m, 20 },
                    { 15, 2, "Winter jacket", null, "Jacket", 89.99m, 40 },
                    { 16, 3, "Automatic coffee maker", null, "Coffee Maker", 79.99m, 30 },
                    { 17, 4, "Inspirational biography", null, "Biography", 22.99m, 50 },
                    { 18, 5, "Fun board game", null, "Board Game", 29.99m, 60 },
                    { 19, 1, "Portable tablet", null, "Tablet", 299.99m, 25 },
                    { 20, 2, "Comfortable shorts", null, "Shorts", 24.99m, 80 }
                });

            migrationBuilder.InsertData(
                table: "ProductSuppliers",
                columns: new[] { "Id", "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductSuppliers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);
        }
    }
}
