using API.OpenPDV.Models;

namespace API.OpenPDV.Dto
{
    public class SaleCreateDto
    {
        public required List<string> ItemIds { get; set; }
        public List<PaymentCreateDto> Payments { get; set; }
    }

    public class PaymentCreateDto
    {
        public string Method { get; set; }
        public decimal Amount { get; set; }
    }
}
