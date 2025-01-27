using EFCodeFirstApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(int pageNumber = 1, int pageSize = 10, string sortBy = "Name", string sortOrder = "asc")
        {
            var productsQuery = _context.Products.AsQueryable();

            // Apply sorting
            productsQuery = sortOrder.ToLower() == "desc" 
                ? productsQuery.OrderByDescending(p => EF.Property<object>(p, sortBy))
                : productsQuery.OrderBy(p => EF.Property<object>(p, sortBy));

            var products = await productsQuery
                .Include(p => p.Category)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var productDtos = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();

            return productDtos;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            // Map to DTO
            var productDto = new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return productDto;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.CategoryId = productDto.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/Products/price-range?min=10&max=100&pageNumber=1&pageSize=10&sortBy=Price&sortOrder=desc
        [HttpGet("price-range")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByPriceRange(decimal min, decimal max, 
        int pageNumber = 1, int pageSize = 10, string sortBy = "Price", string sortOrder = "asc")
        {
            var productsQuery = _context.Products
                .Where(p => p.Price >= min && p.Price <= max);

            productsQuery = sortOrder.ToLower() == "desc" 
                ? productsQuery.OrderByDescending(p => EF.Property<object>(p, sortBy))
                : productsQuery.OrderBy(p => EF.Property<object>(p, sortBy));

            var products = await productsQuery
                .Include(p => p.Category)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var productDtos = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();

            return productDtos;
        }

        // GET: api/Products/category/{categoryId}?pageNumber=1&pageSize=10&sortBy=Name&sortOrder=asc
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(int categoryId, int pageNumber = 1, 
        int pageSize = 10, string sortBy = "Name", string sortOrder = "asc")
        {
            var productsQuery = _context.Products
                .Where(p => p.CategoryId == categoryId);

            // Apply sorting
            productsQuery = sortOrder.ToLower() == "desc" 
                ? productsQuery.OrderByDescending(p => EF.Property<object>(p, sortBy))
                : productsQuery.OrderBy(p => EF.Property<object>(p, sortBy));

            var products = await productsQuery
                .Include(p => p.Category)
                .Include(p => p.ProductSuppliers) // Include supplier information
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var productDtos = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();

            return productDtos;
        }

        // GET: api/Products/low-stock?pageNumber=1&pageSize=10&sortBy=Stock&sortOrder=asc
        [HttpGet("low-stock")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsWithLowStock(int threshold = 5, int pageNumber = 1, 
        int pageSize = 10, string sortBy = "Stock", string sortOrder = "asc")
        {
            var productsQuery = _context.Products
                .Where(p => p.Stock < threshold);

            // Apply sorting
            productsQuery = sortOrder.ToLower() == "desc" 
                ? productsQuery.OrderByDescending(p => EF.Property<object>(p, sortBy))
                : productsQuery.OrderBy(p => EF.Property<object>(p, sortBy));

            var products = await productsQuery
                .Include(p => p.Category)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var productDtos = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();

            return productDtos;
        }

        // GET: api/Products/search?name=example&pageNumber=1&pageSize=10&sortBy=Name&sortOrder=asc
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProductsByName(string name, int pageNumber = 1, int pageSize = 10, string sortBy = "Name", string sortOrder = "asc")
        {
            var productsQuery = _context.Products
                .Where(p => p.Name.Contains(name));

            // Apply sorting
            productsQuery = sortOrder.ToLower() == "desc" 
                ? productsQuery.OrderByDescending(p => EF.Property<object>(p, sortBy))
                : productsQuery.OrderBy(p => EF.Property<object>(p, sortBy));

            var products = await productsQuery
                .Include(p => p.Category)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var productDtos = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();

            return productDtos;
        }
    }
}