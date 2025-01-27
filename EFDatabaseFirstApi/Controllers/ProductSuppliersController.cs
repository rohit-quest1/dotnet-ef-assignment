using EFDatabaseFirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using EFDatabaseFirstApi.DTO;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSuppliersController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductSuppliersController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/ProductSuppliers/{productId}
        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<ProductSupplierDto>>> GetSuppliersForProduct(int productId)
        {
            var suppliers = await _context.ProductSuppliers
                .Where(ps => ps.ProductId == productId)
                .Include(ps => ps.Supplier)
                .ToListAsync();

            return suppliers.Select(ps => new ProductSupplierDto
            {
                ProductId = ps.ProductId,
                SupplierId = ps.SupplierId,
                SupplyPrice = ps.SupplyPrice
            }).ToList();
        }

        // GET: api/ProductSuppliers/supplier/{supplierId}
        [HttpGet("supplier/{supplierId}")]
        public async Task<ActionResult<IEnumerable<ProductSupplierDto>>> GetProductsBySupplier(int supplierId)
        {
            var products = await _context.ProductSuppliers
                .Where(ps => ps.SupplierId == supplierId)
                .Include(ps => ps.Product)
                .ToListAsync();

           
            var productSupplierDtos = products.Select(ps => new ProductSupplierDto
            {
                ProductId = ps.ProductId,
                SupplierId = ps.SupplierId,
                SupplyPrice = ps.SupplyPrice
            }).ToList();

            return Ok(productSupplierDtos);
        }

        // POST: api/ProductSuppliers
        [HttpPost]
        public async Task<ActionResult<ProductSupplier>> AddSupplierToProduct(ProductSupplier productSupplier)
        {
            _context.ProductSuppliers.Add(productSupplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSuppliersForProduct), new { productId = productSupplier.ProductId }, productSupplier);
        }

        // DELETE: api/ProductSuppliers
        [HttpDelete]
        public async Task<IActionResult> RemoveSupplierFromProduct(int productId, int supplierId)
        {
            var productSupplier = await _context.ProductSuppliers
                .FirstOrDefaultAsync(ps => ps.ProductId == productId && ps.SupplierId == supplierId);

            if (productSupplier == null)
            {
                return NotFound();
            }

            _context.ProductSuppliers.Remove(productSupplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
} 