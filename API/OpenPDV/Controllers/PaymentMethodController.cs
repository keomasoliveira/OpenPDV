using API.OpenPDV.Interfaces;
using API.OpenPDV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.OpenPDV.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todas as formas de pagamento.")]
        public async Task<IActionResult> GetAllPaymentMethods()
        {
            var paymentMethods = await _paymentMethodService.GetAllPaymentMethods();
            return Ok(paymentMethods);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma forma de pagamento específica pelo ID.")]
        public async Task<IActionResult> GetPaymentMethodById(string id)
        {
            var paymentMethod = await _paymentMethodService.GetPaymentMethodById(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return Ok(paymentMethod);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova forma de pagamento.")]
        public async Task<IActionResult> CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            var createdPaymentMethod = await _paymentMethodService.CreatePaymentMethod(paymentMethod);
            return CreatedAtAction(nameof(GetPaymentMethodById), new { id = createdPaymentMethod.Id }, createdPaymentMethod);
        }
    }
}
