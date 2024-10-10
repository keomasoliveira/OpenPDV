namespace API.OpenPDV.Dto
{
    public class SaleItemCreateDto
    {
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
