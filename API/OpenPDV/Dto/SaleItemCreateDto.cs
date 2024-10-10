namespace API.OpenPDV.Dto
{
    public class SaleItemCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
