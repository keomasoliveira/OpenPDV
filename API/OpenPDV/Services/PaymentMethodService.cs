using API.OpenPDV.Data;
using API.OpenPDV.Interfaces;
using API.OpenPDV.Models;
using MongoDB.Driver;

namespace API.OpenPDV.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly OpenPDVContext _context;

        public PaymentMethodService(OpenPDVContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentMethod>> GetAllPaymentMethods()
        {
            return await _context.PaymentMethods.Find(_ => true).ToListAsync();
        }

        public async Task<PaymentMethod> GetPaymentMethodById(string id)
        {
            return await _context.PaymentMethods.Find(pm => pm.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PaymentMethod> CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            await _context.PaymentMethods.InsertOneAsync(paymentMethod);
            return paymentMethod;
        }
    }
}
