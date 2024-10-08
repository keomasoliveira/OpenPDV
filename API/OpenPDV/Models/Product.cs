using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.OpenPDV.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Barcode { get; set; }

        public decimal Price { get; set; }
    }
}
