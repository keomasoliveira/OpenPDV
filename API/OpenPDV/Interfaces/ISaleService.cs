using API.OpenPDV.Dto;
using API.OpenPDV.Models;

namespace API.OpenPDV.Interfaces
{
    public interface ISaleService
    {
        Task<Sale> CreateSale(SaleCreateDto saleCreateDto);
        Task<Sale> GetSaleById(string saleId);
    }
}
