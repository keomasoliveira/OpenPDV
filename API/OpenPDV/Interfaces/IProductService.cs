using API.OpenPDV.Dto;
using API.OpenPDV.Models;

namespace API.OpenPDV.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<List<Product>> CreateProduct(List<ProductCreateDto> productCreateDtos);
        Task<Product> GetProductByBarcode(string barcode);
    }
}
