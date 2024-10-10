using API.OpenPDV.Data;
using API.OpenPDV.Interfaces;
using API.OpenPDV.Models;
using MongoDB.Driver;

namespace API.OpenPDV.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OpenPDVContext _context;

        public ProductRepository(OpenPDVContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.Find(p => p.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> CreateProduct(List<Product> products)
        {
            await _context.Products.InsertManyAsync(products);
            return products;
        }
    }
}
