using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.OpenPDV.Models
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public List<SaleItem> Items { get; set; }
        public List<Payment> Payments { get; set; }
        public DateTime Date { get; set; }
    }
}
