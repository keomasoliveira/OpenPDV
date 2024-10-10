using API.OpenPDV.Data;
using API.OpenPDV.Interfaces;
using API.OpenPDV.Models;
using MongoDB.Driver;

namespace API.OpenPDV.Services
{
    public class SaleItemService : ISaleItemService
    {
        private readonly OpenPDVContext _context;

        public SaleItemService(OpenPDVContext context)
        {
            _context = context;
        }

        public async Task<SaleItem> CreateSaleItem(SaleItem saleItem)
        {
            await _context.SaleItems.InsertOneAsync(saleItem);
            return saleItem;
        }

        public async Task<SaleItem> GetSaleItemById(string saleItemId)
        {
            return await _context.SaleItems.Find(si => si.Id == saleItemId).FirstOrDefaultAsync();
        }
    }
}
