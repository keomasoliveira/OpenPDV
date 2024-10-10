using API.OpenPDV.Data;
using API.OpenPDV.Dto;
using API.OpenPDV.Models;
using MongoDB.Driver;
using API.OpenPDV.Interfaces;

namespace API.OpenPDV.Services
{
    public class SaleService : ISaleService
    {
        private readonly OpenPDVContext _context;

        public SaleService(OpenPDVContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateSale(SaleCreateDto saleCreateDto)
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

            return sale;
        }

        public async Task<Sale> GetSaleById(string saleId)
        {
            return await _context.Sales.Find(s => s.Id == saleId).FirstOrDefaultAsync();
        }
    }
}
