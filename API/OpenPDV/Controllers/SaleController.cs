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
    public class SaleController : ControllerBase
    {
        private readonly OpenPDVContext _context;

        public SaleController(OpenPDVContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova venda. As vendas são armazenadas permanentemente na coleção 'Sales'. Os itens de venda associados são movidos da coleção temporária 'SaleItems' para a venda.")]
        public async Task<IActionResult> CreateSale(SaleCreateDto saleCreateDto)
        {
            var saleItems = await _context.SaleItems.Find(si => saleCreateDto.ItemIds.Contains(si.Id)).ToListAsync();

            var payments = saleCreateDto.Payments.Select(p => new Payment
            {
                Method = p.Method,
                Amount = p.Amount
            }).ToList();

            var sale = new Sale
            {
                Items = saleItems,
                Payments = payments,
                Date = DateTime.UtcNow
            };

            await _context.Sales.InsertOneAsync(sale);

            return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma venda específica pelo ID. As vendas são armazenadas permanentemente na coleção 'Sales'.")]
        public async Task<IActionResult> GetSale(string id)
        {
            var sale = await _context.Sales.Find(s => s.Id == id).FirstOrDefaultAsync();

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }
    }
}
