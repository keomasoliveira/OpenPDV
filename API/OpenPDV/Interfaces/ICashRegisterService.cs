using API.OpenPDV.Models;

namespace API.OpenPDV.Interfaces
{
    public interface ICashRegisterService
    {
        Task<CashRegister> OpenCashRegister(string operatorId, decimal openingBalance);
        Task<CashRegisterClosing> CloseCashRegister(string cashRegisterId, decimal closingBalance);
        Task<CashRegister> GetCashRegisterById(string cashRegisterId);
        Task<CashRegisterClosing> GetCashRegisterClosingById(string closingId);
    }
}
