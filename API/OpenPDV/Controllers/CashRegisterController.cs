using API.OpenPDV.Data;
using API.OpenPDV.Dto;
using API.OpenPDV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using API.OpenPDV.Interfaces;
using API.OpenPDV.Services;
using MongoDB.Bson;

namespace API.OpenPDV.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CashRegisterController : ControllerBase
    {
        private readonly ICashRegisterService _cashRegisterService;
        private readonly IConfiguration _configuration;

        public CashRegisterController(ICashRegisterService cashRegisterService, IConfiguration configuration)
        {
            _cashRegisterService = cashRegisterService;
            _configuration = configuration;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Abre um novo caixa com o valor inicial e o operador especificados.")]
        public async Task<IActionResult> OpenCashRegister(CashRegisterCreateDto cashRegisterCreateDto)
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var cashRegister = await _cashRegisterService.OpenCashRegister(userId, cashRegisterCreateDto.OpeningBalance);

            if (cashRegister == null)
            {
                return BadRequest("There is already an open cash register");
            }

            return CreatedAtAction(nameof(GetCashRegister), new { id = cashRegister.Id }, cashRegister);
        }

        private string GenerateJwtToken(string operatorId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, operatorId)
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém os detalhes de um caixa específico pelo ID.")]
        public async Task<IActionResult> GetCashRegister(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest("Invalid cash register ID format.");
            }

            var cashRegister = await _cashRegisterService.GetCashRegisterById(id);

            if (cashRegister == null)
            {
                return NotFound();
            }

            return Ok(cashRegister);
        }

        [HttpPut("{id}/close")]
        [SwaggerOperation(Summary = "Fecha um caixa aberto.")]
        public async Task<IActionResult> CloseCashRegister(string id, CashRegisterClosingCreateDto closingDto)
        {
            var cashRegisterClosing = await _cashRegisterService.CloseCashRegister(id, closingDto.ClosingBalance);

            if (cashRegisterClosing == null)
            {
                return BadRequest("Cash register is already closed or does not exist");
            }

            return NoContent();
        }

        [HttpGet("closings/{id}")]
        [SwaggerOperation(Summary = "Obtém os detalhes de um fechamento de caixa específico pelo ID.")]
        public async Task<IActionResult> GetCashRegisterClosing(string id)
        {
            var cashRegisterClosing = await _cashRegisterService.GetCashRegisterClosingById(id);

            if (cashRegisterClosing == null)
            {
                return NotFound();
            }

            return Ok(cashRegisterClosing);
        }
    }
}
