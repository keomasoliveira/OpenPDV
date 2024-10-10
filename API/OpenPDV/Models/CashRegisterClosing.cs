using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.OpenPDV.Models
{
    public class CashRegisterClosing
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string CashRegisterId { get; set; }
        public decimal ClosingBalance { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
