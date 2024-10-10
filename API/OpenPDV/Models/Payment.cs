using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.OpenPDV.Models
{
    public class Payment
    {
        public string PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
    }
}
