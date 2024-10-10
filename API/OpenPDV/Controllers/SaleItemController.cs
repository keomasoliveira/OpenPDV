using API.OpenPDV.Data;
using API.OpenPDV.Dto;
using API.OpenPDV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Annotations;

namespace API.OpenPDV.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SaleItemController : ControllerBase
    {
        private readonly OpenPDVContext _context;

        public SaleItemController(OpenPDVContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo item de venda. Os itens de venda são armazenados temporariamente na coleção 'SaleItems' antes do fechamento da venda.")]
        public async Task<IActionResult> CreateSaleItem(SaleItemCreateDto saleItemCreateDto)
        {
            var saleItem = new SaleItem
            {
                ProductId = saleItemCreateDto.ProductId,
                Quantity = saleItemCreateDto.Quantity,
                Price = saleItemCreateDto.Price
            };

            await _context.SaleItems.InsertOneAsync(saleItem);

            return CreatedAtAction(nameof(GetSaleItem), new { id = saleItem.Id }, saleItem);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um item de venda específico pelo ID. Os itens de venda são armazenados temporariamente na coleção 'SaleItems' antes do fechamento da venda.")]
        public async Task<IActionResult> GetSaleItem(string id)
        {
            var saleItem = await _context.SaleItems.Find(si => si.Id == id).FirstOrDefaultAsync();

            if (saleItem == null)
            {
                return NotFound();
            }

            return Ok(saleItem);
        }
    }
}
