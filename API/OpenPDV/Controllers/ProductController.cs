using API.OpenPDV.Models;
using API.OpenPDV.Dto;
using Microsoft.AspNetCore.Mvc;
using API.OpenPDV.Data;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace API.OpenPDV.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly OpenPDVContext _context;

        public ProductController(OpenPDVContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os produtos. Os produtos são armazenados permanentemente na coleção 'Products'.")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.Find(_ => true).ToListAsync();
            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Barcode = p.Barcode,
                Price = p.Price
            });
            return Ok(productDtos);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo produto. Os produtos são armazenados permanentemente na coleção 'Products'.")]
        public async Task<IActionResult> CreateProduct(List<ProductCreateDto> productCreateDtos)
        {
            var lastProduct = await _context.Products.Find(_ => true)
                .SortByDescending(p => p.Id)
                .FirstOrDefaultAsync();

            int lastId = lastProduct?.Id ?? 0;

            var products = productCreateDtos.Select((dto, index) => new Product
            {
                Id = lastId + index + 1,
                Description = dto.Description,
                Barcode = dto.Barcode,
                Price = dto.Price
            }).ToList();

            await _context.Products.InsertManyAsync(products);

            var createdProductDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Barcode = p.Barcode,
                Price = p.Price
            }).ToList();

            return CreatedAtAction(nameof(GetAllProducts), createdProductDtos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um produto específico pelo ID. Os produtos são armazenados permanentemente na coleção 'Products'.")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Barcode = product.Barcode,
                Price = product.Price
            };

            return Ok(productDto);
        }
    }
}
