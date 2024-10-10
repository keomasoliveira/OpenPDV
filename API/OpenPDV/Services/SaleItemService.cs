using API.OpenPDV.Data;
using API.OpenPDV.Dto;
using API.OpenPDV.Models;
using MongoDB.Driver;
using API.OpenPDV.Interfaces;

namespace API.OpenPDV.Services
{
    public class SaleItemService : ISaleItemService
    {
        private readonly OpenPDVContext _context;

        public SaleItemService(OpenPDVContext context)
        {
            _context = context;
        }

        public async Task<SaleItem> CreateSaleItem(SaleItemCreateDto saleItemCreateDto)
        {
            var saleItem = new SaleItem
            {
                ProductId = saleItemCreateDto.ProductId,
                Quantity = saleItemCreateDto.Quantity,
                Price = saleItemCreateDto.Price
            };

            await _context.SaleItems.InsertOneAsync(saleItem);

            return saleItem;
        }

        public async Task<SaleItem> GetSaleItemById(string saleItemId)
        {
            return await _context.SaleItems.Find(si => si.Id == saleItemId).FirstOrDefaultAsync();
        }
    }
}
