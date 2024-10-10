using API.OpenPDV.Models;

namespace API.OpenPDV.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethod>> GetAllPaymentMethods();
        Task<PaymentMethod> GetPaymentMethodById(string id);
        Task<PaymentMethod> CreatePaymentMethod(PaymentMethod paymentMethod);
    }
}
