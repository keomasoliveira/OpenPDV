using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.OpenPDV.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Method { get; set; }
        public decimal Amount { get; set; }
    }
}
