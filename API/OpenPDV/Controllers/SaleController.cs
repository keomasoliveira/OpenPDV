using API.OpenPDV.Data;
using API.OpenPDV.Dto;
using API.OpenPDV.Interfaces;
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
        private readonly ISaleService _saleService;

        public SaleController(OpenPDVContext context, ISaleService saleService)
        {
            _context = context;
            _saleService = saleService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova venda. As vendas são armazenadas permanentemente na coleção 'Sales'. Os itens de venda associados são movidos da coleção temporária 'SaleItems' para a venda.")]
        public async Task<IActionResult> CreateSale(SaleCreateDto saleCreateDto)
        {
            try
            {
                var sale = await _saleService.CreateSale(saleCreateDto);
                return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
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
