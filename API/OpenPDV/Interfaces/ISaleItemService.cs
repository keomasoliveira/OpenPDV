using API.OpenPDV.Dto;
using API.OpenPDV.Models;

namespace API.OpenPDV.Interfaces
{
    public interface ISaleItemService
    {
        Task<SaleItem> CreateSaleItem(SaleItemCreateDto saleItemCreateDto);
        Task<SaleItem> GetSaleItemById(string saleItemId);
    }
}
