using API.OpenPDV.Dto;
using API.OpenPDV.Interfaces;
using API.OpenPDV.Models;

namespace API.OpenPDV.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        public async Task<List<Product>> CreateProduct(List<ProductCreateDto> productCreateDtos)
        {
            var products = await _productRepository.GetAllProducts();
            var lastProduct = products.OrderByDescending(p => p.Id).FirstOrDefault();

            int lastId = lastProduct?.Id ?? 0;

            var newProducts = productCreateDtos.Select((dto, index) => new Product
            {
                Id = lastId + index + 1,
                Description = dto.Description,
                Barcode = dto.Barcode,
                Price = dto.Price
            }).ToList();

            return await _productRepository.CreateProduct(newProducts);
        }
    }
}
