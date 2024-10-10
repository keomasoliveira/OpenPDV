using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.OpenPDV.Models
{
    public class SaleItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
