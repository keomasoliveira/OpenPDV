using API.OpenPDV.Models;

namespace API.OpenPDV.Interfaces
{
    public interface ISaleItemService
    {
        Task<SaleItem> CreateSaleItem(SaleItem saleItem);
        Task<SaleItem> GetSaleItemById(string saleItemId);
    }
}
