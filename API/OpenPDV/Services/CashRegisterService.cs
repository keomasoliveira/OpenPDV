using API.OpenPDV.Data;
using API.OpenPDV.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.OpenPDV.Interfaces;

namespace API.OpenPDV.Services
{
    public class CashRegisterService : ICashRegisterService
    {
        private readonly OpenPDVContext _context;
        private readonly IConfiguration _configuration;

        public CashRegisterService(OpenPDVContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<CashRegister> OpenCashRegister(string operatorId, decimal openingBalance)
        {
            var openCashRegister = await _context.CashRegisters.Find(cr => cr.ClosingDate == null).FirstOrDefaultAsync();
            if (openCashRegister != null)
            {
                return null;
            }

            var cashRegister = new CashRegister
            {
                OperatorId = operatorId,
                OpeningBalance = openingBalance,
                OpeningDate = DateTime.UtcNow
            };

            await _context.CashRegisters.InsertOneAsync(cashRegister);

            return cashRegister;
        }

        public async Task<CashRegisterClosing> CloseCashRegister(string cashRegisterId, decimal closingBalance)
        {
            var cashRegister = await _context.CashRegisters.Find(cr => cr.Id == cashRegisterId).FirstOrDefaultAsync();

            if (cashRegister == null || cashRegister.ClosingDate != null)
            {
                return null;
            }

            var sales = await _context.Sales.Find(s => s.Date >= cashRegister.OpeningDate && s.Date <= DateTime.UtcNow).ToListAsync();
            var totalSales = sales.Sum(s => s.Payments.Sum(p => p.Amount));

            var cashRegisterClosing = new CashRegisterClosing
            {
                CashRegisterId = cashRegisterId,
                ClosingBalance = cashRegister.OpeningBalance + totalSales,
                ClosingDate = DateTime.UtcNow
            };

            await _context.CashRegisterClosings.InsertOneAsync(cashRegisterClosing);

            cashRegister.ClosingDate = DateTime.UtcNow;
            await _context.CashRegisters.ReplaceOneAsync(cr => cr.Id == cashRegisterId, cashRegister);

            return cashRegisterClosing;
        }

        public async Task<CashRegister> GetCashRegisterById(string cashRegisterId)
        {
            return await _context.CashRegisters.Find(cr => cr.Id == cashRegisterId).FirstOrDefaultAsync();
        }

        public async Task<CashRegisterClosing> GetCashRegisterClosingById(string closingId)
        {
            return await _context.CashRegisterClosings.Find(crc => crc.Id == closingId).FirstOrDefaultAsync();
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
    }
}
