using MongoDB.Bson;

namespace API.OpenPDV.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
    }
}
