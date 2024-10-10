using API.OpenPDV.Models;

namespace API.OpenPDV.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<List<Product>> CreateProduct(List<Product> products);
        Task<Product> GetProductByBarcode(string barcode);
    }
}
