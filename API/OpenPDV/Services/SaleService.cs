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
            var openCashRegister = await _context.CashRegisters.Find(cr => cr.ClosingDate == null).FirstOrDefaultAsync();
            if (openCashRegister == null)
            {
                throw new InvalidOperationException("There is no open cash register. Please open a cash register before creating a sale.");
            }

            var saleItems = await _context.SaleItems.Find(si => saleCreateDto.ItemIds.Contains(si.Id)).ToListAsync();

            if (saleCreateDto.Payments == null || !saleCreateDto.Payments.Any())
            {
                throw new InvalidOperationException("A sale must have at least one payment method.");
            }

            var payments = new List<Payment>();
            foreach (var paymentDto in saleCreateDto.Payments)
            {
                var paymentMethod = await _context.PaymentMethods.Find(pm => pm.Id == paymentDto.PaymentMethodId).FirstOrDefaultAsync();
                if (paymentMethod == null)
                {
                    throw new InvalidOperationException($"Payment method with ID {paymentDto.PaymentMethodId} not found.");
                }

                payments.Add(new Payment
                {
                    PaymentMethodId = paymentDto.PaymentMethodId,
                    Amount = paymentDto.Amount
                });
            }

            var sale = new Sale
            {
                CashRegisterId = openCashRegister.Id,
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
